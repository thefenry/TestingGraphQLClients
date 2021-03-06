﻿using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Threading.Tasks;
using GraphQLRequest = GraphQL.GraphQLRequest;

namespace TestingGraphQLClients.Clients
{
    public class GraphQLClient
    {
        public void QueryGraph() { }

        public async Task<GraphQLResponse<T>> SendRequestAsync<T>(string urlString, string token, GraphQLRequest contentRequest)
        {
            GraphQLHttpClient graphQLClient = new GraphQLHttpClient(o =>
            {
                o.EndPoint = new Uri(urlString);
                o.JsonSerializer = new NewtonsoftJsonSerializer();
            });

            graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {token}");
            
            GraphQLResponse<T> graphQLResponse = await graphQLClient.SendQueryAsync<T>(contentRequest);
            return graphQLResponse;
        }
    }
}
