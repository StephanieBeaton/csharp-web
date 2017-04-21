using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheLearningCenter.Models
{
    public class ClassMasterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Sessions { get; set; }

        public ClassMasterModel(int id, string name, string description, double price, int sessions)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Sessions = sessions;
        }
    }
}