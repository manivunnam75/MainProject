using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.IO;

using TraineesManagementSystem.Repositary;
using TraineesManagementSystem.Repositary.Context;
using TraineesManagementSystem.Repositary.Entites;
using TraineesManagementSystem.Services.Interfaces;
using TraineesManagementSystem.Services.Models;

namespace TraineesManagementSystem.Services
{
    public class TraineeService : ITraineeService
    {
		private readonly ITraineeRepository traineeRepositary;
		public TraineeService(ITraineeRepository TraineeRepositary) 
		{
            traineeRepositary = TraineeRepositary;

        }
        public void UpdateTrainee(TraineeDetailsModel traineeDetails)
        {
			var updateDetails = new TraineeDetails()
			{
				TraineeId = traineeDetails.TraineeId,
				TraineeName = traineeDetails.TraineeName,
				MobileNumber = traineeDetails.MobileNumber,
				EmailId = traineeDetails.EmailId,
				DegreeCollegeName = traineeDetails.DegreeCollegeName,
				DegreePercentage = traineeDetails.DegreePercentage,
				DateOfBirth = traineeDetails.DateOfBirth,
				DateOfJoining = traineeDetails.DateOfJoining,
				DegreePassedOut = traineeDetails.DegreePassedOut,
				City = traineeDetails.City,
				State = traineeDetails.State,
				Stream = traineeDetails.Stream,
				Village = traineeDetails.Village,
				Pincode = traineeDetails.Pincode,
				Street = traineeDetails.Street,
			};
           
            traineeRepositary.UpdateTrainee(updateDetails);
        }
        public void CreateBatch(BatchDetailsModel batchdetails)
		{
			var batchDetails = new TraineesManagementSystem.Repositary.Entites.BatchDetails()
			{
				BatchId = batchdetails.BatchId,
				BatchName = batchdetails.BatchName,
			};
			traineeRepositary.CreateBatch(batchDetails);
		}
		public void UpdateBatch(BatchDetailsModel batchDetails)
		{
			if (batchDetails != null)
			{
				BatchDetails _batchDetails = new BatchDetails()
				{
					BatchId = batchDetails.BatchId,
					BatchName = batchDetails.BatchName,
				};
			}

		}

		public void CreateSubBatch(SubBatchDetails subBatchDetails)
		{
            SubBatchDetails _subBatchDetails = new SubBatchDetails()
            {
                MainBatchId = subBatchDetails.MainBatchId,
                MainBatchName = subBatchDetails.MainBatchName,
                SubBatchName = subBatchDetails.SubBatchName,
                AssignCourse = subBatchDetails.AssignCourse
            };
			traineeRepositary.CreateSubBatch(subBatchDetails);
         }
    }
}
