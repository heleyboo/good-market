using Elasticsearch.Net;
using GoodMarket.Models;
using Nest;

namespace GoodMarket.Extension;

public static class ElasticSearchExtension {
    public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
    {
        var s = configuration.GetSection("ElasticSettings");
        var baseUrl = configuration["ElasticSettings:baseUrl"];
        var index = configuration["ElasticSettings:defaultIndex"];
        // var settings = new ConnectionSettings(new Uri(baseUrl ?? "")).PrettyJson().BasicAuthentication("elastic", "changeme").DefaultIndex(index);
        // settings.EnableApiVersioningHeader();
        // AddDefaultMappings(settings);
        
        var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
            .BasicAuthentication("elastic", "changeme") // Replace with your Elasticsearch credentials
            .DefaultIndex(index); // Set the default index

        
        var client = new ElasticClient(connectionSettings);
        services.AddSingleton < IElasticClient > (client);
        CreateIndex(client, index);
    }
    private static void AddDefaultMappings(ConnectionSettings settings) {
        settings.DefaultMappingFor < Article > (m => m.Ignore(p => p.Link).Ignore(p => p.AuthorLink));
    }
    private static void CreateIndex(IElasticClient client, string indexName) {
        var createIndexResponse = client.Indices.Create(indexName, index => index.Map < Article > (x => x.AutoMap()));
    }
}