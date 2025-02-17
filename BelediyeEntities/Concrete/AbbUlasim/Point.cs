
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BelediyeCore.Entities;
namespace BelediyeEntities.Concrete.AbbUlasim;

public class Point :IEntity
{
    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }
    public int? BusId { get; set; }
    public double? Lat { get; set; }
    public double? Lon { get; set; }
    public int? SeqNo { get; set; }
    public DateTime? ChangeDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime InsertDate { get; set; }

    // Foreign Key Relationship
    [ForeignKey("BusId")]
    public virtual Bus Bus { get; set; }
}
