using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Api.Data;
using Api.Models;
using Api.Dto;

namespace Api.Controllers;

[ApiController]
[Route("api/posts")]
[Produces("application/json")]
public class PostsController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public PostsController(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/posts
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PostReadDto>>> GetPosts(int limit = 100, int start = 0)
    {
        var posts = await _context.Posts.Where(p => p.Id > start)
            .OrderBy(p => p.Id)
            .Take(limit)
            .ToListAsync();

        return Ok(_mapper.Map<IEnumerable<PostReadDto>>(posts));
    }

    // GET: api/posts/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostReadDto>> GetPostById(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return NotFound();

        return Ok(_mapper.Map<PostReadDto>(post));
    }

    // PUT: api/posts/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutPost(int id, PostCreateDto postDto)
    {
        var post = _mapper.Map<Post>(postDto);
        _context.Entry(post).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PostExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/posts/localhost
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Post>> CreatePost(PostCreateDto postDto)
    {
        var post = _mapper.Map<Post>(postDto);
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        var postReadDto = _mapper.Map<PostReadDto>(post);

        return CreatedAtAction(nameof(GetPostById), new { id = postReadDto.Id }, postReadDto);
    }

    // DELETE: api/posts/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return NotFound();

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<PostReadDto>(post));
    }

    private bool PostExists(int id)
    {
        return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}

