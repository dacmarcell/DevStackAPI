using Microsoft.AspNetCore.Mvc;
using portfolio_api.Data;
using portfolio_api.Dtos.ProjectDtos;
using portfolio_api.Models;

namespace portfolio_api.Controllers {
    [ApiController]
    [Route("api/project")]
    public class ProjectController : ControllerBase 
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly ApplicationDBContext _dbContext;
        public ProjectController(ILogger<ProjectController> logger, ApplicationDBContext dbContext){
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetProject")]
        public ActionResult<Project> GetProject() {
            var projects = _dbContext.Projects;
            return Ok(projects);
        }

        [HttpGet("{id}", Name = "GetProjectById")]
        public async Task<ActionResult<Project>> GetProjectById(int id) {
            var project = await _dbContext.Projects.FindAsync(id);
            if (project == null) {
                return NotFound("Project not found");
            }

            return Ok(project);
        }

        [HttpPost(Name = "CreateProject")]
        public async Task<ActionResult<Project>> CreateProject([FromBody] CreateProjectDto body) {
            if (string.IsNullOrWhiteSpace(body.Name)) {
                return BadRequest("Name is required");
            } else if (string.IsNullOrWhiteSpace(body.Description)) {
                return BadRequest("Description is required");
            } else if (string.IsNullOrWhiteSpace(body.ProfileID.ToString())) {
                return BadRequest("URL is required");
            }

            var profile = await _dbContext.Profiles.FindAsync(body.ProfileID);
            if(profile is null) {
                return NotFound("Profile not found");
            }

            var project = new Project {
                Name = body.Name,
                Description = body.Description,
                GithubURL = body.GithubURL ?? "",
                DeployURL = body.DeployURL ?? "",
                ProfileID = body.ProfileID,
                Profile = profile
            };

            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                "Project with ID {ID} created at {CreatedAt}",
                project.ID,
                DateTime.Now
            );

            return CreatedAtRoute("CreateProject", new { id = project.ID }, project);
        }

        [HttpPatch("{id}", Name = "UpdateProject")]
        public async Task<ActionResult<Project>> UpdateProject(int id, [FromBody] UpdateProjectDto body)
        {
            var foundProject = await _dbContext.Projects.FindAsync(id);
            if(foundProject == null)
            {
                return NotFound("Project not found");
            }

            var foundProfile = await _dbContext.Profiles.FindAsync(body.ProfileID);
            if(foundProfile == null)
            {
                return NotFound("Profile not found");
            }

            _logger.LogInformation("body info: {body}", body.GithubURL);

            if(!string.IsNullOrWhiteSpace(body.Name)){
                foundProject.Name = body.Name;
            }
            if (!string.IsNullOrWhiteSpace(body.Description)){
                foundProject.Description = body.Description;
            }
            if (!string.IsNullOrWhiteSpace(body.GithubURL)){
                foundProject.GithubURL = body.GithubURL;
            }
            if (!string.IsNullOrWhiteSpace(body.DeployURL)){
                foundProject.DeployURL = body.DeployURL;
            }
            if (!string.IsNullOrWhiteSpace(body.ProfileID.ToString())){
                foundProject.ProfileID = (int)body.ProfileID;
            }
            if (foundProfile != null){
                foundProject.Profile = foundProfile;
            }

            _dbContext.Projects.Update(foundProject);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                "Project with ID {ID} updated at {UpdatedAt}",
                foundProject.ID,
                DateTime.Now
            );

            return Ok(foundProject);
        }

        [HttpDelete("{id}", Name = "DeleteProject")]
        public async Task<ActionResult<Project>> DeleteProject(int id){
            var project = await _dbContext.Projects.FindAsync(id);
            if(project is null){
                return NotFound("Project not found");
            }

            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
            
            _logger.LogInformation(
                "Project with ID {ID} deleted at {DeletedAt}",
                project.ID,
                DateTime.Now
            );

            return NoContent();
        }
    }
}