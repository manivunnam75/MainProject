

using Azure;
using Microsoft.AspNetCore.Mvc;
using TraineesManagementSystem.Models;
using TraineesManagementSystem.Repositary;
using TraineesManagementSystem.Repositary.Context;
using TraineesManagementSystem.Services.Interfaces;
using TraineesManagementSystem.Services.Models;

using static System.Reflection.Metadata.BlobBuilder;

namespace TraineesManagementSystem.Controllers
{
    public class AdminViewController : Controller
	{
		private readonly TraineeDbContext _TraineeDbContext;
		private readonly ITraineeService service;
		private readonly ITraineeRepository  repository;
        public AdminViewController(TraineeDbContext traineeDbContext, ITraineeService Service, ITraineeRepository Repositary) 
		{
			_TraineeDbContext = traineeDbContext;
			service = Service;
			repository = Repositary;

        }
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(string MobileNumber, string Password)
		{
			if (MobileNumber == "Cognine" && Password == "12345")
			{
				return RedirectToAction("AdminLoginSuccess");
			}
			return View();

		}
		public IActionResult DashBoard(int page = 1)
		{
			var allTraineeDetails = repository.DashBoard();
			const int pageSize = 4;
			if (page < 1)
				page = 1;
			int recordsCount = allTraineeDetails.Count();
			var pager = new PaginationProperties(recordsCount, page, pageSize);
			int recordSkip = (page - 1) * pageSize;
			var data = allTraineeDetails.Skip(recordSkip).Take(pager.PageSize).ToList();
			this.ViewBag.Pager = pager;
			return View(data);

		}
		[HttpGet]
		public ActionResult AllTraineeDetails(int page = 1)
		{
			var details = _TraineeDbContext.Traineesdetails.ToList();
			const int pageSize = 4;
			if (page < 1)
				page = 1;
			int recordsCount = details.Count();
			var pager = new PaginationProperties(recordsCount, page, pageSize);
			int recordSkip = (page - 1) * pageSize;
			var data = details.Skip(recordSkip).Take(pager.PageSize).ToList();
			this.ViewBag.Pager = pager;
			return View(data);
		}

		public ActionResult GetTraineeDetailsById(int traineeId)
		{
			var traineeDetails = repository.GetTraineeById(traineeId);	
			return View(traineeDetails);
		}

		[HttpGet]
		public ActionResult EditTrainee(int Id)
		{
			var details = repository.EditTraineeById(Id);
			return View(details);
		}
		[HttpPost]
		public ActionResult EditTrainee(TraineeDetailsModel traineeDetails)
		{
			service.UpdateTrainee(traineeDetails);
			return RedirectToAction("AllDetails");
		}
		[HttpGet]
		public ActionResult DeleteTraineeById(int Id)
		{
			repository.DeleteTraineeById(Id);
			return RedirectToAction("DashBoard");
		}
		public ActionResult Batches()
		{
			return View();
		}
		[HttpGet]
		public ActionResult CreateBatch()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateBatch(BatchDetailsModel batchdetails)
		{
            service.CreateBatch(batchdetails);
			return RedirectToAction("BatchesDetails", "AdminView");
		}
		[HttpGet]
		public ActionResult BatchesDetails(TraineesManagementSystem.Repositary.Entites.BatchDetails batchDetails)
		{
			var details = repository.GetBatch(batchDetails); 
			return View(details);
		}

		public ActionResult EveryBatchDetails(int BatchId)
		{
			if (TempData.ContainsKey("batchid"))
			{
				BatchId = (int)TempData["batchid"];
				TempData["id"] = BatchId;
			}
			var details2 = _TraineeDbContext.BatchesDetails.FirstOrDefault(x => x.BatchId == BatchId);
			var details = _TraineeDbContext.Traineeswithbatches.Where(x => x.BatchId == BatchId).ToList();
			if (details != null)
			{
				TempData["id"] = details2.BatchId;
				TempData["name"] = details2.BatchName;
			}
			return View(details);
		}
		public ActionResult DeleteBatch(int BatchId)
		{
		   repository.DeleteBatch(BatchId);
		   return RedirectToAction("BatchesDetails");
		}

		public ActionResult DeleteTraineeFromBatch(int TraineeId, int BatchId)
		{
			repository.DeleteTraineeInBatch(TraineeId);
			TempData["batchid"] = BatchId;
			return RedirectToAction("EveryBatchDetails");
		}

		public ActionResult EditBatch(TraineesManagementSystem.Repositary.Entites.BatchDetails batchDetails,int batchId=0)
		{
			var details=repository.GetBatchDetails(batchDetails);
			TempData["batchId"] = batchDetails.BatchId;
			return View(details);
		}
		[HttpPost]
		public ActionResult EditBatch(TraineesManagementSystem.Repositary.Entites.BatchDetails batchDetails)
		{
			int batchId = 0;
            if (TempData.ContainsKey("batchId"))
			{
				batchId = (int)TempData["batchId"];

            }
			repository.UpdateBatch(batchDetails, batchId);
			return RedirectToAction("BatchesDetails");
		}
		//public ActionResult TraineeDetails(int TraineeId)
		//{

