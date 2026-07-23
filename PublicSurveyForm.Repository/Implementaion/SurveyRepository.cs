using Dapper;
using PublicSurveyForm.Domain.Models;
using PublicSurveyForm.Repository.DBContext;
using PublicSurveyForm.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PublicSurveyForm.Repository.Implementaion
{
    public  class SurveyRepository(DatabaseDapperContext context) : ISurveyRepository
    {
        private readonly DatabaseDapperContext _context = context;

        public async Task<bool> AddUserFeedBack(PublicReview model)
        {
            try
            {
                string connectionString = string.Empty;
                model.DateOfBirth = DateTime.UtcNow.Date;
                using var connection = _context.CreateConnection();
                connectionString = connection.ConnectionString;
                var result = await connection.ExecuteAsync(
                    "[dbo].[InsertCorruptionSurveyResponse]",
                    new { model.FullName, model.FirstName, model.LastName, model.PlaceLiving, model.Email, model.CorruptionInIndia,model.DateOfBirth ,model.IpAddress,model.UserAgent,model.BrowserName},
                    commandType: CommandType.StoredProcedure);

                if (result > 0) { return true; } else { return false; }
            }
            catch(Exception ex)
            {
                var error = ex.Message;
                Console.WriteLine(error);
            }

            return false;
        }
    }
}
