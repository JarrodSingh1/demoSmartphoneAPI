using System;
using NUnit.Framework;
using RestSharp;

namespace APITest
{
    [TestFixture]
    public class Test
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            // Create a new RestSharp client instance
            client = new RestClient("https://localhost:5001");
        }

        [Test]
        public void TestAPI()
        {
            // Create a new RestSharp request instance
            RestRequest request = new RestRequest("/swagger/{api}", Method.GET);

            // Set the URL parameter
            request.AddUrlSegment("api", "GetAllProcessors");

            // Execute the request
            IRestResponse response = client.Execute(request);

            // Verify the response
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            // Get the response content
            string content = response.Content;

            // Perform assertions on the response content
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Contains("Snapdragon 710"));
        }
    }
}
