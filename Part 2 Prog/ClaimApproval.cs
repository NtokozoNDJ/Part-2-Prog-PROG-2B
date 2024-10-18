namespace Part_2_Prog.Models
{
    public class ClaimApproval
    {
        public int ApprovalID { get; set; }
        public int ClaimID { get; set; }
        public int CoordinatorID { get; set; }
        public string ApprovalStatus { get; set; }  // "Approved", "Rejected"
        public string ApprovalDate { get; set; }  // Store as string for simplicity
    }
}
