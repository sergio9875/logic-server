using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace testWorkLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
     

        private readonly ILogger<User> _logger;

        private readonly IConfiguration _config;

        public UserController(ILogger<User> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

        }
        public IDbConnection Connection
        {

            get
            {
                return new SqlConnection(_config.GetConnectionString("ConnectionString1"));
            }
        }


        [HttpGet]
        public List<User> Get()
        {
            using (IDbConnection db = Connection)
            {

                var result = db.Query<User>("SELECT * FROM Users").ToList();
                return result;
               
            }

         
        }
    }
}

