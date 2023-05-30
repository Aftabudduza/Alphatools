using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MetalProductsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MetalProductsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MetalProductsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MetalProducts GetMetalProductsbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MetalProducts
                where b.ProductPageCode == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }        

        public List<MetalProducts> GetAllMetalProducts()
        {
            var empQuery = from b in _obAlphaToolEntities.MetalProducts
                           where b.ProductPageCode > 0
                select b;

            var listMetalProducts = empQuery.ToList();
            return listMetalProducts;
        }

        public List<MetalProducts> GetAllMetalProductsByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MetalProducts
                           where b.ProductPageCode == id
                           select b;

            var listMetalProducts = empQuery.ToList();
            return listMetalProducts;
        }        

        public List<MetalProducts> GetAllMetalProductsListBySQL(string sql)
        {
            List<MetalProducts> MetalProductsList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.MetalProducts.SqlQuery(sql).ToList<MetalProducts>();
                    MetalProductsList = empQuery;
                }
                return MetalProductsList;
        }
        
    }
}
