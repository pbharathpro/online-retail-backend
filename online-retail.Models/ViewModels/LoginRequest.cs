using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_retail.Models.ViewModels
{
    public class LoginRequest
    {
        public string Email { get; set; }  // Change Username to Email
        public string Password { get; set; }
    }
}
