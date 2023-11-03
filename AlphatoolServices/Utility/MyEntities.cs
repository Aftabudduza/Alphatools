using AlphatoolServices.BO;

namespace AlphatoolServices.Utility
{
    public class MyEntity
    {
        private MyEntity()
        {
        }

        private static AlphatoolEntities _singleton;

        public static AlphatoolEntities GetEntity()
        {
            return _singleton ?? (_singleton = new AlphatoolEntities());
        }

        public static AlphatoolEntities GetFreshEntity()
        {
            _singleton = new AlphatoolEntities();
            return _singleton;
        }
    }
}
