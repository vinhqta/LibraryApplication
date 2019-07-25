using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Models
{
    public class Users
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsRenewed { get; set; }

        public DateTime DateJoined { get; set; }
    }
}
