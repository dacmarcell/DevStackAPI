using Microsoft.AspNetCore.Mvc;
using portfolio_api.Data;
using portfolio_api.Models;

namespace portfolio_api.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController: ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly ApplicationDBContext _dbContext;
        public ProfileController(ILogger<ProfileController> logger, ApplicationDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetProfile")]
        public IEnumerable<Profile> Get() 
        {
           return _dbContext.Profiles.ToList();
        }
    }
}