using System;
using System.Collections.Generic;
using System.Linq;
using Part_2_Prog.Models;

namespace Part_2_Prog.Services
{
    public class DataService
    {
        public List<User> Users = new List<User>();
        public List<Part_2_Prog.Models.Claim> Claims = new List<Part_2_Prog.Models.Claim>();
        public List<ClaimApproval> Approvals = new List<ClaimApproval>();

        public DataService()
        {
            // Initialize sample users
            Users.Add(new User { UserID = 1, Username = "lecturer1", Password = "pass", Role = "Lecturer" });
            Users.Add(new User { UserID = 2, Username = "coordinator1", Password = "pass", Role = "Coordinator" });
        }

        public User Authenticate(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public void AddClaim(int lecturerID, decimal hoursWorked, decimal hourlyRate, string supportingDocuments)
        {
            int nextClaimID = Claims.Any() ? Claims.Max(c => c.ClaimID) + 1 : 1;
            Claims.Add(new Part_2_Prog.Models.Claim
            {
                ClaimID = nextClaimID,
                LecturerID = lecturerID,
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                HoursWorked = hoursWorked,
                HourlyRate = hourlyRate,
                Status = "Pending",
                SupportingDocuments = supportingDocuments
            });
        }

        public List<Part_2_Prog.Models.Claim> GetLecturerClaims(int lecturerID)
        {
            return Claims.Where(c => c.LecturerID == lecturerID).ToList();
        }

        public void ApproveClaim(int claimID, int coordinatorID)
        {
            var claim = Claims.FirstOrDefault(c => c.ClaimID == claimID);
            if (claim != null)
            {
                claim.Status = "Approved";
                Approvals.Add(new ClaimApproval
                {
                    ApprovalID = Approvals.Count + 1,
                    ClaimID = claim.ClaimID,
                    CoordinatorID = coordinatorID,
                    ApprovalStatus = "Approved",
                    ApprovalDate = DateTime.Now.ToString("yyyy-MM-dd")
                });
            }
        }

        public void RejectClaim(int claimID, int coordinatorID)
        {
            var claim = Claims.FirstOrDefault(c => c.ClaimID == claimID);
            if (claim != null)
            {
                claim.Status = "Rejected";
                Approvals.Add(new ClaimApproval
                {
                    ApprovalID = Approvals.Count + 1,
                    ClaimID = claim.ClaimID,
                    CoordinatorID = coordinatorID,
                    ApprovalStatus = "Rejected",
                    ApprovalDate = DateTime.Now.ToString("yyyy-MM-dd")
                });
            }
        }

        public List<Part_2_Prog.Models.Claim> GetPendingClaims()
        {
            return Claims.Where(c => c.Status == "Pending").ToList();
        }
    }
}
