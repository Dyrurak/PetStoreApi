using Newtonsoft.Json;
using NUnit.Framework;
using PetStoreApi.Entities;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace PetStoreApi.Test
{
    [TestFixture]
    [Binding, Scope(Feature = "User")]
    public class UserTest : BaseTest
    {
        public const string BASE_URL = "https://petstore.swagger.io/v2";
        
        [StepDefinition(@"A new user is added properly")]
        public void CreateNewUser()
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("/user", Method.POST);
            request.AddJsonBody(new
            {
                id = "46",
                username = "sdsd",
                firstName = "eddsfd",
                lastName = "dfddesfs",
                email = "dwfwefd",
                password = "edfewfwew",
                phone = "12236544",
                userstatus = "13"
            }); 
            var response = client.Execute(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
        }


        [StepDefinition(@"User is got by using username")]
        public void GetUserByUsingUsername()
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("/user/sdsd", Method.GET);           
            var response = client.Get(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
            UserEntity user = JsonConvert.DeserializeObject<UserEntity>(response.Content);
            Assert.AreEqual("sdsd", user.Username, "Username is wrong! ");
        }

        [StepDefinition(@"User is updated properly")]
        public void UpdateUser()
        {
            var client = new RestClient("https://petstore.swagger.io/v2");
            var request = new RestRequest("/user/sdsd", Method.PUT);
            request.AddJsonBody(new
            {
                id = "23",
                username = "sdsd",
                firstName = "eddsfd",
                lastName = "dfddesfs",
                email = "dwfwefd",
                password = "edfewfwew",
                phone = "12236544",
                userstatus = "13"
            });
            var response = client.Execute(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
        }

        [StepDefinition(@"User is deleted properly")]
        public void DeleteUser()
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("/user/sdsd", Method.DELETE);
            var response = client.Execute(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
        }

        [StepDefinition(@"User logins to system properly")]
        public void LoginToSystemWithUsernameAndPassword()
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("/user/login", Method.GET);
            request.AddParameter("username", "sdsd", ParameterType.UrlSegment);
            request.AddParameter("password", "edfewfwew", ParameterType.UrlSegment);
            var response = client.Execute(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
        }

        [StepDefinition(@"User is logged out successfully")]
        public void LogoutUser()
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("/user/logout", Method.GET);            
            var response = client.Execute(request);
            CheckResponseStatus(HttpStatusCode.OK, response.StatusCode);
        }  
    }
}