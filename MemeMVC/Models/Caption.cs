using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeMeUp.Models
{
    /// <summary>
    ///  Contains the personalized and captioned memes that have been created, based on the MemeMeUp.Models.Meme class
    /// </summary>
    public class Caption
    {
        public long Id { get; set; }
        public string TopText { get; set; }
        public string BottomText { get; set; }
        public DateTime AddedDate { get; set; }
        public long AddedBy { get; set; }
        public bool Enabled { get; set; }
    }
}