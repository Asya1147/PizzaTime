using System;
using System.Collections.Generic;

namespace PizzaTime.Models;

public partial class Order: BaseModel
{

    public int Number { get; set; }

    public string Customer { get; set; } = null!;

    public float Summa { get; set; }

    public virtual ICollection<OrdersPizza> OrdersPizzas { get; set; } = new List<OrdersPizza>();
}
