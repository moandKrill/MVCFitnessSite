using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB_Migration_tool.Models;

[Table("category_trainer")]
public partial class CategoryTrainer
{
    [Key]
    [Column("id_category_trainer", TypeName = "int(11)")]
    public int IdCategoryTrainer { get; set; }

    [Column("category")]
    [StringLength(16)]
    public string Category { get; set; } = null!;

    [InverseProperty("IdCategoryTrainerNavigation")]
    public virtual ICollection<TrainersClub> TrainersClubs { get; set; } = new List<TrainersClub>();
}
