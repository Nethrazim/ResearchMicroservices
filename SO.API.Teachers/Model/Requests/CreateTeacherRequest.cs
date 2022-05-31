namespace SO.API.Teachers.Model.Requests
{
    public class CreateTeacherRequest
    {
        public int InstitutionId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
    }
}
