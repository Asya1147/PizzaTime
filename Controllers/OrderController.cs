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
    public class OrderController : ControllerBase
    {
       
        WebAppPizzatimeContext db = new WebAppPizzatimeContext();
        List<Order> orderList = new List<Order>();
       


    
        [HttpGet]
        public IResult Get()
        {

            orderList = db.Orders.ToList();
            return Results.Json(orderList);
        }


        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            int index = 0;
            orderList = db.Orders.ToList();
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Id == id) { index = i; }
            }
            return Results.Json(orderList[index]);
        }

        
        
        [HttpPut("{id}")]
        public void Put(int id,string new_customer)
        {
            orderList = db.Orders.ToList();
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Id == id)
                {
                    orderList[i].Customer = new_customer;
                    db.SaveChanges();
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Orders.Where(u => u.Id == id).ExecuteDelete();
            db.SaveChanges();
             
        }
    }
}
