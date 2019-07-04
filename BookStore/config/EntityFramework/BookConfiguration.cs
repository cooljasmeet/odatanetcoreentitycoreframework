using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.config.EntityFramework
{
    public class BookConfiguration
    {
        public BookConfiguration(EntityTypeBuilder<Book> entity)
        {
            entity.ToTable("Book", "dbo");
        }
    }
}