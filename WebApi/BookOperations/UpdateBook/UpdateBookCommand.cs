using System;
using WebApi.Common;
using WebApi.DBOperations;
using System.Collections.Generic;
using System.Linq;


namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private void Handle(int id, Model modelBook)
        {
            var book = _dbContext.Books.SingleOrDefault(b=>b.Id == Model.id);
            if(book == null)
                throw new InvalidOperationException("Böyle bir kitap yok");
            
            book.GenreId = modelBook.GenreId != default ? modelBook.GenreId : book.GenreId;

            book.PageCount = modelBook.PageCount != default ? modelBook.PageCount : book.PageCount;

            book.PublishDate = modelBook.PublishDate != default ? modelBook.PublishDate : book.PublishDate;

            book.Title = modelBook.Title != default ? modelBook.Title : book.Title;

            _dbContext.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}   