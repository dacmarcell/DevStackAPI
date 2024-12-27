using Microsoft.AspNetCore.Mvc;
using portfolio_api.Data;
using portfolio_api.Dtos.Profile;
using portfolio_api.Models;

namespace portfolio_api.Controllers{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController: ControllerBase{
        private readonly ILogger<ProfileController> _logger;
        private readonly ApplicationDBContext _dbContext;
        public ProfileController(ILogger<ProfileController> logger, ApplicationDBContext dbContext){
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetProfile")]
        public IEnumerable<Profile> Get(){
          return [.. _dbContext.Profiles];
        }

        [HttpGet("{id}", Name = "GetProfileById")]
        public async Task<ActionResult<Profile>> Get(int id){
            var profile = await _dbContext.Profiles.FindAsync(id);
            
            if (profile is null){
                return NotFound();
            }

            return profile;
        }

        [HttpPost(Name = "CreateProfile")]
        public async Task<ActionResult<Profile>> Post(Profile profile){
            _dbContext.Profiles.Add(profile);
            await _dbContext.SaveChangesAsync();
            return CreatedAtRoute("CreateProfile", new { id = profile.ID }, profile);
        }

        [HttpPatch("{id}", Name = "UpdateProfile")]
        public async Task<ActionResult<Profile>> Patch(int id, [FromBody] Profile body){
            var foundProfile = await _dbContext.Profiles.FindAsync(id);
            if(foundProfile is null){
                return NotFound();
            }

            if(!string.IsNullOrWhiteSpace(body.Name)){
                foundProfile.Name = body.Name;
            }

            if(!string.IsNullOrWhiteSpace(body.AboutMe)){
                foundProfile.AboutMe = body.AboutMe;
            }

            _dbContext.Profiles.Update(foundProfile);
            await _dbContext.SaveChangesAsync();

            return Ok(foundProfile);
        }

        [HttpDelete("{id}", Name = "DeleteProfile")]
        public async Task<ActionResult<Profile>> Delete(int id){
            var profile = await _dbContext.Profiles.FindAsync(id);
            if(profile is null){
                return NotFound();
            }

            _dbContext.Profiles.Remove(profile);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/social-media", Name = "ConnectOrDisconnectSocialMedia")]
        public async Task<ActionResult<Profile>> ConnectSocialMedia(int id, [FromBody] ConnectOrDisconnectSocialMediaDto body){
            var profile = await _dbContext.Profiles.FindAsync(id);
            if(profile is null){
                return NotFound();
            }

            var socialMedia = await _dbContext.SocialMedias.FindAsync(body.SocialMediaID);
            if(socialMedia is null){
                return NotFound();
            }

            if(body.Kind == SocialMediaKind.Connect){
                profile.SocialMedia.Add(socialMedia);
            } else if (body.Kind == SocialMediaKind.Disconnect) {
                profile.SocialMedia.Remove(socialMedia);
            } else {
                return BadRequest();
            }
            
            _dbContext.Profiles.Update(profile);

            await _dbContext.SaveChangesAsync();
            return Ok(profile);
        }
    }
}