using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MOtherReferenceDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MOtherReferenceDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MOtherReferenceDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MOtherReference GetMOtherReferencebyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherReference
                           where b.OtherReferenceID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MOtherReference objUser)
        {
            _obAlphaToolEntities.MOtherReference.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MOtherReference obj)
        {
            MOtherReference existing = _obAlphaToolEntities.MOtherReference.Find(obj.OtherReferenceID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MOtherReference.Remove(GetMOtherReferencebyId(id));
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public MWebGroup GetMWebGroupbyCategoryId(int categoryId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.MWebGroup
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

        public List<MOtherReference> GetAllMOtherReference()
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherReference
                           where b.OtherReferenceID > 0
                select b;

            var listMOtherReference = empQuery.ToList();
            return listMOtherReference;
        }

        public List<MOtherReference> GetAllMOtherReferenceById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherReference
                           where b.OtherReferenceID == groupId
                           select b;

            var listMOtherReference = empQuery.ToList();
            return listMOtherReference;
        }
    }
}
