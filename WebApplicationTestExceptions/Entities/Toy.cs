using System;
using System.Collections.Generic;

namespace WebApplicationTestExceptions.Entities;

public partial class Toy
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public string AgeLimit { get; set; }
}
