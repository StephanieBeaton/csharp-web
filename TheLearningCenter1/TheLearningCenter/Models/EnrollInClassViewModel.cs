using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheLearningCenter.Models
{
    public class EnrollInClassViewModel
    {
        public ClassMasterModel[] ClassMasters { get; set; }

        public int ClassId {get; set;}

        public int UserId { get; set; }     // remove UserId property after Session["User"] implemented
    }
}