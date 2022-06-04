namespace SO.API.Teachers.Model.Requests
{
    public class GetTeachersByInstitutionIdRequest
    {
        public int InstitutionId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
