

namespace Library.DAL.Modell
{
    public class Book
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime BookBorrowedTime { get; set; }
        public DateTime BookReturnDeadline { get; set; }
    }
}
