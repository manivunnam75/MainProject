using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace TraineesManagementSystem.Models.ViewModel
{
    public class TraineeViewModel
    {
        

        [Required(ErrorMessage = "EmployeeId is Required")]
        public int TraineeId { get; set; }
        [Required(ErrorMessage = "Employee Name is Required")]

        public string TraineeName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Mobile Number")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Email Id is Required")]

        public string EmailId { get; set; }
        [Required(ErrorMessage = "Date Of Joining  is Required")]

        public string DateOfJoining { get; set; }
        [Required(ErrorMessage = " 10th Percentage is Required")]



        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Your City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Your Village")]
        public string Village { get; set; }

        [Required(ErrorMessage = "Please Enter Your Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please Enter Your Degree Passed Out Year")]
        public int Pincode { get; set; }
        public string DegreeCollegeName { get; set; }
        [Required(ErrorMessage = "Degree Percentage  is Required")]

        public int DegreePercentage { get; set; }
        [Required(ErrorMessage = "Please Enter Your Degree Passed Out Year")]
        public string DegreePassedOut { get; set; }
        [Required(ErrorMessage = "Stream is Required")]
        public string Stream { get; set; }
        [Required(ErrorMessage ="University is Required")]
        public string University { get; set; }

       
        [Required(ErrorMessage = "Please Enter Your DateOfBirth")]
        public string DateOfBirth { get; set; }

        public IFormFile ProfilePicture { get; set; }

    }
}
