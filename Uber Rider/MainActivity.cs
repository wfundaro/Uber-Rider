using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Firebase;
using Firebase.Database;

namespace Uber_Rider
{
    [Activity(Label = "Uber Rider", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        FirebaseDatabase database;
        Button btnTestConnection;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnTestConnection = (Button)FindViewById(Resource.Id.mybutton);
            btnTestConnection.Click += btnTestConnection_click;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void btnTestConnection_click(object sender, System.EventArgs args)
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            var app = FirebaseApp.InitializeApp(this);
            if(app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetApplicationId("uber-clone-f63fe")
                    .SetApiKey("AIzaSyCMrZQ1VYGUgjm8mowyDm98mdaeJoSsXZs")
                    .SetDatabaseUrl("https://uber-clone-f63fe.firebaseio.com")
                    .SetStorageBucket("uber-clone-f63fe.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(this, options);
            }
            database = FirebaseDatabase.GetInstance(app);
            DatabaseReference dbRef = database.GetReference("UserSupport");
            dbRef.SetValue("Ticket1");
            Toast.MakeText(this, "Completed", ToastLength.Short).Show();
        }
    }
}