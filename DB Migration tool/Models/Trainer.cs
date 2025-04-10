using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB_Migration_tool.Models;

[Table("trainers")]
[Index("IdTrainer", Name = "id")]
public partial class Trainer
{
    [Key]
    [Column("id_trainer", TypeName = "int(11)")]
    public int IdTrainer { get; set; }

    [Column("name")]
    [StringLength(32)]
    public string? Name { get; set; }

    [Column("telephone")]
    [StringLength(16)]
    public string Telephone { get; set; } = null!;

    [Column("trainer_info")]
    [StringLength(255)]
    public string TrainerInfo { get; set; } = null!;

    [Column("photo_url")]
    [StringLength(255)]
    public string PhotoUrl { get; set; } = null!;

    [InverseProperty("IdTrainersNavigation")]
    public virtual ICollection<TrainersClub> TrainersClubs { get; set; } = new List<TrainersClub>();
}
