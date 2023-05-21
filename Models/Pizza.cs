using System;
using System.Collections.Generic;

namespace PizzaTime.Models;

public partial class Pizza : BaseModel
{

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<OrdersPizza> OrdersPizzas { get; set; } = new List<OrdersPizza>();
}
