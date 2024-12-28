using Microsoft.AspNetCore.Mvc;
using portfolio_api.Data;
using portfolio_api.Dtos;
using portfolio_api.Models;

namespace portfolio_api.Controllers{
    [ApiController]
    [Route("api/social-media")]
    public class SocialMediaController: ControllerBase{
        private readonly ILogger<SocialMediaController> _logger;
        private readonly ApplicationDBContext _dbContext;
        public SocialMediaController(ILogger<SocialMediaController> logger, ApplicationDBContext dbContext){
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetSocialMedia")]
        public ActionResult<SocialMedia> GetSocialMedia(){
            var socialMedias = _dbContext.SocialMedias;
            return Ok(socialMedias);
        }

        [HttpGet("{id}", Name = "GetSocialMediaById")]
        public async Task<ActionResult<SocialMedia>> GetSocialMediaById(int id){
            var socialMedia = await _dbContext.SocialMedias.FindAsync(id);
            if (socialMedia is null){
                return NotFound("SocialMedia not found");
            }

            return Ok(socialMedia);
        }

        [HttpPost(Name = "CreateSocialMedia")]
        public async Task<ActionResult<SocialMedia>> CreateSocialMedia([FromBody] CreateSocialMediaDto body){
            if(string.IsNullOrWhiteSpace(body.Name.ToString())){
                return BadRequest("Name is required");
            } else if (string.IsNullOrWhiteSpace(body.ProfileID.ToString())) {
                return BadRequest("ProfileID is required");
            } else if (string.IsNullOrWhiteSpace(body.URL)){
                return BadRequest("URL is required");
            }

            var foundProfile = await _dbContext.Profiles.FindAsync(body.ProfileID);
            if(foundProfile is null){
                return NotFound("Profile not found");
            }

            bool isValidSocialMediaEnum = Enum.TryParse<Enums.SocialMediaNames>(body.Name.ToString(), out var validSocialMediaName);


            if(isValidSocialMediaEnum){
                var socialMedia = new SocialMedia{
                    Name = validSocialMediaName,
                    ProfileID = body.ProfileID,
                    Profile = foundProfile,
                    URL = body.URL
                };

                _dbContext.SocialMedias.Add(socialMedia);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation(
                    "Social Media with ID {ID} has been created at {CreatedAt}",
                    socialMedia.ID,
                    DateTime.Now
                );

                return CreatedAtRoute("CreateSocialMedia", new { id = socialMedia.ID }, body);
            } else {
                return BadRequest("Invalid Name");
            }
        }

        [HttpPatch("{id}", Name = "UpdateSocialMedia")]
        public async Task<ActionResult<Profile>> UpdateSocialMedia(int id, [FromBody] UpdateSocialMediaDto body){
            var foundSocialMedia = await _dbContext.SocialMedias.FindAsync(id);
            if(foundSocialMedia is null){
                return NotFound("Social Media not found");
            }

            if(!string.IsNullOrWhiteSpace(body.Name.ToString())){
                bool isValidSocialMediaEnum = Enum.TryParse<Enums.SocialMediaNames>(body.Name.ToString(), out var validSocialMediaName);

                if(isValidSocialMediaEnum){
                    foundSocialMedia.Name = validSocialMediaName;
                } else {
                    return BadRequest("Invalid Name");
                }
            } else if (body.ProfileID.HasValue){
                var foundProfile = await _dbContext.Profiles.FindAsync(body.ProfileID);

                if(foundProfile != null){
                    foundSocialMedia.ProfileID = body.ProfileID.Value;
                    foundSocialMedia.Profile = foundProfile;
                } else {
                    return NotFound("Profile not found");
                }
            } else if (!string.IsNullOrWhiteSpace(body.URL)){
                foundSocialMedia.URL = body.URL;
            }

            _dbContext.SocialMedias.Update(foundSocialMedia);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                "Social Media with ID {ID} has been updated at {UpdatedAt}",
                foundSocialMedia.ID,
                DateTime.Now
            );

            return Ok(foundSocialMedia);
        }

        [HttpDelete("{id}", Name = "DeleteSocialMedia")]
        public async Task<ActionResult<Profile>> DeleteSocialMedia(int id){
            var socialMedia = await _dbContext.SocialMedias.FindAsync(id);
            if(socialMedia is null){
                return NotFound("SocialMedia not found");
            }

            _dbContext.SocialMedias.Remove(socialMedia);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                "Social Media with ID {ID} has been deleted at {DeletedAt}",
                socialMedia.ID,
                DateTime.Now
            );

            return NoContent();
        }
    }
}