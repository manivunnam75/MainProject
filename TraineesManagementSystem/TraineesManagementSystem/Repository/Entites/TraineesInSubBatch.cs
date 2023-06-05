namespace TraineesManagementSystem.Repositary.Entites
{
    public class TraineesInSubBatch
    {
        public int Id { get; set; }

        public int MainBatchId { get; set; }

        public string MainBatchName { get; set; } =string.Empty;

        public string SubBatchName { get; set; } = string.Empty;

        public int TraineeId { get; set; }

        public string TraineeName { get; set; } = string.Empty;

        public string CourseAssigned { get; set; } = string.Empty;
    }
}
