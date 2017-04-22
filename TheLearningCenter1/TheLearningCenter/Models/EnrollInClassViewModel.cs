using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;   // for [Required]

namespace TheLearningCenter.Models
{
    public class EnrollInClassViewModel
    {
        public ClassMasterModel[] ClassMasters { get; set; }

       [Required(ErrorMessage = "Please select a class")]
        public int ClassId {get; set;}

        public int UserId { get; set; }     // remove UserId property after Session["User"] implemented
    }
}