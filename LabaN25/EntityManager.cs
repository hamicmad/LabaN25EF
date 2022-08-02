
namespace LabaN25
{
    public class EntityManager
    {
        public static void CreateOrder()
        {
            using var db = new CHContext();
            
            Console.WriteLine("Введите номер столика и имя официанта:");
            var tableNum = int.Parse(Console.ReadLine());
            var name = Console.ReadLine();
            var order = new Order()
            {
                Date = DateTime.Now,
                TableNumber = tableNum,
                WaiterName = name
            };

            db.Orders.Add(order);
            db.SaveChanges();

            Console.WriteLine("Введите позицию меню и количество");
            var posMenu = int.Parse(Console.ReadLine());
            var amount = int.Parse(Console.ReadLine());

            var orderInfo = new OrderInfo()
            {
                OrderInfoId = db.Orders.Max(x => x.Id),
                MenuPositionId = posMenu,
                Amount = amount,
                OrderSum = db.Menus.FirstOrDefault(x => x.Id == posMenu).Price * amount
            };

            db.OrdersInfo.Add(orderInfo);
            db.SaveChanges();
            Console.WriteLine("Сохранено");
        }

        public static void ReadOrders()
        {
            using var db = new CHContext();

            var orders = db.Orders.ToList();
            var ordersinfo = db.OrdersInfo.ToList();

            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"Number: {orders[i].Id}, Data: {orders[i].Date}, Waiter's name: {orders[i].WaiterName}\n" +
                    $"Menu position: {db.Menus.FirstOrDefault(x => x.Id == ordersinfo[i].MenuPositionId).Name}, " +
                    $"Amount: {ordersinfo[i].Amount}, Order Sum: {ordersinfo[i].OrderSum}");
            }

        }

        public static void UpdateOrder(int id)
        {
            using var db = new CHContext();

            var order = db.Orders.FirstOrDefault(x => x.Id == id);
            var orderInfo = db.OrdersInfo.FirstOrDefault(x => x.OrderInfoId == order.Id);

            Console.WriteLine("Введите номер столика и имя официанта:");
            var tableNum = int.Parse(Console.ReadLine());
            var name = Console.ReadLine();
            if (order != null && orderInfo != null)
            {
                order.TableNumber = tableNum;
                order.WaiterName = name;
                //OrderInfo changes
                db.SaveChanges();
            }
        }

        public static void DeleteOrder(int id)
        {
            using var db = new CHContext();

            var order = db.Orders.FirstOrDefault(x => x.Id == id);

            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
