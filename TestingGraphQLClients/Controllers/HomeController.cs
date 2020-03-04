using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GraphQLRequest = GraphQL.GraphQLRequest;

namespace TestingGraphQLClients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/Home
        [HttpGet]
        public async Task<GraphQLResponse<PersonAndFilmsResponse>> GetAsync()
        {
            //var graphQLClient = new GraphQLHttpClient("https://swapi.apis.guru/");

            GraphQLHttpClient graphQLClient = new GraphQLHttpClient(o => { o.EndPoint = new Uri("https://swapi.apis.guru/"); 
                o.JsonSerializer = new NewtonsoftJsonSerializer(); });

            var personAndFilmsRequest = new GraphQLRequest
            {
                Query = @"
                query PersonAndFilms($id: ID) {
                    person(id: $id) {
                        name
                        filmConnection {
                            films {
                                title
                            }
                        }
                    }
                }",
                OperationName = "PersonAndFilms",
                Variables = new
                {
                    id = "cGVvcGxlOjE="
                }
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<PersonAndFilmsResponse>(personAndFilmsRequest);
            return graphQLResponse;
        }
    }

    public class PersonAndFilmsResponse
    {
        public PersonContent Person { get; set; }

        public class PersonContent
        {
            public string Name { get; set; }
            public FilmConnectionContent FilmConnection { get; set; }

            public class FilmConnectionContent
            {
                public List<FilmContent> Films { get; set; }

                public class FilmContent
                {
                    public string Title { get; set; }
                }
            }
        }
    }
}
