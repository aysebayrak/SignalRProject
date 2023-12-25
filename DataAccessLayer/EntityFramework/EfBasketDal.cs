using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {

        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBAsketByMenuTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values  = context.Baskets.Where(x=>x.MenuTableId == id).ToList();   
            return values;
        }
    }
}
