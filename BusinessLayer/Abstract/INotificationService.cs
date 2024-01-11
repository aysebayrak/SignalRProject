using BusinessLayer.Abstract;
using EntityLayer.Entities;


namespace BusinessLayer.Abstract
{
	public interface INotificationService:IGenericService<Notification>
	{
		int TNotificationCountByStatusFalse();

		 List<Notification>  TGetNotificationByFalse();

        void TNotificationStatusChangeToTrue(int id);
        void TNotificationStatusChangeToFalse(int id);

    }
}
