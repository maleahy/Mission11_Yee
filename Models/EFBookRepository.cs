namespace Mission11_Yee.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookstoreContext _context;

        public EFBookRepository(BookstoreContext temp) {
            _context = temp;
        }

        public List<Book>Books => _context.Books.ToList();
    }
}
