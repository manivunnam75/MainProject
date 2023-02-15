using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TraineesManagementSystem.Models
{
    public class TraineesInSubBatches
    {
        public int Id { get; set; }

        public int MainBatchId { get;set; }

        public string MainBatchName { get; set; }

        public string SubBatchName { get; set; }    


        public int TraineeId { get; set; }  

        public string TraineeName { get;set; }

        public string CourseAssigned { get; set; }  
    }
}