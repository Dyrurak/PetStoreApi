using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace PetStoreApi.Test
{
    [TestFixture]
    [Binding, Scope(Feature = "Store")]
    public class StoreTest : BaseTest
    {
        public const string BASE_URL = "https://petstore.swagger.io/v2";

        [StepDefinition(@"Pet inventories are returned by status")]
        public void GetInventoriesByStatus()
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("/store/inventory", Method.GET);
            var response = client.Get(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
        }

        [StepDefinition(@"Order is placed for a pet")]
        public void OrderForAPet()
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("/store/order", Method.POST);
            request.AddJsonBody(new
            {
                id = 1,
                petId = 1,
                quantity = 0,
                shipDate = "2021-12-07T21:11:42.535Z",
                status= "placed",
                complete= true
            });
            var response = client.Execute(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
        }

        [StepDefinition(@"Order is found by Id")]
        public void FindOrderById()
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("/store/order/{orderId}", Method.GET).AddUrlSegment("orderId", "1");            
            var response = client.Get(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
        }

        [StepDefinition(@"Order is deleted by Id")]
        public void DeleteOrderById()
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("/store/order/{orderId}", Method.DELETE).AddUrlSegment("orderId", "1");
            var response = client.Execute(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
        }
    }
}