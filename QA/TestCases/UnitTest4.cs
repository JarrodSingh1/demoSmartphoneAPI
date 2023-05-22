namespace TestCases;

public class TestCase4
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
        RestRequest request = new RestRequest("/GetAllSmartphones", Method.GET);

        //HEADER
        request.AddHeader("accept", "text/plain");

        //EXECUTE Reqquest
        IRestResponse response = client.Execute(request);

        //VERIFY STATUS CODE
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        //RESPONSE
        string content = response.Content;

        List<SmartPhones> smartphone = JsonSerializer.Deserialize<List<SmartPhones>>(content);
        
        foreach(SmartPhones x in smartphone)
        {
        
        string modelID = SmartPhones.modelID;

        //RESPONSE BODY
        Assert.IsNotNull(processorID);
        
        
        //NOT EMPTY
        Assert.IsNotEmpty(processName);

        //VERIFY CORRECTNESS
        Assert.IsTrue(processName.Contains("Snapdragon") || processName.Contains("MediaTek"));
        }
    }
}

public class SmartPhones
{
    public string Model_ID { get; set; }
    public string Model_Name { get; set; }
    public int Spec_ID { get; set; }
    public int Brand_ID { get; set; }
    public string Brand_Name { get; set; }
    


}