using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MTechNoteDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MTechNoteDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MTechNoteDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MTechNote GetMTechNotebyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MTechNote
                where b.TechNoteID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MTechNote objUser)
        {
            _obAlphaToolEntities.MTechNote.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MTechNote obj)
        {
            MTechNote existing = _obAlphaToolEntities.MTechNote.Find(obj.TechNoteID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MTechNote.Remove(GetMTechNotebyId(id));
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

        public List<MTechNote> GetAllMTechNote()
        {
            var empQuery = from b in _obAlphaToolEntities.MTechNote
                           where b.TechNoteID > 0
                select b;

            var listMTechNote = empQuery.ToList();
            return listMTechNote;
        }

        public List<MTechNote> GetAllMTechNoteById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MTechNote
                           where b.TechNoteID == groupId
                           select b;

            var listMTechNote = empQuery.ToList();
            return listMTechNote;
        }
    }
}
