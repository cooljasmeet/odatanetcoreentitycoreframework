
using Newtonsoft.Json;

namespace BookStore.Models
{
    // Book
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public Address Address { get; set; }
        [JsonIgnore]
        public Press Press { get; set; }
    }

}
