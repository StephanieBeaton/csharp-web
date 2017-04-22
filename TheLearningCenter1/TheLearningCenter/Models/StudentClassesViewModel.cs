using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheLearningCenter.Models
{
    public class StudentClassesViewModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public double ClassPaid { get; set; }

        public StudentClassesViewModel(int userId,
            int classId,
            string className,
            string classDescription,
            double classPrice)
        {
            UserId = userId;
            ClassId = classId;
            ClassName = className;
            ClassDescription = classDescription;
            ClassPaid = classPrice;
        }
    }
}