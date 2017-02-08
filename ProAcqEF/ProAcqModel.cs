using System.Data.Entity;

namespace ProAcqEF
{
    // ProAcq Entities
    class ProAcqModel : DbContext
    {
        public DbSet<PD_Entity> PD_Entities { get; set; }
    }

    // Memo ENtity
    public class PD_Entity
    {
        public int Id { get; set; }
        public string PD_Date { get; set; }
        public string PD_AbsTime { get; set; }
        public string PD_RelTime { get; set; }
        public string PD_Memo { get; set; }
    }
}
