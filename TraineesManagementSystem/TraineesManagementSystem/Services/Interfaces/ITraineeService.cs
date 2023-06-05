using TraineesManagementSystem.Repositary.Entites;
using TraineesManagementSystem.Services.Models;

namespace TraineesManagementSystem.Services.Interfaces
{
    public interface ITraineeService
    {
       
        public void UpdateTrainee(TraineeDetailsModel traineeDetails);
       
        public void CreateBatch(BatchDetailsModel batchdetails);
        public void UpdateBatch(BatchDetailsModel batchdetails);
        public void CreateSubBatch(SubBatchDetails subBatchDetails);

    }
}
