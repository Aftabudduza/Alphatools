using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MppcIndustryDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MppcIndustryDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MppcIndustryDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MPPCIndustry GetMPPCIndustrybyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustry
                where b.PPCIndustry == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MPPCIndustry objUser)
        {
            _obAlphaToolEntities.MPPCIndustry.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubMPPCIndustry objUser)
        //{
        //    _obAlphaToolEntities.SubMPPCIndustry.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MPPCIndustry obj)
        {
            MPPCIndustry existing = _obAlphaToolEntities.MPPCIndustry.Find(obj.PPCIndustry);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MPPCIndustry.Remove(GetMPPCIndustrybyId(id));
            _obAlphaToolEntities.SaveChanges();
            return true;
        }
        
        //public User GetUserBySql(string sql)
        //{
        //    var empQuery = _obAlphaToolEntities.User.SqlQuery(sql).ToList().FirstOrDefault();
        //    var objUser = empQuery;
        //    return objUser;
        //}

        public List<MPPCIndustry> GetAllMPPCIndustry()
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustry
                where b.PPCIndustry > 0
                select b;

            var listMPPCIndustrys = empQuery.OrderBy(x => x.IndustrySort).ToList();
            return listMPPCIndustrys;
        }
    }
}
