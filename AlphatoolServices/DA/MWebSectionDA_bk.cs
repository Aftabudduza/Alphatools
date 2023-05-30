using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MWebSectionDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MWebSectionDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MWebSectionDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MWebSection GetMWebSectionbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MWebSection
                where b.WebSectionID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MWebSection objUser)
        {
            _obAlphaToolEntities.MWebSection.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MWebSection obj)
        {
            MWebSection existing = _obAlphaToolEntities.MWebSection.Find(obj.WebSectionID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MWebSection.Remove(GetMWebSectionbyId(id));
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public MWebSection GetMWebSectionbyCategoryId(int categoryId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.MWebSection
        //                   where b.CategoryID == categoryId
        //                   select b;

        //    var objUser = empQuery.ToList().FirstOrDefault();

        //    return objUser;
        //}

        //public User GetUserBySql(string sql)
        //{
        //    var empQuery = _obAlphaToolEntities.User.SqlQuery(sql).ToList().FirstOrDefault();
        //    var objUser = empQuery;
        //    return objUser;
        //}

        public List<MWebSection> GetAllMWebSection()
        {
            var empQuery = from b in _obAlphaToolEntities.MWebSection
                //where b.WebSectionID > 0
                select b;

            var listMWebSection = empQuery.ToList();
            return listMWebSection;
        }
        public List<MWebSection> GetAllMWebSectionById(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MWebSection
                           where b.WebSectionID == id
                           select b;

            var listMWebSection = empQuery.ToList();
            return listMWebSection;
        }

        public List<MWebSection> GetAllMWebSectionBySQL(string sql)
        {
            List<MWebSection> productinfolist = null;

            if (sql != "")
            {
                var empQuery = _obAlphaToolEntities.MWebSection.SqlQuery(sql).ToList<MWebSection>();
                productinfolist = empQuery;
            }
            return productinfolist;

        }

        public MWebSection GetMWebSectionbyBySQL(string sql)
        {
            //var empQuery = from b in _obAlphaToolEntities.MWebSection
            //               where b.WebSectionID == id
            //               select b;
            var empQuery = _obAlphaToolEntities.MWebSection.SqlQuery(sql).ToList().FirstOrDefault();
            //var objUser = empQuery.ToList().FirstOrDefault();

            return empQuery;
        }
    }
}
