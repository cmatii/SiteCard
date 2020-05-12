﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Models
{


    public class Cuestionario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        public DateTime Date { get; set; }
    }
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Note(string text, DateTime date)
        {
            Text = text;
            Date = date;
        }

    
        public Note()
        {
        }
    }
}
