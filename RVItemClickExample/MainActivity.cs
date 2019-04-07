using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace RVItemClickExample
{
    // Ported from Java:
    // https://github.com/Hariofspades/CustomRecyclerView/blob/master/app/src/main/java/com/hariofspades/customrecyclerview/MainActivity.java#L31

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //Declare the Adapter, AecyclerView and our custom ArrayList
        private RecyclerView _recyclerView;
        private CustomAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Set toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recycleView);
            //As explained in the tutorial, LineatLayoutManager tells the RecyclerView that the view
            //must be arranged in linear fashion
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            /*
             * RecyclerView: Implementing single item click and long press (Part-II)
             */
            _recyclerView.AddOnItemTouchListener(
                new RecyclerTouchListener(this, _recyclerView, new ItemClickListener(this)));

            _adapter = new CustomAdapter(this);

            // Method call for populating the view
            PopulateRecyclerViewValues();
        }

        private void PopulateRecyclerViewValues()
        {
            var listContentArr = new List<CustomPojo>();
            /** This is where we pass the data to the adpater using POJO class.
             *  The for loop here is optional. I've just populated same data for 50 times.
             *  You can use a JSON object request to gather the required values and populate in the
             *  RecyclerView.
             * */
            for (int iter = 0; iter <= 50; iter++)
            {
                //Creating POJO class object
                //Values are binded using set method of the POJO class
                var pojoObject = new CustomPojo
                {
                    Name = "User Name",
                    Content = "Hello RecyclerView! item: " + iter,
                    Time = "10:45PM"
                };

                //After setting the values, we add all the Objects to the array
                //Hence, listConentArr is a collection of Array of POJO objects
                listContentArr.Add(pojoObject);
            }
            //We set the array to the adapter
            _adapter.SetListContent(listContentArr);

            //We in turn set the adapter to the RecyclerView
            _recyclerView.SetAdapter(_adapter);
        }
    }

    /*
     * RecyclerView: Implementing single item click and long press (Part-II)
     *
     * - creating an Interface for single tap and long press
     * - Parameters are its respective view and its position
     */

    public interface IClickListener
    {
        void OnClick(View view, int position);
        void OnLongClick(View view, int position);
    }

    public class ItemClickListener : IClickListener
    {
        private readonly Context _context;

        public ItemClickListener(Context context)
        {
            _context = context;
        }

        public void OnClick(View view, int position)
        {
            //Values are passing to activity & to fragment as well
            Android.Widget.Toast.MakeText(_context, "Single Click on position :" + position,
                Android.Widget.ToastLength.Short).Show();
        }

        public void OnLongClick(View view, int position)
        {
            Android.Widget.Toast.MakeText(_context, "Long press on position :" + position,
                Android.Widget.ToastLength.Short).Show();
        }
    }
}