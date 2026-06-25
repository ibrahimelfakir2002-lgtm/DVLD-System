namespace DvldShared
{
    public class clsLicenseDetailsDTO
    {


        
            public int LicenseID { get; set; }
            public string ClassName { get; set; }
            public string FullName { get; set; }
            public string NationalNo { get; set; }
            public string Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int DriverID { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string IssueReason { get; set; }
            public string IsActive { get; set; }
            public string Notes { get; set; }
            public string IsDetained { get; set; }
        
    }
}
