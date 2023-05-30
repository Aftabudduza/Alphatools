using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class ProductBulletinsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public ProductBulletinsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public ProductBulletinsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        
        public List<ProductBulletins> GetAllProductBulletins()
        {
            var empQuery = from b in _obAlphaToolEntities.ProductBulletins
                           //where b.ProductPageCode > 0
                select b;

            var listProductBulletins = empQuery.ToList();
            return listProductBulletins;
        }

        

        public List<ProductBulletins> GetAllProductBulletinsListBySQL(string sql)
        {
            List<ProductBulletins> ProductBulletinsList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.ProductBulletins.SqlQuery(sql).ToList<ProductBulletins>();
                    ProductBulletinsList = empQuery;
                }
                return ProductBulletinsList;
        }
        
    }
}
