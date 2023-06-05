namespace TraineesManagementSystem.Services.Models
{
    public class SubBatchModel
    {
        public int Id { get; set; }

        public int MainBatchId { get; set; }

        public string MainBatchName { get; set; }

        public string SubBatchName { get; set; }

        public string AssignCourse { get; set; }
    }
}
