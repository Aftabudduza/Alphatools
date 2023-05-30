using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class BaseDa
    {
        protected AlphatoolEntities ObAlphaToolEntities;

        public BaseDa(bool isNewNewContext = false, bool isLazyLoadingEnable = true)
        {
            ObAlphaToolEntities = (isNewNewContext == false) ? MyEntity.GetEntity() : MyEntity.GetFreshEntity();
            ObAlphaToolEntities.Configuration.LazyLoadingEnabled = isLazyLoadingEnable;
        }

        protected void Insert(object ob)
        {
            //object entity = ;
        }
    }
}
