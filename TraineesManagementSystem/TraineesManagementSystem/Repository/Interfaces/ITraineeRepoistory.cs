using Microsoft.AspNetCore.Mvc;
using TraineesManagementSystem.Repositary.Entites;
using TraineesManagementSystem.Services.Models;

namespace TraineesManagementSystem.Repositary
{
    public interface ITraineeRepository
    {

        public List<TraineeDetails> DashBoard();
        public TraineeDetails GetTraineeById(int traineeId);
        public TraineeDetails EditTraineeById(int traineeId);
        public void UpdateTrainee(TraineeDetails traineeDetails);
        public void DeleteTraineeById(int Id);
        public void CreateBatch(BatchDetails batch);
        public List<BatchDetails> GetBatch(BatchDetails batch);
        public void DeleteBatch(int batchId);
        public void DeleteTraineeInBatch(int batchId);
        public void UpdateBatch(BatchDetails batchdetails,int batchId);
        public void CreateSubBatch(SubBatchDetails subBatchDetails);
        public SubBatchDetails GetSubBatch(int mainBatchId);
        public List<TraineesInSubBatch> GetTraineesInSubBatches(string subBatchName);
        public List<TraineesWithBatches> GetTraineesInMainBatch(int bacthId);
        public BatchDetails GetBatchDetails(BatchDetails batchDetails);
        public void DeleteTraineeInSubBatch(int traineeId);



    }
}
