using BookStore.Models;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.config.EntityFramework
{
    public class AddressConfiguration 
    {
        public AddressConfiguration(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address", "dbo");
        }
    }
}
