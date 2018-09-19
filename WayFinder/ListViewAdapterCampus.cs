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
    public class ListViewAdapterCampus:BaseAdapter
    {
        private Activity activity;
        private List<Campus> lstCampus;
        public ListViewAdapterCampus(Activity activity, List<Campus> lstCampus)
        {
            this.activity = activity;
            this.lstCampus = lstCampus;
        }

        public override int Count
        {
            get
            {
                
                return lstCampus.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstCampus[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view_dataCampus, parent, false);

            var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtAddress = view.FindViewById<TextView>(Resource.Id.textView2);

            txtName.Text = lstCampus[position].Name;
            txtAddress.Text = "" + lstCampus[position].Address;

            return view;
        }
    }
}