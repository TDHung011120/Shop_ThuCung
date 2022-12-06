using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_ThuCung.Models.DAO
{
    public class ContentDAO
    {
        DBShopOnline db = new DBShopOnline();
        public long Insert(Content Entyti)
        {
            db.Contents.Add(Entyti);
            db.SaveChanges();
            return Entyti.ID;
        }
        public long Edit(Content entyti)    
        {
            var u = db.Contents.Find(entyti.ID);
            u.Name = entyti.Name;
            u.Metatitle = entyti.Metatitle;
            u.Description = entyti.Description;
            u.MetaDescriptions = entyti.MetaDescriptions;
            u.Metekeywords = entyti.Metekeywords;
            u.Detail= entyti.Detail;
            u.Image= entyti.Image;
            u.CategotyID = entyti.CategotyID;
            u.Warranty=entyti.Warranty;
            u.ModifiedBy = entyti.ModifiedBy;
            u.ModifiedDate = entyti.ModifiedDate;
            u.Status = entyti.Status;
            db.SaveChanges();
            return u.ID;
        }
        public Content GetByCategoryName(string Name)
        {
            return db.Contents.SingleOrDefault(x => x.Name == Name);
        }
        public Content GetByID(int ID)
        {
            return db.Contents.Find(ID);
        }
        public IEnumerable<Content> GetListCategory(string keyWord, int page, int pageSize)
        {
            IOrderedQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(keyWord))
            {
                model = (IOrderedQueryable<Content>)model.Where(x => x.Name.Contains(keyWord) || x.Tags.Contains(keyWord) || x.MetaDescriptions.Contains(keyWord) || x.Metatitle.Contains(keyWord));
            }
            return model.OrderByDescending(x => x.TopHot).ToPagedList(page, pageSize);
        }
        public bool Delete(int ID)
        {
            var u = db.Contents.SingleOrDefault(x => x.ID == ID);

            if (u != null)
            {
                db.Contents.Remove(u);
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