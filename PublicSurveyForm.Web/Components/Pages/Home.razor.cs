using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using MudBlazor;
using PublicSurveyForm.Domain.Models;
using PublicSurveyForm.Web.Components.Dialogs;
using static MudBlazor.CategoryTypes;

namespace PublicSurveyForm.Web.Components.Pages
{
    public partial  class Home
    {
        [Inject]
        private IDialogService? DialogService { get; set; } 
        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
           // DialogService!.ShowAsync<MudDialogPage>("Simple Dialog");
            
        }

        public void ClickMe()
        {
            Console.WriteLine("This is chandu");
        }

    }
}
