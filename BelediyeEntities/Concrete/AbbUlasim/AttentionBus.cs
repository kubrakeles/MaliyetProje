using BelediyeCore.Entities;

namespace BelediyeEntities.Concrete.AbbUlasim;

public class AttentionBus :IEntity
{
         public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> AttentionId { get; set; }
        public int BusId { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public System.DateTime InsertDate { get; set; }
        public bool Secim { get; set; }
    
        public virtual Attention Attention { get; set; }
        public virtual Bus Bus { get; set; }
}
