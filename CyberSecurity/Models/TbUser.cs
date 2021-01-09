using System;
using System.Collections.Generic;

namespace CyberSecurity.Models
{
    public partial class TbUser
    {
        public TbUser()
        {
            TbUserRole = new HashSet<TbUserRole>();
        }

        public long UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }

        public virtual ICollection<TbUserRole> TbUserRole { get; set; }
    }
}
