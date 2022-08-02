using MaliyetCore.Entities;

namespace MaliyetEntities.Concrete;

public class Unit:IEntity
{
    public int id { get; set; }
    public string UnitName { get; set; }
    public ICollection<Tender> Tenders { get; set; } 

    
}
