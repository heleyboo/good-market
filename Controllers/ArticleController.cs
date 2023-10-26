using GoodMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace GoodMarket.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController
{
    private readonly IElasticClient _elasticClient;
    private readonly IWebHostEnvironment _hostingEnvironment;
    public ArticleController(IElasticClient elasticClient, IWebHostEnvironment hostingEnvironment) {
        _elasticClient = elasticClient;
        _hostingEnvironment = hostingEnvironment;
    }
    
    [HttpPost]
    public async Task < Article > Create(Article model) {
        try
        {
            var article = new Article()
            {
                Id = model.Id,
                Title = model.Title,
                Link = model.Link,
                Author = model.Author,
                AuthorLink = model.AuthorLink,
                PublishedDate = DateTime.Now
            };
            await _elasticClient.IndexDocumentAsync(article);
            model = new Article();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return model;
    }
}