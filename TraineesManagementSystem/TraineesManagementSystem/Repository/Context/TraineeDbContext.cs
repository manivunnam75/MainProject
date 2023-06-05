using Microsoft.EntityFrameworkCore;
using TraineesManagementSystem.Repositary.Entites;

namespace TraineesManagementSystem.Repositary.Context
{
    public class TraineeDbContext : DbContext
    {
        public TraineeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TraineeDetails> Traineesdetails { get; set; }
        public DbSet<BatchDetails> BatchesDetails { get; set; }

        public DbSet<TraineesWithBatches> Traineeswithbatches { get; set; }

        public DbSet<SubBatchDetails> Subbatchesdetails { get; set; }

        public DbSet<TraineesInSubBatch> TraineesInSubbatches { get; set; }


    }
}
