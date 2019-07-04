using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BookStore.config.EntityFramework
{
    public class PressConfiguration
    {
        public PressConfiguration(EntityTypeBuilder<Press> entity)
        {
            entity.ToTable("Press", "dbo");
        }
    }
}
