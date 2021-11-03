using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification_Service.Data.Entities
{
    public class CreateNotificationDto
    {

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime CreatedAt { get; set; }

        public Notification ToEntity()
        {
            return new Notification
            {
                Id = Guid.NewGuid(),
                UserId = UserId,
                Title = Title,
                Description = Description,
                Link = Link,
                CreatedAt = CreatedAt,
            };
        }

    }
}

