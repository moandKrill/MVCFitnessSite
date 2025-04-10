using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB_Migration_tool.Models;

[Table("training")]
[Index("IdClient", Name = "fk_client")]
[Index("IdLevel", Name = "id_level")]
[Index("IdTrainersClub", Name = "id_trainer")]
[Index("IdTrainingType", "IdTrainersClub", Name = "id_training_type")]
public partial class Training
{
    [Key]
    [Column("id_training", TypeName = "int(11)")]
    public int IdTraining { get; set; }

    [Column("id_client", TypeName = "int(11)")]
    public int IdClient { get; set; }

    [Column("id_training_type", TypeName = "int(11)")]
    public int IdTrainingType { get; set; }

    [Column("id_level", TypeName = "int(11)")]
    public int IdLevel { get; set; }

    [Column("id_trainers_club", TypeName = "int(11)")]
    public int IdTrainersClub { get; set; }

    [ForeignKey("IdClient")]
    [InverseProperty("Training")]
    public virtual Client IdClientNavigation { get; set; } = null!;

    [ForeignKey("IdLevel")]
    [InverseProperty("Training")]
    public virtual TrainingLevel IdLevelNavigation { get; set; } = null!;

    [ForeignKey("IdTrainersClub")]
    [InverseProperty("Training")]
    public virtual TrainersClub IdTrainersClubNavigation { get; set; } = null!;
}
