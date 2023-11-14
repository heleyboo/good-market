namespace GoodMarket.Models;

public class Post
{
    public int Id { get; set; }
    public string ThumbnailUrl { get; set; }
    public string Title { get; set; }
    public long Price { get; set; }
    public string Description { get; set; }
}