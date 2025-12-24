
namespace Kursova.Tests
{
    [TestClass]
    public class SessionServiceTests
    {
        private string connStr;

        [TestInitialize]
        public void Setup()
        {
            connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
        }

        [TestMethod]
        public void Session_ShouldNotOverlapInSameHall()
        {
            var service = new SessionService(connStr);

            DateTime start1 = DateTime.Now.AddHours(1);
            DateTime start2 = start1.AddMinutes(30);

            service.AddSession(1, 1, start1, 100);

            bool canAdd = service.CanAddSession(
                hallId: 1,
                startTime: start2,
                durationMinutes: 120
            );

            Assert.IsFalse(canAdd);
        }
    }
}
