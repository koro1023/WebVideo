using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebVideo.Models
{
    public class Users
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}