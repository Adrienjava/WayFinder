using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WayFinder.Resources.DataHelper;
using Android.Util;
using WayFinder.Resources.Model;
using System.Collections.Generic;
using static Android.Resource;
using System;

namespace WayFinder
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        //declaring all the list
        ListView lstData;
        List<Campus> lstSourceCampus = new List<Campus>();
        List<Buildings> lstSourceBuilding = new List<Buildings>();
        List<Rooms> lstSourceRooms = new List<Rooms>();

        //declaring the database 
        DataBase db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            

            db = new DataBase();

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Log.Info("DB_PATH", folder);

            lstData = FindViewById<ListView>(Resource.Id.listView);

            //Load the campus data when the listview starts
            LoadDataCampus();
            
    
            //here is my listView click event which has some bugs
            //I need to find another way to use click event
            //Because I can't have what I want from this click event
            lstData.ItemClick += (s, e) =>
            {
               //this FOR LOOP will return the building data according to the campus that I clicked
                for (int i = 0; i < lstData.Count; i++)
                {
                    if (e.Position == i)
                    {
                        LoadDataBuilding(i);
                       
                    }
                    
                }

            };

        }

       
        // this method will select the Campus Table and display the data in the listview
        private void LoadDataCampus()
        {
            lstSourceCampus = db.selectTableCampus();
            var adapter = new ListViewAdapterCampus(this, lstSourceCampus);
            lstData.Adapter = adapter;
        }



        // this method will select the Buildings Table according to the campusId and display the data in the listview
        private void LoadDataBuilding(int campusId)
        {
            lstSourceBuilding = db.selectBuildingsById(campusId);
            var adapter = new ListViewAdapterBuilding(this, lstSourceBuilding);
            lstData.Adapter = adapter;
        }


        // this method will select the Rooms Table according to the buildingId and display the data in the listview
        private void LoadDataRoom(int buildingId)
        {

            lstSourceRooms = db.selectRoomById(buildingId);
            var adapter = new ListViewAdapterRooms(this, lstSourceRooms);
            lstData.Adapter = adapter;
        }
    }
}