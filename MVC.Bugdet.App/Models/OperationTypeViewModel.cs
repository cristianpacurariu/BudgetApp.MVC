using Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Bugdet.App.Models
{
    public class OperationTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public bool IsCredit { get; set; }
        public virtual List<OperationDto> Operations { get; set; }
    }
}