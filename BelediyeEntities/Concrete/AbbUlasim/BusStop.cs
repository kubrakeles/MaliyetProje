namespace BelediyeEntities.Concrete.AbbUlasim;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BelediyeCore.Entities;

public class BusStop :IEntity
{
    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }
    public int? BusId { get; set; }
    public int? StopId { get; set; }
    public int? SeqNo { get; set; }
    public DateTime? ChangeDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime InsertDate { get; set; }

    // Foreign Key Relationships
    [ForeignKey("BusId")]
    public virtual Bus Bus { get; set; }

    [ForeignKey("StopId")]
    public virtual Stop Stop { get; set; }
}
