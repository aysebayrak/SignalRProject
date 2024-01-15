using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
            

        }

		public void ChangeStatusToFalse(int id)
		{
		   using  var context  = new SignalRContext();
			var value = context.Discounts.Find(id);
			value.DiscountStatus = false;
			context.SaveChanges();
		}

		public void ChangeStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.Discounts.Find(id);
			value.DiscountStatus = true;
			context.SaveChanges();
		}

		public List<Discount> GetListByStatusTrue()
		{
			using var context = new SignalRContext();
			var values = context.Discounts.Where(x=>x.DiscountStatus==true).ToList();
			return values;
		}
	}
}
