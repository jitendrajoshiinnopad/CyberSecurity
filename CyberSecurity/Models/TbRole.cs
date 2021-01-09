using System;
using System.Collections.Generic;

namespace CyberSecurity.Models
{
    public partial class TbRole
    {
        public TbRole()
        {
            TbUserRole = new HashSet<TbUserRole>();
        }

        public long RoleId { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<TbUserRole> TbUserRole { get; set; }
    }
}
