using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTable_Basics.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}