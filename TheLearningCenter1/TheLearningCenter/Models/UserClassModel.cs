using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheLearningCenter.Models
{
    public class UserClassModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public int ClassName { get; set; }
        public int ClassDescription { get; set; }
        public int ClassPaid { get; set; }

        public UserClassModel(int userId, int classId)
        {
            UserId = userId;
            ClassId = classId;

            // get details about a particular class

            //ClassName = className;
            //ClassDescription = classDescription;
            //ClassPaid = classPrice;

        }

    }
}