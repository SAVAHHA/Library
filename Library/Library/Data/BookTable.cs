using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Library.Data
{
    [Table("Books")]
    public class BookTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
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
