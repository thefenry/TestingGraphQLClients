using GraphQL;

namespace TestingGraphQLClients.GraphQueries
{
    public static class HomeQueries
    {
        public static GraphQLRequest GetHomeDetailQuery(string id)
        {
           return new GraphQLRequest
            {
                Query = @"
                query HomeContent($id: Guid!) {
                    findHomeContent(id: $id) {
                        id
                        flatData {
                            pageTitle
                            videoTitle
                         }
                    }
                }",
                OperationName = "HomeContent",
                Variables = new
                {
                    id = id
                }
            };
        }
    }
}
