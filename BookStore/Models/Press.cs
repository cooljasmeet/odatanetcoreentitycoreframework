using BookStore.Enums;
using Newtonsoft.Json;

namespace BookStore.Models
{
    // Press
    public class Press
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
