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
using WayFinder.Resources.Model;

namespace WayFinder
{
    public class ListViewAdapterBuilding: BaseAdapter
    {


        private Activity activity;
        private List<Buildings> lstBuilding;

        public ListViewAdapterBuilding(Activity activity, List<Buildings> lstBuilding)
        {
            this.activity = activity;
            this.lstBuilding = lstBuilding;
        }

        public override int Count
        {
            get
            {

                return lstBuilding.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstBuilding[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view_dataBuilding, parent, false);

            var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtAddress = view.FindViewById<TextView>(Resource.Id.textView2);

            

            txtName.Text = lstBuilding[position].Name;
            txtAddress.Text = "" + lstBuilding[position].location;


            

            return view;
        }
    }
}