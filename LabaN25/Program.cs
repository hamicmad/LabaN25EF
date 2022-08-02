using LabaN25;

Console.WriteLine("1.Create\t2.Read\t3.Update\t4.Delete");


while (true)
{
    switch (Console.ReadLine())
    {
        case "1":
            EntityManager.CreateOrder();
            break;
        case "2":
            EntityManager.ReadOrders();
            break;
        case "3":
            Console.WriteLine("Enter the order Id");
            var idToUpdate = int.Parse(Console.ReadLine());
            EntityManager.UpdateOrder(idToUpdate);
            break;
        case "4":
            Console.WriteLine("Enter the order Id");
            var idToDelete = int.Parse(Console.ReadLine());
            EntityManager.DeleteOrder(idToDelete);
            break;
        default:
            return;
    }
}