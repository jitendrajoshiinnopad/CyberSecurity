using System;
using System.Collections.Generic;

namespace CyberSecurity.Models
{
    public partial class TbUserRole
    {
        public long UserRoleId { get; set; }
        public long? RoleId { get; set; }
        public long? UserId { get; set; }

        public virtual TbRole Role { get; set; }
        public virtual TbUser User { get; set; }
    }
}
