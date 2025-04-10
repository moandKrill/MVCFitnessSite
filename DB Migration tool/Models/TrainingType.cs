using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB_Migration_tool.Models;

[Table("training_type")]
[Index("IdTrainingType", Name = "id_training_type")]
public partial class TrainingType
{
    [Key]
    [Column("id_training_type", TypeName = "int(11)")]
    public int IdTrainingType { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("IdTrainingTypeNavigation")]
    public virtual ICollection<TrainersClub> TrainersClubs { get; set; } = new List<TrainersClub>();
}
