using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class GuestResponse
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

    }
}