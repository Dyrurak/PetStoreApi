using Newtonsoft.Json;

namespace PetStoreApi.Entities
{
    public class OrderEntity
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("petId", Required = Required.Always)]
        public int PetId { get; set; }

        [JsonProperty("quantity", Required = Required.Always)]
        public int Quantity { get; set; }

        [JsonProperty("shipDate", Required = Required.Always)]
        public string ShipDate { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; set; }

        [JsonProperty("complete", Required = Required.Always)]
        public bool Complete { get; set; }
    }
}