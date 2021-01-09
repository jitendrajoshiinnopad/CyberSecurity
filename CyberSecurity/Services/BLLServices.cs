using CyberSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberSecurity.Services
{
    public class BLLServices: IBLLService
    {
        private readonly DbCyberSecurityContext _objDbContext;

        public BLLServices(DbCyberSecurityContext context)
        {
            _objDbContext = context;
        }
        //public List<TbUser> GetAllUsers()
        //{
        //    return  _objDbContext.TbUser.ToList();
        //}
        //public string SaveUser()
        //{
        //    TbUser user = new TbUser();
        //    user.Firstname = "Jitendra";
        //    user.Lastname = "Joshi";
        //    user.Email = "joshi@mail.com";
        //    _objDbContext.TbUser.Add(user);
        //    _objDbContext.SaveChanges();
        //    return "";
        //}
    }
}
