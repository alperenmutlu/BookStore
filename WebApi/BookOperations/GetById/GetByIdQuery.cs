using System;
using WebApi.Common;
using WebApi.DBOperations;
using System.Collections.Generic;
using System.Linq;


namespace WebApi.BookOperations.GetById
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public BookViewModel Handle(int id)
        {
            var book = _dbContext.Books.Where(b=>b.Id == id).SingleOrDefault();
            BookViewModel vm = new BookViewModel();
                vm.Title = book.Title;
                vm.PageCount = book.PageCount;
                vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
                vm.Genre = ((GenreEnum)book.GenreId).ToString();
            
                       
            return vm;
        }

        public class BookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}