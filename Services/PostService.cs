using Microsoft.EntityFrameworkCore;
using TcitBackend.Data;
using TcitBackend.Models;

namespace TcitBackend.Services;

public class PostService(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<List<Post>> GetAllPostsAsync() => await _dbContext.Posts.ToListAsync();

    public async Task<Post> CreatePostAsync(Post post)
    {
        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> DeletePostAsync(int id)
    {
        var post = await _dbContext.Posts.FindAsync(id);
        if (post != null)
        {
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }
        return post;
    }
}
