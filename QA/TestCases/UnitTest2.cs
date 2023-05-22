namespace TestCases;

public class TestCase2
{
    private RestClient client;

    [SetUp]
    public void Setup()
    {
        //RestSharp client instance
        client = new RestClient("https://localhost:5001");
    }

    [Test]
    public void TestAPI()
    {
        //CREATE REQUEST INSTANCE
        RestRequest request = new RestRequest("/GetAllProcessors", Method.GET);

        //HEADER
        request.AddHeader("accept", "text/plain");
        
        //EXECUTE Reqquest
        IRestResponse response = client.Execute(request);

        //VERIFY STATUS CODE
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        //RESPONSE
        string content = response.Content;

        List<Processor> processors = JsonSerializer.Deserialize<List<Processor>>(content);
        
        foreach(Processor x in processors)
        {
        
        int processorID = x.ProcessorID;
        string processName = x.ProcessorName;

        //RESPONSE BODY
        Assert.IsNotNull(processorID);
        Assert.IsNotEmpty(processName);

        //VERIFY CORRECTNESS
        Assert.IsTrue(processName.Contains("Snapdragon") || processName.Contains("MediaTek"));
        }
    }
}

public class Processor
{
    public int ProcessorID { get; set; }
    public string ProcessorName { get; set; }

}