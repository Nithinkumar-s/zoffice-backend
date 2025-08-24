using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Employee
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string ShortName { get; set; }
        public required string LoginName { get; set; }
        public string? Designation { get; set; }
        public string? EmployeeCode { get; set; }
        public string? PFAccountNo { get; set; }
        public required string EmailId { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public string? AlternateNumber { get; set; }
        public string? Location { get; set; }
        public string? ReportTo { get; set; }
        public string? PasswordHash { get; set; }
        public string? Status { get; set; }
        public required DateTime JoiningDate { get; set; } 
        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LeavingDate { get; set; }
    }
}
