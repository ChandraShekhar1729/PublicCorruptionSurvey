using PublicSurveyForm.Domain.Models;

namespace PublicSurveyForm.Services.InterfaceService
{
    public interface ISurveyService
    {
        public  Task<bool> AddUserFeedBack(PublicReview model);
    }
}
