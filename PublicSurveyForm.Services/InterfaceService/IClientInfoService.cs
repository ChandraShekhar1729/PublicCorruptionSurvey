using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSurveyForm.Services.InterfaceService
{
    public interface IClientInfoService
    {
        public  Task<string> GetIpAddress();
        public  Task<string> GetBrowserName();
    }
}
