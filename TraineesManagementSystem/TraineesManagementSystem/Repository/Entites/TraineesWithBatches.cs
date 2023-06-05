namespace TraineesManagementSystem.Repositary.Entites
{
    public class TraineesWithBatches
    {
        public int Id { get; set; }
        public int BatchId { get; set; }

        public string BatchName { get; set; } = string.Empty;

        public int TraineeId { get; set; } 

        public string TraineeName { get; set; } = string.Empty;
    }
}
