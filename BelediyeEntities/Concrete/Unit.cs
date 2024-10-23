using BelediyeCore.Entities;

namespace BelediyeEntities.Concrete;

public class Unit:IEntity
{
    public int id { get; set; }
    public string UnitName { get; set; }
    public ICollection<Tender> Tenders { get; set; }
    public DateTime? CreatedDate { get ; set; }
    public DateTime? UpdateDate { get; set; }
    public string? CreatedEmail { get; set; }
    public string ?UpdatedEmail { get; set; }
}
