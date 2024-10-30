using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TcitBackend.Data;
using TcitBackend.Models;

namespace TcitBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(AppDbContext context) : ControllerBase
{

    // GET: api/Posts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        return await context.Posts.ToListAsync();
    }

    // POST: api/Posts
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        context.Posts.Add(post);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, post);
    }

    // DELETE: api/Posts/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        context.Posts.Remove(post);
        await context.SaveChangesAsync();

        return Ok(post);
    }
}
