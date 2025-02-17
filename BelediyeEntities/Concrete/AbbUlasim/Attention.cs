using BelediyeCore.Entities;

namespace BelediyeEntities.Concrete.AbbUlasim;

public class Attention :IEntity
{
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime FinishTime { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsAll { get; set; }
        public System.DateTime InsertDate { get; set; }
            public virtual ICollection<AttentionBus> AttentionBus { get; set; }
}
