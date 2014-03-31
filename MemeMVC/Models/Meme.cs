using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MemeMeUp.Models
{
    /// <summary>
    ///  The meme model, that customized captions will be based off of.
    /// </summary>
    public class Meme
    {
        public long Id { get; set; }
        
        [DisplayName( "Meme")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(25, ErrorMessage = "Name cannot be longer than 25 characters.")]
        public string Title { get; set; }

        [DisplayName ( "Description")]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(250, ErrorMessage = "Name cannot be longer than 250 characters.")]
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public long AddedBy { get; set; } // User ID of who originally uploaded the meme
        public bool Enabled { get; set; } // Will this meme be visible to users?
        public string FileUrl { get; set; }
        public string ThumbUrl { get; set; }
        public string MedUrl { get; set; }
    }
}