using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestCases;

public class Tests
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
        RestRequest request = new RestRequest("https://localhost:5001/GetAllProcessors", Method.GET);

        // Execute the request
        IRestResponse response = client.Execute(request);

        // Verify the response
        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

        // Get the response content
        string content = response.Content;

        List<Processor> processor = JsonConvert.DeserializeObject<List<Processor>>(content);
        // Perform assertions on the response content
        Assert.IsNotNull(content);
        Assert.IsTrue(content.Contains("Snapdragon 710"));
        }
}

public class Processor
{
    public int ProcessorID { get; set; }
    public string ProcessorName { get; set; }

}