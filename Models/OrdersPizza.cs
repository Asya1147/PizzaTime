using System;
using System.Collections.Generic;

namespace PizzaTime.Models;

public partial class OrdersPizza:BaseModel
{

    public int? Orderid { get; set; }

    public int? Pizzaid { get; set; }

    public int Count { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Pizza? Pizza { get; set; }
}
