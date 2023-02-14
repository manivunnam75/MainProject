using Microsoft.EntityFrameworkCore;

namespace TraineesManagementSystem.Models
{
    public class TraineeDbContext :DbContext
    {
        public TraineeDbContext(DbContextOptions options):base(options) 
        { 
        }
        public DbSet<TraineeDetails> Traineesdetails { get; set; }
        public DbSet<BatchDetails> BatchesDetails { get; set; }

        public DbSet<TraineesWithBatches> Traineeswithbatches { get; set; }

        public DbSet<SubBatchesDetails> Subbatchesdetails { get; set;}

        public DbSet<TraineesInSubBatches> Traineesinsubbatches { get; set; }


    }
}
