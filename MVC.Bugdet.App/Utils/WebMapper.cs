using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Domain;
using MVC.Bugdet.App.Models;

namespace MVC.Bugdet.App.Utils
{
    public class WebMapper:Profile
    {
        public WebMapper()
        {
            this.CreateMap<AccountDto, AccountViewModel>().ReverseMap();
            this.CreateMap<OperationDto, OperationViewModel>().ReverseMap();
            this.CreateMap<OperationTypeDto, OperationTypeViewModel>().ReverseMap();
            this.CreateMap<CurrencyDto, CurrencyViewModel>().ReverseMap();
        }
    }
}