namespace BelediyeEntities.Concrete.AbbUlasim;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BelediyeCore.Entities;

public class Stop :IEntity
{
    public Stop()
    {
        this.Buses = new HashSet<Bus>();
        this.Buses1 = new HashSet<Bus>();
        this.BusStops = new HashSet<BusStop>();
        this.StopBusTimes = new HashSet<StopBusTime>();
        this.StopBusTimeBackups = new HashSet<StopBusTimeBackup>();
    }

    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    public double? Lat { get; set; }
    public double? Lon { get; set; }

    public string Description { get; set; }

    public DateTime? ChangeDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime InsertDate { get; set; }

    // Navigation Properties
    public virtual ICollection<Bus> Buses { get; set; }
    public virtual ICollection<Bus> Buses1 { get; set; }
    public virtual ICollection<BusStop> BusStops { get; set; }
    public virtual ICollection<StopBusTime> StopBusTimes { get; set; }
    public virtual ICollection<StopBusTimeBackup> StopBusTimeBackups { get; set; }
}
