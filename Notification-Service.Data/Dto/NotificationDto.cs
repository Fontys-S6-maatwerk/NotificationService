using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification_Service.Data.Entities
{
    public class NotificationDto : CreateNotificationDto
    {
        public Guid Id { get; set; }



        public new Notification ToEntity()
        {
            var result = base.ToEntity();
            result.Id = Id;
            return result;
        }

        public static NotificationDto FromEntity(Notification notification)
        {
            return new NotificationDto
            {
                Id = notification.Id,
                UserId = notification.UserId,
                Title = notification.Title,
                Description = notification.Description,
                Link = notification.Link,
                CreatedAt = notification.CreatedAt,
            };
        }

    }
}

