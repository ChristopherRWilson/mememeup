using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeMeUp.Models
{
    public class Meme
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public long AddedBy { get; set; }
        public bool Enabled { get; set; }
    }
}