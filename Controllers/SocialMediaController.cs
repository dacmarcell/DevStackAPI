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
        public async Task<ActionResult<SocialMedia>> CreateSocialMedia(SocialMedia body){
            _dbContext.SocialMedias.Add(body);
            await _dbContext.SaveChangesAsync();
            return CreatedAtRoute("CreateSocialMedia", new { id = body.ID }, body);
        }

        [HttpPatch("{id}", Name = "UpdateSocialMedia")]
        public async Task<ActionResult<Profile>> UpdateSocialMedia(int id, [FromBody] UpdateSocialMediaDto body){
            var foundSocialMedia = await _dbContext.SocialMedias.FindAsync(id);
            if(foundSocialMedia is null){
                return NotFound("Social Media not found");
            }

            if(!string.IsNullOrWhiteSpace(body.Name.ToString())){
                foundSocialMedia.Name = body.Name;
            } else if (!string.IsNullOrWhiteSpace(body.ProfileID.ToString())){
                var foundProfile = await _dbContext.Profiles.FindAsync(body.ProfileID);

                if(foundProfile is null){
                    return NotFound("Profile not found");
                }

                foundSocialMedia.ProfileID = body.ProfileID;
                foundSocialMedia.Profile = foundProfile;
            } else if (!string.IsNullOrWhiteSpace(body.URL)){
                foundSocialMedia.URL = body.URL;
            }

            _dbContext.SocialMedias.Update(foundSocialMedia);
            await _dbContext.SaveChangesAsync();

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

            return NoContent();
        }
    }
}