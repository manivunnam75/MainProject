using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using TraineesManagementSystem.Repositary.Context;
using TraineesManagementSystem.Repositary.Entites;
using TraineesManagementSystem.Services.Models;

namespace TraineesManagementSystem.Repositary
{
    public class TraineeRepository:ITraineeRepository
    {
        private readonly TraineeDbContext traineeDbContext;
        public TraineeRepository(TraineeDbContext TraineeDbContext)
        {
            traineeDbContext=TraineeDbContext;
        }
        public List<TraineeDetails> DashBoard()
        {
            var allTraineeDetails= traineeDbContext.Traineesdetails.ToList();
            return allTraineeDetails;
        }
        public TraineeDetails GetTraineeById(int traineeId)
        {
          var traineeDetails= traineeDbContext.Traineesdetails.FirstOrDefault(x=>x.TraineeId== traineeId);
            return traineeDetails;
        }
        public TraineeDetails EditTraineeById(int traineeId)
        {
            var traineeDetails = traineeDbContext.Traineesdetails.FirstOrDefault(x => x.TraineeId == traineeId);
            return traineeDetails;
        }
        public void UpdateTrainee(TraineeDetails traineeDetails)
        {
            traineeDbContext.Traineesdetails.Update(traineeDetails);
            traineeDbContext.SaveChanges();
        }

        public void DeleteTraineeById(int Id)
        {
            var details = traineeDbContext.Traineesdetails.FirstOrDefault(x => x.TraineeId == Id);
            traineeDbContext.Traineesdetails.Remove(details);
            traineeDbContext.SaveChanges();
            var traineeInMainBatch = traineeDbContext.Traineeswithbatches.FirstOrDefault(x => x.TraineeId == Id);
            if (traineeInMainBatch != null)
            {
                traineeDbContext.Traineeswithbatches.Remove(traineeInMainBatch);
                traineeDbContext.SaveChanges();
            }
            var traineeInSubBatch = traineeDbContext.TraineesInSubbatches.FirstOrDefault(x => x.TraineeId == Id);
            if (traineeInSubBatch != null)
            {
                traineeDbContext.TraineesInSubbatches.Remove(traineeInSubBatch);
                traineeDbContext.SaveChanges();
            }
        }
        public void CreateBatch(BatchDetails batchDetails)
        {
            traineeDbContext.BatchesDetails.Add(batchDetails);
            traineeDbContext.SaveChanges();
        }
        public List<BatchDetails> GetBatch(BatchDetails batchDetails)
        {
            var details = new List<BatchDetails>();
            if (batchDetails != null)
            {
                details = traineeDbContext.BatchesDetails.ToList();
                return details;
            }
            else
            {
                details = traineeDbContext.BatchesDetails.Where(x => x.BatchName == batchDetails.BatchName || x.BatchId== batchDetails.BatchId).ToList();
                return details;
            }
        }
        public void DeleteBatch(int batchId)
        {

            var batchdetails= traineeDbContext.BatchesDetails.FirstOrDefault(x=> x.BatchId == batchId);
            traineeDbContext.BatchesDetails.Remove(batchdetails);
           var traineeswithbatches = traineeDbContext.Traineeswithbatches.FirstOrDefault(x => x.BatchId == batchId);
            traineeDbContext.Traineeswithbatches.Remove(traineeswithbatches);
            traineeDbContext.SaveChanges();

            //var batchdetails = from BatchDetails in traineeDbContext.BatchesDetails
            //                   join TraineeWithBatches in traineeDbContext.Traineeswithbatches
            //                   on BatchDetails.BatchId equals TraineeWithBatches.BatchId
            //                   where BatchDetails.BatchId == batchId && TraineeWithBatches.BatchId==batchId

            //traineeDbContext
        }
        public void DeleteTraineeInBatch(int TraineeId)
        {
            var details = traineeDbContext.Traineeswithbatches.FirstOrDefault(x => x.TraineeId == TraineeId);
            traineeDbContext.Traineeswithbatches.Remove(details);
            traineeDbContext.SaveChanges();
        }
        
        public void UpdateBatch(BatchDetails batchdetails,int batchID)
        {
         var details =  traineeDbContext.BatchesDetails.Find(batchID);
             details.BatchName = batchdetails.BatchName;
            traineeDbContext.SaveChanges(); 
        }

        public void CreateSubBatch(SubBatchDetails subbatchdetails)
        {
            traineeDbContext.Subbatchesdetails.Add(subbatchdetails);
            traineeDbContext.SaveChanges();
        }
        public SubBatchDetails GetSubBatch(int mainBatchId)
        {
          var subBatchDetails=  traineeDbContext.Subbatchesdetails.FirstOrDefault(x=>x.MainBatchId== mainBatchId);
            if(subBatchDetails != null) 
            { 
                return subBatchDetails;
            }
            return subBatchDetails;
            
        }
        public List<TraineesInSubBatch> GetTraineesInSubBatches(string subBatchName)
        {
            var traineesInSubBatch = traineeDbContext.TraineesInSubbatches.Where(x => x.SubBatchName == subBatchName).ToList();
            return traineesInSubBatch;
        }
        public List<TraineesWithBatches> GetTraineesInMainBatch(int bacthId)
        {
            var taraineDetails= traineeDbContext.Traineeswithbatches.Where(x=>x.BatchId== bacthId).ToList();    
            return taraineDetails;
        }
        public void DeleteTraineeInSubBatch(int traineeId)
        {
            var traineeDetails= traineeDbContext.TraineesInSubbatches.FirstOrDefault(x=>x.TraineeId== traineeId);
            traineeDbContext.TraineesInSubbatches.Remove(traineeDetails);
            traineeDbContext.SaveChanges();
        }

        public BatchDetails GetBatchDetails(BatchDetails batchDetails)
        {
            var batchDetals = traineeDbContext.BatchesDetails.FirstOrDefault(x => x.BatchId == batchDetails.BatchId);
            return batchDetals;
        }


    }
}
