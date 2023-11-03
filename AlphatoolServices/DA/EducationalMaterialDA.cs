using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class EducationalMaterialsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public EducationalMaterialsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public EducationalMaterialsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public EducationalMaterial GetEducationalMaterialsbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.EducationalMaterial
                where b.ProductPageCode == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public List<EducationalMaterial> GetAllEducationalMaterials()
        {
            var empQuery = from b in _obAlphaToolEntities.EducationalMaterial
                           where b.ProductPageCode > 0
                select b;

            var listEducationalMaterials = empQuery.ToList();
            return listEducationalMaterials;
        }

        public List<EducationalMaterial> GetAllEducationalMaterialsByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.EducationalMaterial
                           where b.ProductPageCode == id
                           select b;

            var listEducationalMaterials = empQuery.ToList();
            return listEducationalMaterials;
        }

        public List<EducationalMaterial> GetAllEducationalMaterialListBySQL(string sql)
        {
            List<EducationalMaterial> EducationalMaterialList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.EducationalMaterial.SqlQuery(sql).ToList<EducationalMaterial>();
                    EducationalMaterialList = empQuery;
                }
                return EducationalMaterialList;
        }
        
    }
}
