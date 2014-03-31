using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MemeMeUp.Models
{
    /// <summary>
    ///  Contains the personalized and captioned memes that have been created, based on the MemeMeUp.Models.Meme class
    /// </summary>
    public class Caption
    {
        public long Id { get; set; }

        [DisplayName("Top Line")]
        [StringLength(100, ErrorMessage = "Top line cannot be longer than 100 characters.")]
        public string TopText { get; set; }

        [DisplayName("Bottom Line")]
        [StringLength(100, ErrorMessage = "Bottom line cannot be longer than 100 characters.")]
        public string BottomText { get; set; }
        public DateTime AddedDate { get; set; }
        public long AddedBy { get; set; }
        public bool Enabled { get; set; }
        public long MemeID { get; set; }
    }
}