using System;
using System.Collections.Generic;

namespace Entities.DBModels;

public partial class VaccinationsDate
{
    public int Id { get; set; }

    public int VaccineId { get; set; }

    public DateTime Date { get; set; }

    public int MemberId { get; set; }

    public short VaccinationNumber { get; set; }
}
