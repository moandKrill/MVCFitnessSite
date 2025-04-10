using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB_Migration_tool.Models;

[Table("client")]
[Index("IdClient", Name = "id")]
public partial class Client
{
    [Key]
    [Column("id_client", TypeName = "int(11)")]
    public int IdClient { get; set; }

    [Column("name")]
    [StringLength(30)]
    public string? Name { get; set; }

    [Column("city")]
    [StringLength(30)]
    public string? City { get; set; }

    [Column("gender")]
    [StringLength(20)]
    public string? Gender { get; set; }

    [Column("phoneNumber")]
    [StringLength(16)]
    public string? PhoneNumber { get; set; }

    [InverseProperty("IdClientNavigation")]
    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
