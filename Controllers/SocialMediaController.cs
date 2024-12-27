using Microsoft.AspNetCore.Mvc;
using portfolio_api.Data;
using portfolio_api.Dtos;
using portfolio_api.Models;

namespace portfolio_api.Controllers{
    [ApiController]
    [Route("api/social-media")]
    public class SocialMediaController: ControllerBase{
        private readonly ILogger<ProfileController> _logger;
        private readonly ApplicationDBContext _dbContext;
        public SocialMediaController(ILogger<ProfileController> logger, ApplicationDBContext dbContext){
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

        // [HttpPost("{id}/social-media", Name = "ConnectOrDisconnectSocialMedia")]
        // public async Task<ActionResult<Profile>> ConnectOrDisconnectSocialMedia(int id, [FromBody] ConnectOrDisconnectSocialMediaDto body){
        //     var profile = await _dbContext.Profiles
        //         .Include(profile => profile.SocialMedia)
        //         .FirstOrDefaultAsync(profile => profile.ID == id);
                
        //     if (profile is null) {
        //         return NotFound("Profile not found");
        //     }

        //     var socialMedia = await _dbContext.SocialMedias.FindAsync(body.SocialMediaID);
        //     if (socialMedia is null) {
        //         return NotFound("Social Media not found");
        //     }

        //     if (body.Kind == SocialMediaKind.Connect) {
        //         profile.SocialMedia.Add(socialMedia);
        //     } else if (body.Kind == SocialMediaKind.Disconnect) {
        //         profile.SocialMedia.Remove(socialMedia);
        //     } else {
        //         return BadRequest("Invalid Kind");
        //     }
            
        //     _dbContext.Profiles.Update(profile);

        //     await _dbContext.SaveChangesAsync();
        //     return Ok(profile);
        // }

        [HttpPatch("{id}", Name = "UpdateSocialMedia")]
        public async Task<ActionResult<Profile>> UpdateSocialMedia(int id, [FromBody] UpdateSocialMediaDto body){
            var foundSocialMedia = await _dbContext.SocialMedias.FindAsync(id);
            if(foundSocialMedia is null){
                return NotFound("Social Media not found");
            }

            if(!string.IsNullOrWhiteSpace(body.Name.ToString())){
                foundSocialMedia.Name = body.Name;
            } else if (!string.IsNullOrWhiteSpace(body.ProfileID.ToString())){
                foundSocialMedia.ProfileID = body.ProfileID;
            } else if (!string.IsNullOrWhiteSpace(body.URL)){
                foundSocialMedia.URL = body.URL;
            }

            _dbContext.SocialMedias.Update(foundSocialMedia);
            await _dbContext.SaveChangesAsync();

            return Ok(foundSocialMedia);
        }

        [HttpDelete("{id}", Name = "DeleteProfile")]
        public async Task<ActionResult<Profile>> DeleteProfile(int id){
            var profile = await _dbContext.Profiles.FindAsync(id);
            if(profile is null){
                return NotFound("Profile not found");
            }

            _dbContext.Profiles.Remove(profile);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}