using Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.Bugdet.App.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public int IdCurrency { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        public CurrencyDto Currency { get; set; }

        public List<SelectListItem> Currencies { get; set; }
    }
}