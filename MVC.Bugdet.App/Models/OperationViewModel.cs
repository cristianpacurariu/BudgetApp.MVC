using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Bugdet.App.Models
{
    public class OperationViewModel
    {
        public int Id { get; set; }

        [Required]
        public int IdAccount { get; set; }

        [Required]
        public int IdOperationType { get; set; }

        [Required]
        public decimal Ammount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual AccountDto Account { get; set; }
        public virtual OperationTypeDto OperationType { get; set; }
        public List<SelectListItem> Accounts { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}