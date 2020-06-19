using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.core.ViewModels
{
    public class Dao2ViewMapper : Profile
    {
        public Dao2ViewMapper()
        {
            CreateMap<Items, ResponseItem>();
        }
    }
}
