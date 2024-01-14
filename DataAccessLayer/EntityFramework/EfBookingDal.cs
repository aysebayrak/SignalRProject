using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;


namespace DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var contex = new SignalRContext();
		    var values = 	contex.Bookings.Find(id);
			values.Description = "Rezervasyon Onaylandı";
			contex.SaveChanges();

		}

		public void BookingStatusCancelled(int id)
		{
			using var contex = new SignalRContext();
			var values = contex.Bookings.Find(id);
			values.Description = "Rezervasyon iptal edildi ";
			contex.SaveChanges();
		}
	}
}
