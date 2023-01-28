using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("get-post")]
        public ActionResult Aggregate()
        {
            var userLondon = _context.Users.Where(p => p.Address.City == "London").ToList();

            //In OwnsMany, you cant directly query in db, you should get all data to memory, then filter your datas
            var userPhone = _context.Users.AsEnumerable().Where(p => p.Orders.Any(p => p.ProductName == "Phone")).ToList();

            var newUser = new User
            {
                Name = "John",
                Surname = "Doe",
                Email = "johndoe@mail.com",
                Address = new Address { City = "New York", Country = "USA", Postcode = "544", Street = "C Avenue" },
                Orders = new List<Order>
                {
                    new Order { ProductName = "Parfume", ProductAmount = 1, TotalPrice = 500.20M, OrderDate = DateTime.Now.AddDays(-10)},
                    new Order { ProductName = "Trousers", ProductAmount = 2, TotalPrice = 20.50M, OrderDate = DateTime.Now.AddDays(-50)}
                }
            };

            var newUser2 = new User
            {
                Name = "Bruce",
                Surname = "Bruce Wayne",
                Email = "brucewayne@mail.com",
                Address = new Address { City = "London", Country = "England", Postcode = "544", Street = "B Avenue" },
                Orders = new List<Order>
                {
                    new Order { ProductName = "Phone", ProductAmount = 2, TotalPrice = 500.20M, OrderDate = DateTime.Now.AddDays(-105)},
                    new Order { ProductName = "Pencil", ProductAmount = 4, TotalPrice = 20.50M, OrderDate = DateTime.Now.AddDays(-550)}
                }
            };

            _context.Users.Add(newUser);
            _context.Users.Add(newUser2);
            _context.SaveChanges();

            return Ok();
        }
    }
}
