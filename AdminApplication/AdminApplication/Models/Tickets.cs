
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminApplication.Models
{
    public class Tickets 
    {
        public Guid Id { get; set; }
        public string MovieName { get; set; }
        public string Zarn { get; set; }
        public DateTime DateAvailable { get; set; }   
        public double TicketPrice { get; set; }

        
    }
}
