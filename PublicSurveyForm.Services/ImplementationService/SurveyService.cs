using PublicSurveyForm.Domain.Models;
using PublicSurveyForm.Repository.Interface;
using PublicSurveyForm.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSurveyForm.Services.ImplementationService
{
    public class SurveyService(ISurveyRepository repository): ISurveyService    
    {
        private readonly ISurveyRepository _repository = repository;
        public async  Task<bool> AddUserFeedBack(PublicReview model)
        {
            return await _repository.AddUserFeedBack(model);
        }
    }
}
