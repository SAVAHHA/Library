using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Book
    {
        public int ID_Book { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Illustrator { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public int ID_Flat { get; set; }
        public int ID_Wardrobe { get; set; }
        public int ID_Row { get; set; }
    }
}
