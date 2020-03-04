using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Threading.Tasks;
using TestingGraphQLClients.Models.GraphResponses;
using GraphQLRequest = GraphQL.GraphQLRequest;

namespace TestingGraphQLClients.Clients
{
    public class GraphQLClient
    {
        public void QueryGraph()
        {

        }

        public async Task<GraphQLResponse<HomeResponse>> SendRequestAsync(string urlString, string token, GraphQLRequest homeContentRequest)
        {
            GraphQLHttpClient graphQLClient = new GraphQLHttpClient(o =>
            {
                o.EndPoint = new Uri(urlString);
                o.JsonSerializer = new NewtonsoftJsonSerializer();
            });

            graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {token}");


            GraphQLResponse<HomeResponse> graphQLResponse = await graphQLClient.SendQueryAsync<HomeResponse>(homeContentRequest);
            return graphQLResponse;
        }
    }
}
