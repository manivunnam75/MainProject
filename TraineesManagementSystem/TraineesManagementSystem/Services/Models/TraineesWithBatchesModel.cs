namespace TraineesManagementSystem.Services.Models
{
    public class TraineesWithBatchesModel
    {
        public int Id { get; set; }
        public int BatchId { get; set; }

        public string BatchName { get; set; } = string.Empty;

        public string TraineeId { get; set; } = string.Empty;

        public string TraineeName { get; set; } = string.Empty;
    }
}
