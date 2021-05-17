using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RegLoginDemo.Tables
{
    public class RegisteredUsers
    {
        //public Guid UserId { get; set; }
        [PrimaryKey]
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }

    }
}
