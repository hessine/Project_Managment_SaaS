using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
   // public enum TypeContart { Freelancer, Employee }
   // public enum TypeAvailability { Available, NotAvailable, AvailableSoon }
    public class MandateViewModel
    {

        public int ProjectId { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }

        public int userId { get; set; }
        [Required(ErrorMessage = "The start date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateBegin { get; set; }
        [Required(ErrorMessage = "The End date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateEnd { get; set; }
        public float Cost { get; set; }
        public int Duree { get; set; }
        public TypeAvailability Availability { get; set; }
        public virtual Resource resource { get; set; }
        public ProjectViewModel projet { get; set; }

        public TypeMandate mandat { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateEnd < DateBegin)
            {
                yield return
                  new ValidationResult(errorMessage: "EndDate must be greater than StartDate",
                                       memberNames: new[] { "EndDate" });
            }
        }

    }
}