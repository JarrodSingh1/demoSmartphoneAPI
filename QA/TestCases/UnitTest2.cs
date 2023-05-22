namespace YourNamespace
{
    [TestFixture]
    public class ApiTests
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            //CREATE RESTSHARP REST CLIENT INSTANCE
            client = new RestClient("https://localhost:5001");
        }

        [Test]
        public void CreateProcessorTest()
        {
            //REQUEST
            var request = new RestRequest("/AddProcessor", Method.POST);
            
            //HEADER
            request.AddHeader("accept", "*/*");
            request.AddHeader("Content-Type", "application/json");

            //BODY
            request.AddJsonBody(new { processorID = "0", processorName = "TestProcessor" });

            //EXECUTE REQUEST
            var response = client.Execute(request);

            //ASSERTIONS
            Assert.AreEqual(201, (int)response.StatusCode);
            Assert.IsTrue(response.IsSuccessful); 
            
            //RESPONSE BODY ASSERTION
            Assert.That(response.Content, Is.EqualTo("New process added."));
        }
    }
}
