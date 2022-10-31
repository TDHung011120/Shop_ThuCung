using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_ThuCung.Models
{
    public class AdminDAO
    {
        DBShopOnline db= new DBShopOnline();
        public Admin GetByUserName(string adminName)
        {
            return db.Admins.SingleOrDefault(x => x.AdminName == adminName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Admins.FirstOrDefault(x => x.AdminName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                    return -1;
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }

        }
    }
}