namespace BelediyeEntities.Concrete.AbbUlasim;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BelediyeCore.Entities;

public class TimeBackUp :IEntity
{
    public TimeBackUp()
    {
        this.StopBusTimeBackups = new HashSet<StopBusTimeBackup>();
        this.TimeBackupBus = new HashSet<TimeBackUpBus>();
    }

    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }
    
    public string Description { get; set; }

    public DateTime ChangeDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime InsertDate { get; set; }

    // Navigation Properties
    public virtual ICollection<StopBusTimeBackup> StopBusTimeBackups { get; set; }
    public virtual ICollection<TimeBackUpBus> TimeBackupBus { get; set; }
}
