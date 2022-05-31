using SO.BusinessLayer.Entities.Responses;
using SO.BusinessLayer.Teachers.Entities.DTOs;

namespace SO.API.Teachers.Model.Responses
{
    public class GetTeachersByInstitutionIdResponse : EntitiesResponse<TeacherDTO>
    {
        public int TotalCount { get; set; }
    }
}
