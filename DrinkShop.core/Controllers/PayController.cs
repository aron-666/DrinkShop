using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DrinkShop.core.Controllers
{
    public class PayController : Controller
    {
        private Models.Db.drinkShopContext _shopContext;
        private IConfiguration _configuration;
        public PayController(Models.Db.drinkShopContext shopContext, IConfiguration configuration)
        {
            _shopContext = shopContext;
            _configuration = configuration;
        }

        /// <summary>
        /// 付款
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IActionResult Index([FromQuery] string order)
        {
            order += "==";
            ViewBag.order = order;
            order = DecodeFrom64(order);
            int orderId =  int.Parse(order) - 1000000000;

            ViewModels.ResponseItems items = new ViewModels.ResponseItems();

            var orderDao = _shopContext
                .Orders
                .Where(x => x.Id == orderId)
                .First();

            if (orderDao.Payment)
                return View("Paid");
            items.Items = _shopContext
                .OrderItems
                .Where(x => x.IdOrder == orderDao.Id)
                .Select(x => new ViewModels.ResponseItem() { Count = x.Count, Price = x.Price, Ice = x.IdIceNavigation.Name, Size = x.IdSizeNavigation.Name, Sweetness = x.IdSweetnessNavigation.Name, Name = x.IdItemNavigation.Name })
                .ToList();
            ViewBag.time = (orderDao.Created ?? DateTime.MinValue).AddHours(8).ToString("yyyy-MM-dd HH:mm:ss");

            return View(items);
        }

        /// <summary>
        /// 取得訂單內容
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IActionResult GetOrder([FromQuery] string order)
        {
            order += "==";
            order = DecodeFrom64(order);
            int orderId = int.Parse(order) - 1000000000;

            ViewBag.order = orderId;
            ViewModels.ResponseItems items = new ViewModels.ResponseItems();

            var orderDao = _shopContext
                .Orders
                .Where(x => x.Id == orderId)
                .First();

            items.Items = _shopContext
                .OrderItems
                .Where(x => x.IdOrder == orderDao.Id)
                .Select(x => new ViewModels.ResponseItem() { Count = x.Count, Price = x.Price, Ice = x.IdIceNavigation.Name, Size = x.IdSizeNavigation.Name, Sweetness = x.IdSweetnessNavigation.Name, Name = x.IdItemNavigation.Name })
                .ToList();
            ViewBag.time = (orderDao.Created ?? DateTime.MinValue).AddHours(8).ToString("yyyy-MM-dd HH:mm:ss");
            if (orderDao.Payment)
            {
                ViewBag.payTime = (orderDao.Modified ?? DateTime.MinValue).AddHours(8).ToString("yyyy-MM-dd HH:mm:ss");
            }
            return View(items);
        }

        /// <summary>
        /// 測試用金流
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IActionResult TestPay([FromQuery] string order)
        {
            var order1 = order;
            order = DecodeFrom64(order);
            int orderId = int.Parse(order) - 1000000000;

            ViewBag.order = orderId;

            var orderDao = _shopContext
                .Orders
                .Where(x => x.Id == orderId)
                .First();
            if (orderDao.Payment)
                return View("Paid");
            orderDao.Payment = true;
            _shopContext.SaveChanges();
            try
            {
                
                var payRoot = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/Pay";
                var data = new { id = orderDao.ClientId, text = $"付款完成!!\r\n訂單網址：{payRoot}/GetOrder?order={order1.Replace("==", "")}" };

                WebClient client = new WebClient();
                client.UploadData(_configuration.GetValue<string>("PaySuccessUrl"), "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
            }
            catch (Exception ex)
            {
                ViewBag.ex = ex.ToString();
            }
            return View();
        }

        /// <summary>
        /// 已經付款過的頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult Paid()
        {
            return View();
        }

        private static string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes

                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }

        private static string DecodeFrom64(string encodedData)
        {

            byte[] encodedDataAsBytes

                = System.Convert.FromBase64String(encodedData);

            string returnValue =

               System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

            return returnValue;

        }
    }
}