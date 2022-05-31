namespace SO.API.Teachers.Model.Requests
{
    public class GetTeachersByInstitutionIdRequest
    {
        public int InstitutionId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
