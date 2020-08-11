using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Library.Model
{
    [Table("Flats")]
    public class Flat
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
