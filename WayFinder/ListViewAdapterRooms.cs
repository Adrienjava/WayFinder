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

using Java.Lang;
using WayFinder.Resources.Model;

namespace WayFinder
{
    public class ListViewAdapterRooms:BaseAdapter
    {
        private Activity activity;
        private List<Rooms> lstRoom;

        public ListViewAdapterRooms(Activity activity, List<Rooms> lstRoom)
        {
            this.activity = activity;
            this.lstRoom = lstRoom;
        }

        public override int Count
        {
            get
            {

                return lstRoom.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstRoom[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view_dataRooms, parent, false);

            var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtFloor = view.FindViewById<TextView>(Resource.Id.textView2);

            txtName.Text = lstRoom[position].Name;
            txtFloor.Text = "" + lstRoom[position].floor;

            return view;
        }
    }
}
