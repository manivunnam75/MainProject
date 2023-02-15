using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TraineesManagementSystem.Models;
using TraineesManagementSystem.Models.ViewModel;

namespace TraineesManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly TraineeDbContext _TraineeDbContext;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public HomeController(TraineeDbContext traineeDbContext,IWebHostEnvironment webHostEnvironment)
        {
            _TraineeDbContext = traineeDbContext;
            _WebHostEnvironment= webHostEnvironment;    
        }

        [HttpGet]
        public IActionResult TraineeDetails()
        {
            return View();                               

        }

        [HttpPost]
        public IActionResult TraineeDetails(TraineeViewModel traineeDetails)
        {
            string fileName = UploadedFile(traineeDetails);



                TraineeDetails _traineeDetails = new TraineeDetails()
                {
                    TraineeId = traineeDetails.TraineeId,
                    TraineeName = traineeDetails.TraineeName,
                    MobileNumber = traineeDetails.MobileNumber,
                    EmailId = traineeDetails.EmailId,
                    Stream=traineeDetails.Stream,
                    University= traineeDetails.University,
                    DegreeCollegeName = traineeDetails.DegreeCollegeName,
                    DegreePercentage = traineeDetails.DegreePercentage,
                    DateOfBirth = traineeDetails.DateOfBirth,
                    DateOfJoining = traineeDetails.DateOfJoining,
                    DegreePassedOut = traineeDetails.DegreePassedOut,
                    ProfilePic = fileName,
                    City=traineeDetails.City,
                    State=traineeDetails.State,
                    Village=traineeDetails.Village,
                    Street=traineeDetails.Street,
                    Pincode=traineeDetails.Pincode
                };
              
                _TraineeDbContext.Traineesdetails.Add(_traineeDetails);

                _TraineeDbContext.SaveChanges();

            ViewBag.Message= "Registration Successfully Completed";
                
                return View();

            
        }

        private string UploadedFile(TraineeViewModel model)
        {
            string uniqueFileName = null;
            if (model.ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(_WebHostEnvironment.WebRootPath, "ProfilePics");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfilePicture.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}