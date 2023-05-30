using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class PartsWebfieldsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public PartsWebfieldsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public PartsWebfieldsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public PartsWebfields GetPartsWebfieldsbyPartNo(string PartsPageCode)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsWebfields
                           where b.PartsPageCode == PartsPageCode
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public PartsWebfields GetPartsWebfieldsbyProductId(string PartNo)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsWebfields
                           where b.PartNo == PartNo
                           select b;

            var objWebField = empQuery.ToList().FirstOrDefault();

            return objWebField;
        }

        public bool Insert(PartsWebfields objUser)
        {
            _obAlphaToolEntities.PartsWebfields.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        
        public List<PartsWebfields> GetAllPartsWebfields()
        {
            var empQuery = from b in _obAlphaToolEntities.PartsWebfields
                           //where b.PartsWebfieldsID > 0
                select b;

            var listPartsWebfields = empQuery.ToList();
            return listPartsWebfields;
        }

        public List<PartsWebfields> GetAllPartsWebfieldsByPartNo(string partno)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsWebfields
                           where b.PartNo == partno
                           select b;

            var listPartsWebfields = empQuery.ToList();
            return listPartsWebfields;
        }

        public List<PartsWebfields> GetAllPartsWebfieldsByProductId(string PartsPageCode)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsWebfields
                           where b.PartsPageCode == PartsPageCode
                           select b;

            var listPartsWebfields = empQuery.ToList();
            return listPartsWebfields;
        }
    }
}
