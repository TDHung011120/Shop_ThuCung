using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using PagedList;
using Shop_ThuCung.Models;

namespace Shop_ThuCung.Models
{
    
    public class UserDAO
    {
        DBShopOnline db= new DBShopOnline();
        public long Insert(User Entyti)
        {
            db.Users.Add(Entyti);
            db.SaveChanges();
            return Entyti.ID;
        }
        public long Edit(User entyti)
        {
            var u = db.Users.Find(entyti.ID);
            u.Name=entyti.Name;
            u.Address=entyti.Address;
            u.Phone=entyti.Phone;
            u.Status=entyti.Status;
            u.Email=entyti.Email;
            u.CreateBy=entyti.CreateBy;
            u.CreateDate=entyti.CreateDate;
            u.ModifiedBy=entyti.ModifiedBy;
            u.ModifiedDate=entyti.ModifiedDate;
            db.SaveChanges();
            return u.ID;
        }
        public User GetByUserName(string UserName)
        {
            return db.Users.SingleOrDefault(x=>x.UserName==UserName);
        }
        //public IEnumerable<User> SearchUser(string keyWord="")
        //{
        //    var userName = db.Users.Select(x => x.UserName.Contains(keyWord.ToLower())).ToList();
        //    var name= db.Users.Select(x => x.Name.Contains(keyWord.ToLower())).ToList();
        //    var address= db.Users.Select(x => x.Address.Contains(keyWord.ToLower())).ToList();
        //    var email= db.Users.Select(x => x.Email.Contains(keyWord.ToLower())).ToList();
        //    var phone= db.Users.Select(x => x.Phone.Contains(keyWord.ToLower())).ToList();
        //    var 
        //    users = userName.ToList();
        //    foreach(var u in name)
        //    {
        //        var kt=users.Select(x=>x.Equals(u)).ToList();
        //        if (kt == null)
        //            users.Add(u);
        //    }
        //    foreach (var u in address)
        //    {
        //        var kt = users.Select(x => x.Equals(u)).ToList();
        //        if (kt == null)
        //            users.Add(u);
        //    }
        //    foreach (var u in email)
        //    {
        //        var kt = users.Select(x => x.Equals(u)).ToList();
        //        if (kt == null)
        //            users.Add(u);
        //    }
        //    foreach (var u in phone)
        //    {
        //        var kt = users.Select(x => x.Equals(u)).ToList();
        //        if (kt == null)
        //            users.Add(u);
        //    }
        //    users=(IEnumerable)users;
        //    return users;
        //}
        public User GetByID(int ID)
        {
            return db.Users.Find(ID);
        }
        public IEnumerable<User> GetListUser(string keyWord,int page,int pageSize)
        {
            IOrderedQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(keyWord))
            {
                model = (IOrderedQueryable<User>)model.Where(x => x.UserName.Contains(keyWord) || x.Name.Contains(keyWord)|| x.Address.Contains(keyWord)||x.Email.Contains(keyWord)||x.Phone.Contains(keyWord));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page,pageSize);
        }
        public int Login(string userName,string passWord)
        {
            var result=db.Users.FirstOrDefault(x=>x.UserName==userName);
            if (result==null)
            {
                return 0;
            }
            else
            {
                if(result.Status==false)
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
        public bool Delete(int ID)
        {
            var u = db.Users.SingleOrDefault(x=>x.ID==ID);
            
            if (u != null)
            {
                db.Users.Remove(u);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChangeStatus(int id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
    }
}