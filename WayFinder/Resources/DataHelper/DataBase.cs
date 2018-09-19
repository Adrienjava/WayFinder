using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;
using WayFinder.Resources.Model;

namespace WayFinder.Resources.DataHelper
{
    public class DataBase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    
        

        Campus campus = new Campus();

        //Create the database
        //I'm not using this method but it is here in case I need it
        public bool createDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
                {
                    connection.CreateTable<Campus>();
                    connection.CreateTable<Buildings>();
                    connection.CreateTable<Rooms>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        //Insert in table campus
        //I'm not using this method but it is here in case I need it
        public bool InsertIntoTableCampus(Campus campus)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
                {
                    connection.Insert(campus);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        //select Campus
        public List<Campus> selectTableCampus()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
                {
                    return connection.Table<Campus>().ToList();

                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        //Select Table Campus by Id Query
        public bool selectTableCampus(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
                {
                    connection.Query<Campus>("SELECT * FROM Campus Where Id= ?", id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }


        //retrieve building data according to the campusId which works like a foreign key
        public List<Buildings> selectBuildingsById(int campusId)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
                {
                    
                    return connection.Query<Buildings>("SELECT * FROM Buildings Where campusId= ?", campusId);
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        //retrieve building data according to the campusId which works like a foreign key
        public bool selectBuildingsById(Campus campus)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
                {

                     connection.Query<Buildings>("SELECT * FROM Buildings Where campusId= ?", campus.id);
                    return true;
                  
                    
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
                
            }
        }


        //retrieve rooms data according to the buildingId which works like a foreign key

        public List<Rooms> selectRoomById(int buildingId)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
                {
                    //return connection.Table<Buildings>().ToList();
                    return connection.Query<Rooms>("SELECT * FROM Rooms Where buildingId= ?", buildingId);
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool selectRoomById(Buildings building)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
                {
                    connection.Query<Rooms>("SELECT * FROM Rooms Where buildingId= ?", building.id);
                    return true;
                }
            }

            catch(SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }



        // Update data in table
        //public bool UpdateTableCampus(Campus campus)
        //{
        //    try
        //    {
        //        using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
        //        {
        //            connection.Query<Campus>("UPDATE Campus set Name=?, Address=?, Where Id=?", campus.Name, campus.Address, campus.id);
        //            return true;
        //        }
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        Log.Info("SQLiteEx", ex.Message);
        //        return false;
        //    }
        //}

        //delete data in table
        //public bool deleteTableCampus(Campus campus)
        //{
        //    try
        //    {
        //        using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Campus.db3")))
        //        {
        //            connection.Delete(campus);
        //            return true;
        //        }
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        Log.Info("SQLiteEx", ex.Message);
        //        return false;
        //    }
        //}

       

        
    }
}