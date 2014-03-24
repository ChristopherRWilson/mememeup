using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeMeUp.Models
{
    /// <summary>
    ///  The meme model, that customized captions will be based off of.
    /// </summary>
    public class Meme
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public long AddedBy { get; set; } // User ID of who originally uploaded the meme
        public bool Enabled { get; set; } // Will this meme be visible to users?
        public string FileUrl { get; set; }
        public string ThumbUrl { get; set; }
    }
}