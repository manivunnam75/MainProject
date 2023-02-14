namespace TraineesManagementSystem.Models
{
    public class SubBatchesDetails
    {
        public int Id { get;set; }

        public int MainBatchId { get; set; }

        public string MainBatchName { get; set; }

        public string SubBatchName { get; set; }


        public int CourseAssigned { get; set; }

    }
}
