namespace EmployeeAPI.Models
{
    public class Fee
    {
        public int FeeId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; } // Paid / Pending
    }

}
