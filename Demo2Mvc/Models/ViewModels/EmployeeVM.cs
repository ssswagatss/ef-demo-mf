namespace Demo2Mvc.Models.ViewModels
{
    public class EmployeeVM
    {
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public int? DeptId { get; set; }

        public string DepartmentName { get; set; }
        public string[] Languages { get; set; }
    }
}
