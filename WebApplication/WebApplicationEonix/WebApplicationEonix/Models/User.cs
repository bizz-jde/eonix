using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationEonix.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
