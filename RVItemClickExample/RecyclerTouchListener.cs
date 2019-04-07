//
// RecyclerTouchListener.cs
//
// Author:
//       Yauheni Pakala <evgeniy.pakalo@gmail.com>
//
// Copyright (c) 2019 Yauheni Pakala
//
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;

namespace RVItemClickExample
{
    // Ported from Java:
    // https://github.com/Hariofspades/CustomRecyclerView/blob/master/app/src/main/java/com/hariofspades/customrecyclerview/MainActivity.java#L152
    public class RecyclerTouchListener : Java.Lang.Object, RecyclerView.IOnItemTouchListener
    {
        private readonly IClickListener _clicklistener;
        private readonly GestureDetector _gestureDetector;

        public RecyclerTouchListener(Context context, RecyclerView recycleView, IClickListener clicklistener)
        {
            _clicklistener = clicklistener;
            _gestureDetector = new GestureDetector(context,
                new CustomGestureListener(recycleView, clicklistener));
        }

        public bool OnInterceptTouchEvent(RecyclerView rv, MotionEvent e)
        {
            var child = rv.FindChildViewUnder(e.GetX(), e.GetY());
            if (child != null && _clicklistener != null && _gestureDetector.OnTouchEvent(e))
            {
                _clicklistener.OnClick(child, rv.GetChildAdapterPosition(child));

                // https://medium.com/@anupdey99/multiple-click-problem-need-to-return-true-4a21b72f0953
                return true;
            }

            return false;
        }

        public void OnTouchEvent(RecyclerView rv, MotionEvent e)
        {
        }

        public void OnRequestDisallowInterceptTouchEvent(bool disallowIntercept)
        {
        }
    }
}
