using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace WayFinder.Resources.Model
{
    [Table("Campus")]
    public class Campus
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string drawingName { get; set; }
    }

    [Table("Buildings")]
    public class Buildings
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }

        public string Name { get; set; }

        public string location { get; set; }

        public string drawingName { get; set; }

        [ForeignKey(typeof(Campus))]
        public int campusId { get; set; }
    }

    [Table("Rooms")]
    public class Rooms
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }

        public string Name { get; set; }

        public int floor { get; set; }

        public string drawingName { get; set; }

        [ForeignKey(typeof(Buildings))]
        public int buildingId { get; set; }
    }
}