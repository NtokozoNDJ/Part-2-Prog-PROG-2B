namespace Part_2_Prog.Models
{
    public class Claim
    {
        public Claim() { }  // Default constructor

        public int ClaimID { get; set; }
        public int LecturerID { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAmount => HoursWorked * HourlyRate;
        public string Status { get; set; }  // "Pending", "Approved", "Rejected"
        public string SupportingDocuments { get; set; }
        public string Date { get; set; }
    }
}
