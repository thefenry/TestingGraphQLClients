using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingGraphQLClients.GraphQueries;
using TestingGraphQLClients.Models.GraphResponses;
using GraphQLRequest = GraphQL.GraphQLRequest;

namespace TestingGraphQLClients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/Home
        [HttpGet]
        public async Task<GraphQLResponse<HomeResponse>> GetAsync()
        {
            string urlString = "{URL}";
            var token = "{Token}";

            GraphQLHttpClient graphQLClient = new GraphQLHttpClient(o =>
            {
                o.EndPoint = new Uri(urlString);
                o.JsonSerializer = new NewtonsoftJsonSerializer();
            });

            graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {token}");

            var HomeContentRequest = HomeQueries.GetHomeDetailQuery("2a8c32bb-3793-44d1-ab26-92ca24ae803d");


            var graphQLResponse = await graphQLClient.SendQueryAsync<HomeResponse>(HomeContentRequest);
            return graphQLResponse;
        }
    }

    
}
