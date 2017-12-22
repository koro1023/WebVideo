using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebVideo.Models
{
    public class Photos
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
       
        public string Link { get; set; }
        
    }
}