namespace TestCases;

public class TestCase3
{
    private RestClient client;

    [SetUp]
    public void Setup()
    {
        //CREATE RESTSHARP REST CLIENT INSTANCE
        client = new RestClient("https://localhost:5001");
    }

    [Test]
    public void VerifyGetAllBrands()
    {
        //REQUEST
        var request = new RestRequest("/GetAllBrands", Method.GET);

        //HEADER
        request.AddHeader("accept", "text/plain");

        //REQUEST
        var response = client.Execute(request);

        //VERIFY RESPONSE
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        //STORE RESPONSE BODY
        string content = response.Content;

        //RESPONSE BODY CONTENTS
        Assert.IsEmpty(content);
    }
}