using Microsoft.AspNetCore.Components;
using PublicSurveyForm.Domain.Models;
using PublicSurveyForm.Services.InterfaceService;

namespace PublicSurveyForm.Web.Components.Pages
{
    public partial  class SurveyForm
    {
        private DateTime _minDate;
        private DateTime _maxDate;
        private bool _submitted;
        private string? _errorMessage;

        [Inject]
        private  ISurveyService? SurveyService { get; set; }
        private PublicReview? Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Model = new();
            Model.DateOfBirth = DateTime.Now;
            _minDate = DateTime.Now.AddYears(-30);
            _maxDate = DateTime.Now.AddYears(+30);
        }

        private async Task HandleValidSubmit()
        {
            try
            {
                await SurveyService!.AddUserFeedBack(Model!);
                _submitted = true;
                Model = new();
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }
        }
    }
}
