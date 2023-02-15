

using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TraineesManagementSystem.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace TraineesManagementSystem.Controllers
{
	public class AdminViewController : Controller
	{
		private readonly TraineeDbContext _TraineeDbContext;
		public AdminViewController(TraineeDbContext traineeDbContext)
		{
			_TraineeDbContext = traineeDbContext;
		}
		[HttpGet]
		public IActionResult Admin()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Admin(string MobileNumber, string Password)
		{
			if (MobileNumber == "Cognine" && Password == "12345")
			{
				return RedirectToAction("AdminLoginSuccess");
			}
			return View();

		}
		public IActionResult AdminLoginSuccess(int page = 1)
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

		[HttpPost]
		public ActionResult AllTraineeDetails(List<TraineeDetails> L1, TraineeDetails t1)
		{
			var details = L1.FindAll(x => x.Ischeck == true).ToList();

			int batchId = 0;
			string batchName = "";
			string courseAssigned = "";
			if (TempData.ContainsKey("Id") && TempData.ContainsKey("Name") && TempData.ContainsKey("Course"))
			{
				batchId = (int)TempData["Id"];
				batchName = TempData["Name"].ToString();
				courseAssigned = TempData["Course"].ToString();

			}
			for (int i = 0; i < details.Count; i++)
			{
				TraineesWithBatches _addingTraineesToBatches = new TraineesWithBatches();

				_addingTraineesToBatches.BatchId = batchId;
				_addingTraineesToBatches.BatchName = batchName;

				_addingTraineesToBatches.TraineeId = details[i].TraineeId.ToString();
				_addingTraineesToBatches.TraineeName = details[i].TraineeName;

				_TraineeDbContext.Traineeswithbatches.Add(_addingTraineesToBatches);
				_TraineeDbContext.SaveChanges();
			}

			TempData["batchid"] = batchId;

			return RedirectToAction("EveryBatchDetails", batchId);
		}

		public ActionResult AllDetails(int traineeId)
		{

			var details2 = _TraineeDbContext.Traineesdetails.Where(x => x.TraineeId == traineeId).ToList();
			if (details2 != null)
			{
				return View("AdminLoginSuccess", details2);
			}
			return View("AdminLoginSuccess");
		}

		public ActionResult GetTraineeDetailsById(int traineeId)
		{

			var details2 = _TraineeDbContext.Traineesdetails.Where(x => x.TraineeId == traineeId).FirstOrDefault();

			return View(details2);

		}

		[HttpGet]
		public ActionResult Edit(int Id)
		{
			var details = _TraineeDbContext.Traineesdetails.FirstOrDefault(x => x.TraineeId == Id);

			return View(details);


		}
		[HttpPost]
		public ActionResult Edit(TraineeDetails traineeDetails)
		{
			TraineeDetails _traineeDetails = new TraineeDetails()
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
			_TraineeDbContext.Update(_traineeDetails);

			_TraineeDbContext.SaveChanges();
			return RedirectToAction("AllDetails");
		}
		[HttpGet]
		public ActionResult Delete(string Id)
		{
			int Traineeid = Convert.ToInt32(Id);
			var details = _TraineeDbContext.Traineesdetails.FirstOrDefault(x => x.TraineeId == Traineeid);
			_TraineeDbContext.Traineesdetails.Remove(details);
			_TraineeDbContext.SaveChanges();
			var traineeInMainBatch = _TraineeDbContext.Traineeswithbatches.FirstOrDefault(x => x.TraineeId == Id);
			if (traineeInMainBatch != null)
			{
				_TraineeDbContext.Traineeswithbatches.Remove(traineeInMainBatch);
				_TraineeDbContext.SaveChanges();
			}
			var traineeInSubBatch = _TraineeDbContext.Traineesinsubbatches.FirstOrDefault(x => x.TraineeId == Traineeid);
			if (traineeInSubBatch != null)
			{
				_TraineeDbContext.Traineesinsubbatches.Remove(traineeInSubBatch);
				_TraineeDbContext.SaveChanges();
			}
			return RedirectToAction("AdminLoginSuccess");
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
		public ActionResult CreateBatch(BatchDetails batchdetails)
		{
			BatchDetails _batchDetails = new BatchDetails()
			{
				BatchId = batchdetails.BatchId,
				BatchName = batchdetails.BatchName,
			};
			_TraineeDbContext.BatchesDetails.Add(_batchDetails);
			_TraineeDbContext.SaveChanges();
			return RedirectToAction("BatchesDetails", "AdminView");
		}
		[HttpGet]
		public ActionResult BatchesDetails()
		{
			var details = _TraineeDbContext.BatchesDetails.ToList();
			return View(details);
		}

		[HttpPost]
		public ActionResult BatchesDetails(string batchName)
		{
			var details2 = _TraineeDbContext.BatchesDetails.Where(x => x.BatchName == batchName).ToList();
			if (details2 != null)
			{
				return View(details2);
			}
			return RedirectToAction("BatchesDetails");

		}




		public ActionResult AllDetails1(int BatchId)
		{
			var details = _TraineeDbContext.BatchesDetails.FirstOrDefault(x => x.BatchId == BatchId);
			if (details != null)
			{
				TempData["Id"] = details.BatchId;
				TempData["Name"] = details.BatchName;
			}
			return RedirectToAction("AllTraineeDetails");
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
			var details2 = _TraineeDbContext.BatchesDetails.FirstOrDefault(x => x.BatchId == BatchId);
			_TraineeDbContext.BatchesDetails.Remove(details2);
			var dltebatch = _TraineeDbContext.Traineeswithbatches.Where(x => x.BatchId == BatchId).ToList();
			foreach (TraineesWithBatches btd in dltebatch)
			{
				_TraineeDbContext.Traineeswithbatches.Remove(btd);
				_TraineeDbContext.SaveChanges();
			}
			_TraineeDbContext.SaveChanges();
			return RedirectToAction("BatchesDetails");


		}
		public ActionResult DeleteTraineeFromBatch(int TraineeId, int BatchId)
		{
			string id = TraineeId.ToString();
			var details = _TraineeDbContext.Traineeswithbatches.FirstOrDefault(x => x.TraineeId == id);
			_TraineeDbContext.Traineeswithbatches.Remove(details);
			_TraineeDbContext.SaveChanges();
			TempData["batchid"] = BatchId;
			return RedirectToAction("EveryBatchDetails");
		}
		public ActionResult EditBatch(int BatchId)
		{
			var details = _TraineeDbContext.BatchesDetails.FirstOrDefault(x => x.BatchId == BatchId);
			TempData["batchId"] = BatchId;
			return View(details);
		}
		[HttpPost]
		public ActionResult EditBatch(BatchDetails batchDetails)
		{
			int batchid = 0;
			if (TempData.ContainsKey("batchId"))
			{
				batchid = Convert.ToInt32(TempData["batchId"]);
			}
			if (batchDetails != null)
			{
				BatchDetails _batchDetails = new BatchDetails()
				{
					BatchId = batchDetails.BatchId,
					BatchName = batchDetails.BatchName,
				};



				_TraineeDbContext.SaveChanges();

				SqlConnections sqlConnections = new SqlConnections();
				sqlConnections.Query("update Traineeswithbatches set BatchId='" + _batchDetails.BatchId + "',BatchName='" + _batchDetails.BatchName + "' where BatchId='" + batchid + "'");


				_TraineeDbContext.SaveChanges();

			}
			return RedirectToAction("BatchesDetails");
		}
		public ActionResult TraineeDetails(int TraineeId)
		{

			var details2 = _TraineeDbContext.Traineesdetails.Where(x => x.TraineeId == TraineeId).ToList();
			if (details2 != null)
			{
				return View("AllDetails", details2);
			}
			return View("EveryBatchDetails");
		}
		public ActionResult SubBatch(int MainBatchId, string MainBatchName)
		{
			TempData["btchid"] = MainBatchId;
			TempData["btchname"] = MainBatchName;
			return View();
		}

		public ActionResult CreateSubBatch(SubBatchesDetails subBatchDetails)
		{
			int batchId = (int)TempData["btchid"];
			string batchName = TempData["btchname"].ToString();
			TempData["MainBatchId"] = batchId;
			SubBatchesDetails _subBatchDetails = new SubBatchesDetails()
			{
				MainBatchId = batchId,
				MainBatchName = batchName,
				SubBatchName = subBatchDetails.SubBatchName,
				AssignCourse = subBatchDetails.AssignCourse
			};
			_TraineeDbContext.Subbatchesdetails.Add(_subBatchDetails);
			_TraineeDbContext.SaveChanges();
			return RedirectToAction("SubBatchesDetails");
		}
		public ActionResult SubBatchesDetails()
		{
			if (TempData["MainBatchId"] != null)
			{
				int batchId = (int)TempData["MainBatchId"];
				var details2 = _TraineeDbContext.BatchesDetails.FirstOrDefault(x => x.BatchId == batchId);
				var details = _TraineeDbContext.Subbatchesdetails.Where(x => x.MainBatchId == batchId).ToList();
				TempData["mainBatchId"] = details2.BatchId;
				TempData["mainBatchName"] = details2.BatchName;
				return View(details);

			}
			return View("AdminLoginSuccess");
		}
		public ActionResult TraineesInSubbatches(string SubBatchName)
		{
			
			var details = _TraineeDbContext.Subbatchesdetails.FirstOrDefault(x => x.SubBatchName == SubBatchName);
			var details2 = _TraineeDbContext.Traineesinsubbatches.Where(x => x.SubBatchName == SubBatchName).ToList();
			TempData["mainBatchId"] = details.MainBatchId;
			TempData["name"] = SubBatchName;
			TempData["mainBatchName"] = details.MainBatchName;

			return View(details2);

		}
		[HttpGet]
		public ActionResult TraineesInMainBatch(int MainBatchId)
		{

			var details = _TraineeDbContext.Traineeswithbatches.Where(x => x.BatchId == MainBatchId).ToList();
			var details2 = _TraineeDbContext.Subbatchesdetails.FirstOrDefault(x => x.MainBatchId == MainBatchId);
			if (MainBatchId != 0)
			{
				TempData["SubBatchName"] = details2.SubBatchName;
				TempData["course"] = details2.AssignCourse;
			}
			if (MainBatchId == 0)
			{
				int mainBatchId = (int)TempData["mainBatchId"];

				var detailsOfBatch = _TraineeDbContext.Traineeswithbatches.Where(x => x.BatchId == mainBatchId).ToList();
				var details2OfBatch = _TraineeDbContext.Subbatchesdetails.FirstOrDefault(x => x.MainBatchId == mainBatchId);
				TempData["SubBatchName"] = details2OfBatch.SubBatchName;
				TempData["course"] = details2OfBatch.AssignCourse;

				return View(detailsOfBatch);

			}
			return View(details);
		}
		[HttpPost]
		public ActionResult TraineesInMainBatch(List<TraineesWithBatches> l1, TraineesInSubBatches _tisb)
		{
			

			string subbatch = "";
			string course = "";
			if (TempData.ContainsKey("SubBatchName") && TempData.ContainsKey("course"))
			{
				subbatch = TempData["SubBatchName"].ToString();
				course = TempData["course"].ToString();
			}
			var subbtch = l1.FindAll(x => x.Istick == true);

			for (int i = 0; i < subbtch.Count; i++)
			{

				_tisb.MainBatchId = subbtch[i].BatchId;
				
				_tisb.MainBatchName = subbtch[i].BatchName;
				_tisb.SubBatchName = subbatch;
				_tisb.TraineeId = Int32.Parse(subbtch[i].TraineeId);
				_tisb.TraineeName = subbtch[i].TraineeName;
				_tisb.CourseAssigned = course;

				_TraineeDbContext.Traineesinsubbatches.Add(_tisb);
				_TraineeDbContext.SaveChanges();


			}
			return RedirectToAction("TraineesInSubBatches",subbatch);
		}
		public ActionResult DelTraineeInSubBatch(int traineeId, string SubBatchName)
		{
			var traineeDetails = _TraineeDbContext.Traineesinsubbatches.FirstOrDefault(x => x.TraineeId == traineeId);
			if (traineeDetails != null)
			{
				_TraineeDbContext.Traineesinsubbatches.Remove(traineeDetails);
				_TraineeDbContext.SaveChanges();
			}
			TempData["subBatchname"] = SubBatchName;
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

	}
}