using PublicSurveyForm.Domain.Models;

namespace PublicSurveyForm.Repository.Interface
{
    public interface ISurveyRepository
    {
        public Task<bool> AddUserFeedBack(PublicReview model);
    }
}
