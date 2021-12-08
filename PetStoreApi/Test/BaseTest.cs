using NUnit.Framework;
using System.Net;

namespace PetStoreApi.Test
{
    public class BaseTest
    {
        public void CheckResponseStatus(HttpStatusCode expectedStatusCode, HttpStatusCode actualStatusCode)
        {
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, actualStatusCode, "HTTP 500 Internal Server error has occured! ");
            Assert.AreEqual(expectedStatusCode, actualStatusCode, "Actual response status is: " + actualStatusCode);
        }
    }
}