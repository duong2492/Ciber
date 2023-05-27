using Ciber.Models;
using Ciber.Models.Repository.Customers;
using Ciber.Models.Repository.Orders;
using Ciber.Models.Repository.ProductCategories;
using Ciber.Models.Repository.Products;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Ciber.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private ICustomerRepository _customerRepository;
        private IProductRepository _productRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private readonly ILogger<OrderController> _logger;
        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
            _orderRepository = new OrderRepository(new CiberDbContext());
            _customerRepository = new CustomerRepository(new CiberDbContext());
            _productRepository = new ProductRepository(new CiberDbContext());
            _productCategoryRepository = new ProductCategoryRepository(new CiberDbContext());
        }

        public ActionResult Index([FromQuery] int ProductCategory_ID)
        {
            var orderViewModel = new OrderViewModel();
            try
            {
                var orders = from order in _orderRepository.GetAllOrders(ProductCategory_ID)
                             select order;
                var productcategories = from pc in _productCategoryRepository.GetProductCategories()
                                        select pc;

                orderViewModel.OrderList = orders.ToList();
                orderViewModel.CategoryProductList = productcategories.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return View(orderViewModel);
        }
        public IActionResult GetProductCategory()
        {
            try
            {
                ViewData.Model = from order in _productCategoryRepository.GetProductCategories()
                                 select order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return View();
        }


        [HttpPost]
        public ActionResult CreateNewOrder(OrderDTO order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Order d = new()
                    {
                        OrderName = order.OrderName,
                        CustomerId = order.Customer_ID,
                        ProductId = order.Product_ID,
                        CreateDate = DateTime.Now,
                        Status = 1,
                        OrderDate = DateTime.Parse(order.CreateDate),
                        Amount = order.Amount
                    };
                    if (_orderRepository.CountOrder() < order.Amount)
                    {
                        TempData["Msg"] = "Can't order because product quantity < " + order.Amount + ".<br> Only " + _orderRepository.ProductLeft((int)order.Product_ID) + " products left.";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["Msg"] = "Add new order successfull!";
                        _orderRepository.InsertOrder(d);
                        _orderRepository.Save();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return View(order);
        }

        public ActionResult Create()
        {
            var createOrderViewModel = new CreateOrderViewModel();
            try
            {
                var products = from p in _productRepository.GetProducts()
                               select p;
                var customers = from c in _customerRepository.GetCustomers()
                                select c;
                createOrderViewModel.ProductList = products.ToList();
                createOrderViewModel.CustomerList = customers.ToList();
                createOrderViewModel.Order = new OrderDTO();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return View(createOrderViewModel);
        }

        public class OrderViewModel
        {

            public List<OrderDTO> OrderList { get; set; }

            public List<ProductCategory> CategoryProductList { get; set; }
        }
        public class CreateOrderViewModel
        {
            public OrderDTO Order { get; set; }
            public List<Product> ProductList { get; set; }

            public List<Customer> CustomerList { get; set; }
        }

    }
}
