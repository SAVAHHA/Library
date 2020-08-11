using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Library.Model
{
    [Table("Wardrobes")]
    public class Wardrobe
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ID_Flat { get; set; }
        public string FlatName { get; set; }
    }
}
