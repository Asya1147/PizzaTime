using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaTime.Models;

namespace PizzaTime.Controllers
{
    public class Statistika {
        public string Name { get; set; }

        public double Count { get; set; }
    }

    [Route("[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        WebAppPizzatimeContext db = new WebAppPizzatimeContext();
        List<OrdersPizza> opList = new List<OrdersPizza>();
        List<Pizza> plist = new List<Pizza>();
        List<Statistika> statlist = new List<Statistika>();
        string jsonstring = "";

        [HttpGet]
        public IResult Get()
        {
            opList = db.OrdersPizzas.ToList();
            plist = db.Pizzas.ToList();
            statlist.Clear();
            for (int j = 0; j < plist.Count; j++) {
                statlist.Add(new Statistika { Name = plist[j].Name, Count= 0});
                for (int i = 0; i < opList.Count; i++)
            {
                if (opList[i].Pizzaid == plist[j].Id) { statlist[j].Count+=opList[i].Count; }
                
            }
                
            }
           return Results.Json(statlist);
        }

        [HttpGet("{id}")]
        public IResult Get(int pizza_id)
        {
            
            opList = db.OrdersPizzas.ToList();
            plist = db.Pizzas.ToList();
            Statistika st=new Statistika {Name="", Count=0 };
            for (int i = 0; i < opList.Count; i++)
            {
              if (opList[i].Pizzaid == pizza_id) { st.Count+= opList[i].Count; }}
            
            for (int i = 0; i < plist.Count; i++)
            {
                if (plist[i].Id == pizza_id)
                { st.Name = plist[i].Name; }
            }

            return Results.Json(st);
        }
    }
}
