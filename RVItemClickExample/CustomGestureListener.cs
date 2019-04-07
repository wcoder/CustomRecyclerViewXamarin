//
// CustomGestureListener.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2019 Yauheni Pakala
//
using Android.Support.V7.Widget;
using Android.Views;

namespace RVItemClickExample
{
    // Ported from Java:
    // https://github.com/Hariofspades/CustomRecyclerView/blob/master/app/src/main/java/com/hariofspades/customrecyclerview/MainActivity.java#L160-L172
    public class CustomGestureListener : GestureDetector.SimpleOnGestureListener
    {
        private readonly RecyclerView _recyclerView;
        private readonly IClickListener _clickListener;

        public CustomGestureListener(RecyclerView recyclerView, IClickListener clickListener)
        {
            _recyclerView = recyclerView;
            _clickListener = clickListener;
        }

        public override bool OnSingleTapUp(MotionEvent e)
        {
            return true;
        }

        public override void OnLongPress(MotionEvent e)
        {
            var child = _recyclerView.FindChildViewUnder(e.GetX(), e.GetY());
            if (child != null && _clickListener != null)
            {
                _clickListener.OnLongClick(child, _recyclerView.GetChildAdapterPosition(child));
            }
        }
    }
}