		//	var details2 = _TraineeDbContext.Traineesdetails.Where(x => x.TraineeId == TraineeId).ToList();
		//	if (details2 != null)
		//	{
		//		return View("AllDetails", details2);
		//	}
		//	return View("EveryBatchDetails");
		//}
		public ActionResult SubBatch(int MainBatchId, string MainBatchName)
		{
			TempData["btchid"] = MainBatchId;
			TempData["btchname"] = MainBatchName;
			return View();
		}

		public ActionResult CreateSubBatch(TraineesManagementSystem.Repositary.Entites.SubBatchDetails subBatchDetails)
		{
			service.CreateSubBatch(subBatchDetails);
			return RedirectToAction("SubBatchesDetails");
		}
		public ActionResult SubBatchesDetails(int mainBatchId)
		{
			var details=repository.GetSubBatch(mainBatchId);
	        return View(details);
		}
			
		
		public ActionResult TraineesInSubbatches(string subBatchName)
		{

			var trainessInSubBatch = repository.GetTraineesInSubBatches(subBatchName);
			return View(trainessInSubBatch);

		}
		[HttpGet]
		public ActionResult TraineesInMainBatch(int mainBatchId)
		{

			//var details = _TraineeDbContext.Traineeswithbatches.Where(x => x.BatchId == MainBatchId).ToList();
			//var details2 = _TraineeDbContext.Subbatchesdetails.FirstOrDefault(x => x.MainBatchId == MainBatchId);
			//if (MainBatchId != 0)
			//{
			//	TempData["SubBatchName"] = details2.SubBatchName;
			//	TempData["course"] = details2.AssignCourse;
			//}
			//if (MainBatchId == 0)
			//{
			//	int mainBatchId = (int)TempData["mainBatchId"];

			//	var detailsOfBatch = _TraineeDbContext.Traineeswithbatches.Where(x => x.BatchId == mainBatchId).ToList();
			//	var details2OfBatch = _TraineeDbContext.Subbatchesdetails.FirstOrDefault(x => x.MainBatchId == mainBatchId);
			//	TempData["SubBatchName"] = details2OfBatch.SubBatchName;
			//	TempData["course"] = details2OfBatch.AssignCourse;
			var traineesInBatch = repository.GetTraineesInMainBatch(mainBatchId);

                return View(traineesInBatch);

			}
			//return View(details);
		
		//[HttpPost]
		//public ActionResult TraineesInMainBatch(List<TraineesWithBatches> l1, TraineesInSubBatches _tisb)
		//{
		//	string subbatch = "";
		//	string course = "";
		//	if (TempData.ContainsKey("SubBatchName") && TempData.ContainsKey("course"))
		//	{
		//		subbatch = TempData["SubBatchName"].ToString();
		//		course = TempData["course"].ToString();
		//	}
		//	var subbtch = l1.FindAll(x => x.IsTick == true);

		//	for (int i = 0; i < subbtch.Count; i++)
		//	{

		//		_tisb.MainBatchId = subbtch[i].BatchId;
				
		//		_tisb.MainBatchName = subbtch[i].BatchName;
		//		_tisb.SubBatchName = subbatch;
		//		_tisb.TraineeId = subbtch[i].TraineeId;
		//		_tisb.TraineeName = subbtch[i].TraineeName;
		//		_tisb.CourseAssigned = course;

		//		_TraineeDbContext.Traineesinsubbatches.Add(_tisb);
		//		_TraineeDbContext.SaveChanges();


		//	}
		//	return RedirectToAction("TraineesInSubBatches",subbatch);
		//}
		public ActionResult DelTraineeInSubBatch(int traineeId)
		{
			repository.DeleteTraineeInSubBatch(traineeId);
			return RedirectToAction("TraineesInSubbatches", "AdminView");
		}
		public ActionResult DelSubBatch(string subBatchName, int mainBatchId)
		{
			var subBatchDetails = _TraineeDbContext.Subbatchesdetails.FirstOrDefault(x => x.SubBatchName == subBatchName);
			_TraineeDbContext.Subbatchesdetails.Remove(subBatchDetails);
			_TraineeDbContext.SaveChanges();
			SqlConnections sqlConnections = new SqlConnections();
			sqlConnections.Query("delete from TraineesInSubBatches where SubBatchName='" + subBatchName + "'");
			_TraineeDbContext.SaveChanges();
			TempData["MainBatchId"] = mainBatchId;
			return RedirectToAction("SubBatchesDetails");
		}

		public ActionResult AddTraineeToMainBatch()
		{
			var traineeDetails = repository.DashBoard();
			return View(traineeDetails);
		}

	}
}