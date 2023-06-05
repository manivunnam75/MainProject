namespace TraineesManagementSystem.Models
{
    public class TraineesWithBatches
    {
        public int Id { get;set; }
        public int BatchId { get;set; }

        public string BatchName { get; set; }   

        public int TraineeId { get; set; }   

        public string TraineeName { get; set; }
        public bool IsTick { get; set; }


    }
}
