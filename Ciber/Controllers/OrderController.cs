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
        public OrderController()
        {
            _orderRepository = new OrderRepository(new CiberDbContext());
            _customerRepository = new CustomerRepository(new CiberDbContext());
            _productRepository = new ProductRepository(new CiberDbContext());
            _productCategoryRepository = new ProductCategoryRepository(new CiberDbContext());
        }

        public ActionResult Index([FromQuery] int ProductCategory_ID)
        {
            var orders = from order in _orderRepository.GetAllOrders(ProductCategory_ID)
                         select order;
            var productcategories = from pc in _productCategoryRepository.GetProductCategories()
                                    select pc;

            var orderViewModel = new OrderViewModel();
            orderViewModel.OrderList = orders.ToList();
            orderViewModel.CategoryProductList = productcategories.ToList();

            return View(orderViewModel);
        }
        public IActionResult GetProductCategory()
        {
            ViewData.Model = from order in _productCategoryRepository.GetProductCategories()
                             select order;
            return View();
        }


        [HttpPost]
        public ActionResult CreateNewOrder(OrderDTO order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Order d = new Order();
                    d.OrderName = order.OrderName;
                    d.CustomerId = order.Customer_ID;
                    d.ProductId = order.Product_ID;
                    d.CreateDate = DateTime.Now;
                    d.Status = 1;
                    d.OrderDate = DateTime.Parse(order.CreateDate);
                    d.Amount = order.Amount;
                    if (_orderRepository.CountOrder() < order.Amount)
                    {
                        TempData["Msg"] ="Can't order because product quantity < " + order.Amount + ".<br> Only "+ _orderRepository.ProductLeft((int)order.Product_ID) + " products left.";
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
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(order);
        }

        public ActionResult Create()
        {
            var products = from p in _productRepository.GetProducts()
                           select p;
            var customers = from c in _customerRepository.GetCustomers()
                            select c;

            var createOrderViewModel = new CreateOrderViewModel();
            createOrderViewModel.ProductList = products.ToList();
            createOrderViewModel.CustomerList = customers.ToList();
            createOrderViewModel.Order = new OrderDTO();
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
