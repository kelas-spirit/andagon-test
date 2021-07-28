using NUnit.Framework;
using Services.Services;

namespace Test
{
    public class Tests
    {
        private AnimalService _animalService;

        [SetUp]
        public void Setup()
        {
            _animalService = new AnimalService();
        }

        [Test]
        public void Test1()
        {
            var items = _animalService.Get();
            Assert.IsTrue(true);
        }
    }
}