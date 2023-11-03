using GoodMarket.Models;
using GoodMarket.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController: ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public PostController(ILogger<PostController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpPost("/posts")]
    public Post Store(Post post)
    {
        _unitOfWork.PostRepository.Add(post);

        return post;
    }

    [HttpGet("/posts")]
    public IEnumerable<Post> GetAll()
    {
        return _unitOfWork.PostRepository.GetAll();
    }
}