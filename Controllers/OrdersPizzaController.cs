using MessagePack;
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
    public class OrdersPizzaController : ControllerBase
    {
        

        WebAppPizzatimeContext db = new WebAppPizzatimeContext();
        List<OrdersPizza> opList = new List<OrdersPizza>();
       

        

       
        [HttpGet]
        public IResult Get()
        {
            opList = db.OrdersPizzas.ToList();
            return Results.Json(opList);
        }


        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            int index = 0;
            opList = db.OrdersPizzas.ToList();
            for (int i = 0; i < opList.Count; i++)
            {
                if (opList[i].Id == id) { index = i; }
            }
            return Results.Json(opList[index]);
        }

        [HttpPost]
        public void Post(int id_pizza, string customer,int number_order, int count_pizza)
        { Order o;
            List<Pizza> pl = db.Pizzas.ToList();
            for (int i = 0; i < pl.Count; i++) { if (id_pizza == pl[i].Id) 
            { o = new Order { Customer = customer, Number=number_order, Summa = Convert.ToSingle(count_pizza * pl[i].Price) };
              db.Orders.Add(o);
              db.SaveChanges();
                } }
            List<Order> ol= db.Orders.ToList();
            OrdersPizza op = new OrdersPizza { Orderid = ol[ol.Count-1].Id,Pizzaid=id_pizza, Count=count_pizza};
            db.OrdersPizzas.Add(op);
            db.SaveChanges();

        }

        //// PUT api/<OrdersPizzaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.OrdersPizzas.Where(u => u.Id == id).ExecuteDelete();
            db.SaveChanges();
        }
    }
}
