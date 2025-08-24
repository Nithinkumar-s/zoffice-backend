namespace backend.Models.ResponseModels
{
    public class EmployeeResponse
    {
        public Guid Guid { get; set; }
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string LoginName { get; set; }
        public string Designation { get; set; }
        public string EmployeeCode { get; set; }
        public string PFAccountNo { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string AlternateNumber { get; set; }
        public string Location { get; set; }
        public string ReportTo { get; set; }
        public string Status { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public bool HasSignedHRPolicy { get; set; }
        public bool HasSignedInfoSecPolicy { get; set; }
        public bool HasSignedRulesOfBehaviour { get; set; }
    }
}
