using ApiCourse.Models;

namespace ApiCourse.Services
{
    public class OrderService
    {
        static List<Order> Orders { get; }

        static OrderService()
        {
            Orders = new List<Order> { 
                new Order { Content = "Tv 4k 55'", Price = 5500.00},
                new Order { Content = "Xiaomi Redmi 9S", Price = 1845.99}
            };
        }
        
        public static List<Order> GetAll()
        {
            return Orders;
        }

        public static Order GetOrder(string uuid)
        {
           return Orders.FirstOrDefault(o => o.Uuid == uuid);
        }

        public static void Add(Order order)
        {
            Orders.Add(order);
        }

        public static void Remove(string uuid)
        {
            var order = GetOrder(uuid);

            if(order != null)
            {
                Orders.Remove(order);
            }
            else
            {
                return;
            }
        }

        public static void Update(Order order)
        {
            var index = Orders.FindIndex(i => i.Uuid == order.Uuid);
            if (index == -1)
                return;

            Orders[index] = order;
        }
    }
}
