using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaTime.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace PizzaTime.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
      

        WebAppPizzatimeContext db = new WebAppPizzatimeContext();
        List<Pizza> pizzaList = new List<Pizza>();

        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }
        

        
        [HttpGet]
        public IResult Get()
        {

            pizzaList = db.Pizzas.ToList();
            return Results.Json(pizzaList);
        }


        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            int index = 0;
            pizzaList = db.Pizzas.ToList();
            for (int i = 0; i < pizzaList.Count; i++)
            {
                if (pizzaList[i].Id == id) { index = 0; }
            }
            return Results.Json(pizzaList[index]);
        }

        
        [HttpPost]
        public void Post(string name, double price)
        {
            Pizza p = new Pizza { Name=name, Price=price };
            db.Pizzas.Add(p);
            db.SaveChanges();

        }

        
        [HttpPut("{id}")]
        public void Put(int id, string new_name, double new_price)
        {
            pizzaList = db.Pizzas.ToList();
            for (int i = 0; i < pizzaList.Count; i++)
            {
                if (pizzaList[i].Id == id)
                {
                    pizzaList[i].Name = new_name;
                    pizzaList[i].Price = new_price;
                    db.SaveChanges();
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Pizzas.Where(u => u.Id == id).ExecuteDelete();
            db.SaveChanges();

        }
    }
}
