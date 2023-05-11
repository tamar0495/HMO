using System;
using System.Collections.Generic;

namespace Entities.DBModels;

public partial class Vaccination
{
    public int Id { get; set; }

    public string Manufaktorer { get; set; } = null!;
}
