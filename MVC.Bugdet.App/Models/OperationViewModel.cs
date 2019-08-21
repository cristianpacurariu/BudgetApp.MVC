using Domain;
using MVC.Bugdet.App.Utils;
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

        [Required(ErrorMessage ="You have to define an account first!")]
        public int? IdAccount { get; set; }

        [Required(ErrorMessage ="You have to define a category first!")]
        public int? IdOperationType { get; set; }

        [Required]
        //[GreaterThanZero]
        [Range(0.1, int.MaxValue, ErrorMessage = "The ammount has to be greater than zero.")]
        public decimal Ammount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        [Required]
        public string Description { get; set; }
        public virtual AccountDto Account { get; set; }
        public virtual OperationTypeDto OperationType { get; set; }
        public List<SelectListItem> Accounts { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}