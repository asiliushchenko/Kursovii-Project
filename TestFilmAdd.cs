namespace Kursova.Tests
{
    [TestClass]
    public sealed class TestFilmAdd
    {
        private FilmService service;
        private string connStr =
            "server=localhost;user=root;password=Marshmello135;database=cinema_db;";

        [TestInitialize]
        public void Setup()
        {
            service = new FilmService(connStr);
        }

        [TestMethod]
        public void AddFilm_ShouldCreateFilm()
        {
            int id = service.AddFilm(
                "Тестовий фільм",
                "Драма",
                120,
                "16+");

            Assert.IsTrue(id > 0);
            Assert.IsTrue(service.FilmExists(id));
        }
    }
}
