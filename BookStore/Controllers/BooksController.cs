using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ODataController
    {
        private BookStoreContext _db;

        public BooksController(BookStoreContext context)
        {
            _db = context;
            if (context.Book.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Book.Add(b);
                    context.Press.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Book);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_db.Book.FirstOrDefault(c => c.Id == key));
        }
        [EnableQuery]
        public IActionResult Post([FromBody]Book book)
        {
            _db.Book.Add(book);
            _db.SaveChanges();
            return Created(book);
        }
    }
}
