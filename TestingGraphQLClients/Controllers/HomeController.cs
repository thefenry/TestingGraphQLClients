using System.Threading.Tasks;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using TestingGraphQLClients.Clients;
using TestingGraphQLClients.GraphQueries;
using TestingGraphQLClients.Models.GraphResponses;

namespace TestingGraphQLClients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private GraphQLClient _client;

        public HomeController()
        {
            _client = new GraphQLClient();
        }

        // GET: api/Home
        [HttpGet]
        public async Task<GraphQLResponse<HomeResponse>> GetAsync()
        {
            string urlString = "{URL}";
            var token = "{Token}";

            var homeContentRequest = HomeQueries.GetHomeDetailQuery("2a8c32bb-3793-44d1-ab26-92ca24ae803d");

            return await _client.SendRequestAsync(urlString, token, homeContentRequest);
        }
    }
}
