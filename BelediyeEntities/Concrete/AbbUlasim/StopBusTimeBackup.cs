namespace BelediyeEntities.Concrete.AbbUlasim;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BelediyeCore.Entities;

public class StopBusTimeBackup :IEntity
{
    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }
    
    public int? TimeBackupId { get; set; }
    public int StopId { get; set; }
    public int BusId { get; set; }
    
    public TimeSpan PassTime { get; set; }
    public int DayType { get; set; }
    public DateTime ChangeDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime InsertDate { get; set; }

    // Navigation Properties
    [ForeignKey("BusId")]
    public virtual Bus Bus { get; set; }

    [ForeignKey("StopId")]
    public virtual Stop Stop { get; set; }

    [ForeignKey("TimeBackupId")]
    public virtual TimeBackUp TimeBackup { get; set; }
}
