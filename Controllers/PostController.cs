using Microsoft.AspNetCore.Mvc;
using portfolio_api.Data;
using portfolio_api.Models;

namespace portfolio_api.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController: ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly ApplicationDBContext _dbContext;
        public PostController(ILogger<PostController> logger, ApplicationDBContext dbContext){
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetPosts")]
        public ActionResult<Post> GetPosts(){
            var posts = _dbContext.Posts;
            return Ok(posts);
        }

        [HttpGet("{id}", Name = "GetPostByID")]
        public async Task<ActionResult<Post>> GetPostByID(int id){
            var posts = await _dbContext.Posts.FindAsync(id);
            if (posts is null){
                return NotFound("Post not found");
            }

            return Ok(posts);
        }

        [HttpPost(Name = "CreatePost")]
        public async Task<ActionResult<Post>> CreatePost(Post post){
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                "Post with ID {ID} created at {CreatedAt}",
                post.ID,
                DateTime.Now
            );

            return CreatedAtRoute("CreatePost", new { id = post.ID }, post);
        }

        [HttpPatch("{id}", Name = "UpdatePost")]
        public async Task<ActionResult<Post>> UpdatePost(int id, [FromBody] Post body){
            var foundPost = await _dbContext.Posts.FindAsync(id);
            if(foundPost is null)
            {
                return NotFound("Post not found");
            }

            var foundProfile = await _dbContext.Profiles.FindAsync(body.ProfileID);
            if(foundProfile is null)
            {
                return NotFound("Profile not found");
            }

            if(!string.IsNullOrWhiteSpace(body.Title)){
                foundPost.Title = body.Title;
            }
            if (!string.IsNullOrWhiteSpace(body.Content)){
                foundPost.Content = body.Content;
            }
            if (!string.IsNullOrWhiteSpace(body.ProfileID.ToString())){
                foundPost.ProfileID = body.ProfileID;
            }

            foundPost.Profile = foundProfile;

            _dbContext.Posts.Update(foundPost);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                "Post with ID {ID} updated at {UpdatedAt}",
                foundPost.ID,
                DateTime.Now
            );

            return Ok(foundPost);
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<ActionResult<Post>> DeletePost(int id){
            var post = await _dbContext.Posts.FindAsync(id);
            if(post is null){
                return NotFound("Post not found");
            }

            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                "Post with ID {ID} deleted at {DeletedAt}",
                post.ID,
                DateTime.Now
            );

            return NoContent();
        }
    }
}