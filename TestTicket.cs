namespace Kursova.Tests;

[TestClass]
public class TestTicket
{
    private string connStr;

    [TestInitialize]
    public void Setup()
    {
        connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
    }

    [TestMethod]
    public void CannotReserveMoreThan20Seats()
    {
        var service = new TicketService(connStr);

        for (int i = 1; i <= 20; i++)
            service.ReserveSeat(1, i, "Тестовий користувач");

        bool result = service.ReserveSeat(1, 21, "Тестовий користувач");

        Assert.IsFalse(result);
    }
}
