using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DremovExam.Models
{
    public class Number
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Fact { get; set; }
    }
}
