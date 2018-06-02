using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public List<string> Notifications { get; }

        public BaseEntity()
        {
            Notifications = new List<string>();
        }

        protected void AddNotification(string notification) 
            => Notifications.Add(notification);

        protected void AddNotifications(params string[] notifications) 
            => Notifications.AddRange(notifications);

        public bool IsValid() => Notifications.Count == 0;
    }
}
