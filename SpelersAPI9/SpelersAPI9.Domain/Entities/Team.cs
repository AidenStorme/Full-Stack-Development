using System;
using System.Collections.Generic;

namespace SpelersAPI9.Domain.Entities;

public partial class Team
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Speler> Spelers { get; set; } = new List<Speler>();
}
