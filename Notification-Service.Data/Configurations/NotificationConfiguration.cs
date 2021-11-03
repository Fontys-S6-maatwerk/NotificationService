
using Notification_Service.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Notification_Service.Data.Configurations
{
   
    public class NotificationConfiguration : BaseEntityConfiguration<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);

            // base values
            var time = DateTime.Parse("02/11/2021 11:37:00");

            builder.Property(s => s.Title).IsRequired();
            builder.Property(s => s.Description);
            builder.Property(s => s.Link).IsRequired();

            builder.HasData(new Notification
            {
                Id = Guid.Parse("9c3b5697-e4ba-4c4a-b4c9-0dacd3b634e3"),
                LastUpdatedAt = time,
                Title = "new follower",
                Description = "harry bouwers is now a follower",
                Link = "website.com/user/robin",
                CreatedAt = time,


            });



        }
    }
}