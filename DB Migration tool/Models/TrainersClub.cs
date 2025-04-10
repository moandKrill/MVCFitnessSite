using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB_Migration_tool.Models;

[Table("trainers_club")]
[Index("IdCategoryTrainer", Name = "id_category_trainer")]
[Index("IdTrainers", Name = "id_trainers")]
[Index("IdTrainingType", Name = "id_training_type")]
public partial class TrainersClub
{
    [Key]
    [Column("id_trainers_club", TypeName = "int(11)")]
    public int IdTrainersClub { get; set; }

    [Column("id_trainers", TypeName = "int(11)")]
    public int IdTrainers { get; set; }

    [Column("id_training_type", TypeName = "int(11)")]
    public int IdTrainingType { get; set; }

    [Column("id_category_trainer", TypeName = "int(11)")]
    public int IdCategoryTrainer { get; set; }

    [Column("price_hour", TypeName = "int(11)")]
    public int PriceHour { get; set; }

    [ForeignKey("IdCategoryTrainer")]
    [InverseProperty("TrainersClubs")]
    public virtual CategoryTrainer IdCategoryTrainerNavigation { get; set; } = null!;

    [ForeignKey("IdTrainers")]
    [InverseProperty("TrainersClubs")]
    public virtual Trainer IdTrainersNavigation { get; set; } = null!;

    [ForeignKey("IdTrainingType")]
    [InverseProperty("TrainersClubs")]
    public virtual TrainingType IdTrainingTypeNavigation { get; set; } = null!;

    [InverseProperty("IdTrainersClubNavigation")]
    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
