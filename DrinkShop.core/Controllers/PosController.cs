using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Aron.Http.Tools.HttpMsg;
using Aron.Web.Api.Interfaces.Message;
using Aron.Web.Api.Models.Message;
using DrinkShop.core.Models.Db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrinkShop.core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PosController : ControllerBase
    {
        private Models.Db.drinkShopContext _shopContext;
        private AutoMapper.IMapper _mapper;
        internal IBodyConverter<IResponseMessage> _bodyConverter = new JsonBodyConverter<IResponseMessage>();
        private IWebHostEnvironment _env;

        public PosController(Models.Db.drinkShopContext shopContext, AutoMapper.IMapper mapper, IWebHostEnvironment env)
        {
            _shopContext = shopContext;
            _mapper = mapper;
            _env = env;
        }

        /// <summary>
        /// 取得各項估價
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseMessage<ViewModels.ResponseItems>), 200)]
        [ProducesResponseType(typeof(ErrorResponseMessage), 500)]
        [HttpPost]
        public HttpResponseMessage GetPrice(List<ViewModels.Items> items)
        {
            HttpResponseMessage ret = null;
            try
            {
                ret = CreateResponse(ConvertToResponseItems(items));
            }
            catch(Exception ex)
            {
                ret = CreateErrorResponse("null", ex.Message);

            }

            return ret;
        }


        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseMessage<ViewModels.ResponseCreateOrder>), 200)]
        [ProducesResponseType(typeof(ErrorResponseMessage), 500)]
        [HttpPost]
        public HttpResponseMessage CreateOrder(ViewModels.OrderItems items)
        {
            HttpResponseMessage ret = null;
            List<Models.Db.OrderItems> orderItems = new List<OrderItems>();
            var temp = ConvertToResponseItems(items.Items);
            try
            {
                using(var ten = _shopContext.Database.BeginTransaction())
                {
                    var order = new Orders()
                    {
                        ClientId = items.ClientID,
                        Phone = items.Phone,
                        Price = temp.Total,
                        Payment = false
                    };
                    _shopContext.Orders.Add(order);
                    _shopContext.SaveChanges();

                    foreach (var x in temp.Items)
                    {
                        orderItems.Add(new OrderItems()
                        {
                            Count = x.Count,
                            IdSize = _shopContext.Size.Where(c => c.Name == x.Size).FirstOrDefault().Id,
                            IdIce = _shopContext.Ice.Where(c => c.Name == x.Ice).FirstOrDefault().Id,
                            IdItem = _shopContext.Items.Where(c => c.Name == x.Name).FirstOrDefault().Id,
                            IdSweetness = _shopContext.Sweetness.Where(c => c.Name == x.Sweetness).FirstOrDefault().Id,
                            Price = x.Price,
                            IdOrder = order.Id
                        });
                    };

                    _shopContext.OrderItems.AddRange(orderItems);
                    _shopContext.SaveChanges();
                    ten.Commit();
                    var payRoot = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/Pay";
                    var orderStr = EncodeTo64((order.Id + 1000000000).ToString());
                    ViewModels.ResponseCreateOrder response = new ViewModels.ResponseCreateOrder()
                    {
                        OrderUrl = $"{payRoot}/GetOrder?order={orderStr.Replace("==", "")}",
                        PayUrl = $"{payRoot}?order={orderStr.Replace("==", "")}",
                        Price = order.Price
                    };
                    ret = CreateResponse(response);

                }


            }
            catch(Exception ex)
            {
                ret = CreateErrorResponse("null", ex.Message);
            }
            return ret;
        }

        private ViewModels.ResponseItems ConvertToResponseItems(List<ViewModels.Items> items)
        {
            List<ViewModels.ResponseItem> resp = items
                    .Select(x => _mapper.Map<ViewModels.ResponseItem>(x))
                    .ToList();

            foreach (var i in resp)
            {
                var temp = _shopContext
                    .Items
                    .Where(x => x.Name == i.Name)
                    .FirstOrDefault();

                if (temp == null)
                    throw new ArgumentException("Args not found");
                if (i.Count == 0) i.Count = 1;

                if (temp.CanSize)
                {
                    var size = _shopContext
                        .Size
                        .Where(x => x.Name == i.Size)
                        .FirstOrDefault();
                    if (size == null)
                    {
                        i.Size = "Large";
                        size = _shopContext
                            .Size
                            .Where(x => x.Name == i.Size)
                            .FirstOrDefault();
                        i.Price = (temp.BasePrice + (temp.AddPrice * (size.Id - 1))) * i.Count;
                    }
                    else
                    {
                        i.Price = (temp.BasePrice + (temp.AddPrice * (size.Id - 1))) * i.Count;

                    }
                }
                else
                {
                    i.Price = temp.BasePrice * i.Count;
                    i.Size = "Large";
                }

                if (temp.CanIce)
                {
                    var ice = _shopContext.Ice
                        .Where(x => x.Name == i.Ice)
                        .FirstOrDefault();
                    if (ice == null)
                        i.Ice = "全冰";
                }
                else
                    i.Ice = "全冰";
                if (temp.CanSweetness)
                {
                    var sweet = _shopContext.Sweetness
                        .Where(x => x.Name == i.Sweetness)
                        .FirstOrDefault();
                    if (sweet == null)
                        i.Sweetness = "全糖";
                }
                else
                    i.Sweetness = "全糖";


            }
            return new ViewModels.ResponseItems() { Items = resp };
        }
        private HttpResponseMessage CreateResponse<T>(T data)
        {
            var temp = new StdMsg<IResponseMessage>(_bodyConverter)
            {
                ContentType = ContentType.JSON,
            };
            var t = new ResponseMessage<T>();
            t.data = data;
            temp.Data = t;
            return temp.CreateResponseMsg(System.Net.HttpStatusCode.OK);
        }


        private static string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes

                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }
        private HttpResponseMessage CreateErrorResponse(string code, string msg)
        {
            var temp = new StdMsg<IResponseMessage>(_bodyConverter)
            {
                ContentType = ContentType.JSON,
            };
            var t = new ErrorResponseMessage();
            t.error_code = code;
            t.error_message = msg;
            temp.Data = t;
            return temp.CreateResponseMsg(System.Net.HttpStatusCode.InternalServerError);
        }

        private HttpResponseMessage CreateErrorResponse<T>(T data, string code, string msg)
        {
            var temp = new StdMsg<IResponseMessage>(_bodyConverter)
            {
                ContentType = ContentType.JSON,
            };
            var t = new ErrorResponseMessage<T>();
            t.error_code = code;
            t.error_message = msg;
            t.data = data;
            temp.Data = t;
            return temp.CreateResponseMsg(System.Net.HttpStatusCode.InternalServerError);
        }


    }
}