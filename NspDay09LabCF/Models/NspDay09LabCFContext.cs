using Microsoft.EntityFrameworkCore;

namespace NspDay09LabCF.Models
{
    public class NspDay09LabCFContext:DbContext
    {
        public NspDay09LabCFContext()
        {
        }
        public NspDay09LabCFContext (DbContextOptions<NspDay09LabCFContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.;Database=NspDay09LabCF;Trusted_Connection=True;TrustServerCertificate=True;"
                );
            }
        }
        public DbSet<NspLoai_San_Pham> nspLoai_San_Phams { get; set; }
        public DbSet<NspSan_Pham> nspSan_Phams { get; set; }
    }
}
