using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB_Migration_tool.Models;

[Table("training_level")]
[Index("IdLevel", Name = "id")]
public partial class TrainingLevel
{
    [Key]
    [Column("id_level", TypeName = "int(11)")]
    public int IdLevel { get; set; }

    [Column("level", TypeName = "text")]
    public string Level { get; set; } = null!;

    [InverseProperty("IdLevelNavigation")]
    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
