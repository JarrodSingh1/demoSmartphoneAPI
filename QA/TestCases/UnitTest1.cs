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
        RestRequest request = new RestRequest("/GetAllProcessors", Method.GET);

        // Execute the request
        IRestResponse response = client.Execute(request);

        // Verify the response
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        // Get the response content
        string content = response.Content;

        List<Processor> processors = JsonSerializer.Deserialize<List<Processor>>(content);
        
        foreach(Processor x in processors)
        {
        
        int processorID = x.ProcessorID;
        string processName = x.ProcessorName;

        Assert.IsNotNull(processorID);
        Assert.IsNotEmpty(processName);
        Assert.IsTrue(processName.Contains("Snapdragon") || processName.Contains("MediaTek"));
        }
    }
}

public class Processor
{
    public int ProcessorID { get; set; }
    public string ProcessorName { get; set; }

}