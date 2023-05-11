using System;
using System.Collections.Generic;

namespace Entities.DBModels;

public partial class Member
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string IdNumber { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int BuildingNumber { get; set; }

    public DateTime Birthdate { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string CellPhoneNumber { get; set; } = null!;

    public DateTime PositiveResultDate { get; set; }

    public DateTime? RecoveryDate { get; set; }
}
