using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BelediyeCore.Entities;


namespace BelediyeEntities.Concrete.AbbUlasim;



public class TimeBackUpBus :IEntity
{
    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }
    
    public int? TimeBackupId { get; set; }
    public int BusId { get; set; }
    
    public DateTime ChangeDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime InsertDate { get; set; }

    public bool Secim { get; set; }

    // Navigation Properties
    [ForeignKey("BusId")]
    public virtual Bus Bus { get; set; }

    [ForeignKey("TimeBackupId")]
    public virtual TimeBackUp TimeBackup { get; set; }
}

