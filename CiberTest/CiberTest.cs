using Ciber.Models;
using Ciber.Models.Repository.Orders;

namespace CiberTest
{
    public class CiberTest
    {
        private IOrderRepository _orderRepository;
        public CiberTest()
        {
            _orderRepository = new OrderRepository(new CiberDbContext());
        }

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void GetAll()
        {
            var result = _orderRepository.GetAllOrders(0);
            Assert.AreEqual(27, result.Count);
        }

        [Test]
        public void GetAllByCateID()
        {
            var result = _orderRepository.GetAllOrders(1);
            Assert.AreEqual(18, result.Count);
        }
    }
}