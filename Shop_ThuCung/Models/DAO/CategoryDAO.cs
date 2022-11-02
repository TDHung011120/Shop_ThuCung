using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_ThuCung.Models.DAO
{
    public class CategoryDAO
    {
        DBShopOnline db = new DBShopOnline();
        public long Insert(Category Entyti)
        {
            db.Categories.Add(Entyti);
            db.SaveChanges();
            return Entyti.ID;
        }
        public long Edit(Category entyti)
        {
            var u = db.Categories.Find(entyti.ID);
            u.Name = entyti.Name;
            u.SeoTitle = entyti.SeoTitle;
            u.metaTitle = entyti.metaTitle;
            u.MetaDescriptions = entyti.MetaDescriptions;
            u.Metekeywords = entyti.Metekeywords;
            u.ParentID = entyti.ParentID;
            u.ShowOnHome = entyti.ShowOnHome;
            u.CreateBy = entyti.CreateBy;
            u.CreateDate = entyti.CreateDate;
            u.ModifiedBy = entyti.ModifiedBy;
            u.ModifiedDate = entyti.ModifiedDate;
            u.Status = entyti.Status;
            db.SaveChanges();
            return u.ID;
        }
        public Category GetByCategoryName(string Name)
        {
            return db.Categories.SingleOrDefault(x => x.Name == Name);
        }
        public Category GetByID(int ID)
        {
            return db.Categories.Find(ID);
        }
        public IEnumerable<Category> GetListCategory(string keyWord, int page, int pageSize)
        {
            IOrderedQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keyWord))
            {
                model = (IOrderedQueryable<Category>)model.Where(x => x.Name.Contains(keyWord) ||  x.SeoTitle.Contains(keyWord) || x.MetaDescriptions.Contains(keyWord) || x.metaTitle.Contains(keyWord));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public bool Delete(int ID)
        {
            var u = db.Categories.SingleOrDefault(x => x.ID == ID);

            if (u != null)
            {
                db.Categories.Remove(u);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}