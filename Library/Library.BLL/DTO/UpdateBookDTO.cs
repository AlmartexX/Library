﻿
namespace Library.BLL.DTO
{
    public class UpdateBookDTO
    {
      
        public int ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime BookBorrowedTime { get; set; }
        public DateTime BookReturnDeadline { get; set; }
    }
}
