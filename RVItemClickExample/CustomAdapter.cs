//
// CustomAdapter.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2019 Yauheni Pakala
//
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace RVItemClickExample
{
    // Ported from Java:
    // https://github.com/Hariofspades/CustomRecyclerView/blob/master/app/src/main/java/com/hariofspades/customrecyclerview/Adapter/CustomAdapter.java
    public class CustomAdapter : RecyclerView.Adapter
    {
        //Creating an arraylist of POJO objects
        private List<CustomPojo> _list_members = new List<CustomPojo>();
        private readonly LayoutInflater _inflater;
        private View _view;
        private MyViewHolder _holder;

        public CustomAdapter(Context context)
        {
            _inflater = LayoutInflater.From(context);
        }

        public override int ItemCount => _list_members.Count;

        //This method inflates view present in the RecyclerView
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            _view = _inflater.Inflate(Resource.Layout.custom_row, parent, false);
            _holder = new MyViewHolder(_view);
            return _holder;
        }

        //Binding the data using get() method of POJO object
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var list_items = _list_members[position];

            _holder.UserName.Text = list_items.Name;
            _holder.Content.Text = list_items.Content;
            _holder.Time.Text = list_items.Time;
        }

        //Setting the arraylist
        public void SetListContent(List<CustomPojo> list_members)
        {
            _list_members = list_members;
            NotifyItemRangeChanged(0, list_members.Count);
        }
    }

    public class MyViewHolder : RecyclerView.ViewHolder
    {
        public MyViewHolder(View itemView) : base(itemView)
        {
            UserName = itemView.FindViewById<TextView>(Resource.Id.user_name);
            Content = itemView.FindViewById<TextView>(Resource.Id.content);
            Time = itemView.FindViewById<TextView>(Resource.Id.time);
        }

        public TextView UserName { get; }
        public TextView Content { get; }
        public TextView Time { get; }
    }
}
