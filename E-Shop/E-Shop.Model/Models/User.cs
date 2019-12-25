using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Model.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public override string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public bool IsBlocked { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
