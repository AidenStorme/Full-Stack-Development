namespace PartialView9.ViewModels
{
    public class AdultVM
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime EnrollDate { get; set; }

        public string? DepartmentName { get; set; } // Dit veranderen van departmentId naar DepartmentName
        // Hij toont dit niet want het heeft een andere naam en type dan je entitydb adult.cs
    }
}
