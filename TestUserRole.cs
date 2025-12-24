namespace Kursova.Tests;

[TestClass]
public class TestUserRole
{
    private string connStr;

    [TestInitialize]
    public void Setup()
    {
        connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
    }

    [TestMethod]
    public void Viewer_CannotReserveSeat()
    {
        var auth = new AuthService(connStr);

        string role = auth.Login("guest", "123");

        Assert.AreEqual("viewer", role);
    }
}
