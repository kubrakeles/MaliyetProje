namespace BelediyeEntities.Concrete.AbbUlasim;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BelediyeCore.Entities;

public class Bus :IEntity
{
    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }
    public int? DisplayRouteCode { get; set; }
    
    [Required]
    [MaxLength(50)] // Uzunluk sınırlaması eklenebilir
    public string RouteCode { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    public int? FirstStopId { get; set; }
    public int? LastStopId { get; set; }
    public bool? Direction { get; set; }
    public DateTime? ChangeDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    public bool Active { get; set; }
    public DateTime InsertDate { get; set; }
    public int VehicleType { get; set; }
    public DateTime? DescriptionUpdateDate { get; set; }

    // Foreign Keys
    [ForeignKey("FirstStopId")]
    public virtual Stop FirstStop { get; set; }

    [ForeignKey("LastStopId")]
    public virtual Stop LastStop { get; set; }

    // Navigation Properties (One-to-Many ve Many-to-Many ilişkiler)
    public virtual ICollection<AttentionBus> AttentionBus { get; set; } = new HashSet<AttentionBus>();
    public virtual ICollection<BusStop> BusStops { get; set; } = new HashSet<BusStop>();
    public virtual ICollection<Point> Points { get; set; } = new HashSet<Point>();
    public virtual ICollection<StopBusTime> StopBusTimes { get; set; } = new HashSet<StopBusTime>();
    public virtual ICollection<StopBusTimeBackup> StopBusTimeBackups { get; set; } = new HashSet<StopBusTimeBackup>();
    public virtual ICollection<TimeBackUpBus> TimeBackupBus { get; set; } = new HashSet<TimeBackUpBus>();
}