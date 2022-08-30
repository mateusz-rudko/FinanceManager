using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inzynierka.Models
{
    public class Notifications
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
    }
}
