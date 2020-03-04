namespace TestingGraphQLClients.Models.GraphResponses
{
    public class HomeResponse
    {
        public HomeContent FindHomeContent { get; set; }
    }

    public class HomeContent
    {
        public string Id { get; set; }

        public HomeDetails FlatData { get; set; }
    }

    public class HomeDetails
    {
        public string PageTitle { get; set; }

        public string VideoTitle { get; set; }
    }
}
