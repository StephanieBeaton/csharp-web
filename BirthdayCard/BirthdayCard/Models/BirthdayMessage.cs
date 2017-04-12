using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BirthdayCard.Models
{
    public class BirthdayMessage
    {
        public int BirthdayMessageId { get; set; }

        [Required(ErrorMessage = "Please enter to whom the card will be sent")]
        public string To { get; set; }

        [Required(ErrorMessage = "Please enter who is sending the card")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please enter the birthday message")]
        public string MessageBody { get; set; }

        [Required(ErrorMessage = "Please select a card type")]
        public int CardType { get; set; }
    }
}