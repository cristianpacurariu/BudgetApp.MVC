using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Bugdet.App.Models
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<AccountDto> Accounts { get; set; }
    }
}