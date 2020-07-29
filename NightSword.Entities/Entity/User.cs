using NightSword.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Entities.Entity
{
    public class User : KernelEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
