using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PublicSurveyForm.Repository.DBContext
{
    public class DatabaseDapperContext
    {
        private readonly IConfiguration? _configuration;
        public readonly string _connectionString; 



        public DatabaseDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration!.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()=> new SqlConnection(_connectionString);
    }
}
