using Android.App;
using Android.OS;
using Android.Widget;
using ReactiveUI;
using System.Reactive.Linq;

namespace HelloRxDroid
{
    [Activity(Label = "HelloRxDroid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : ReactiveActivity<MainActivity>
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            //Button button = FindViewById<Button>(Resource.Id.myButton);
            this.WireUpControls();


            MyButton.Events().Click.Count().Select(n => $"{n} clicks").ToProperty(this, CountMsg);
            this.OneWayBind(this, a => a.CountMsg, a => a.MyButton);
        }

        
        private string countMsg = "0 clicks";
        public string CountMsg
        {
            get { return countMsg; }
            set { this.RaiseAndSetIfChanged(ref countMsg, value); }
        }

        public Button MyButton { get; private set; }
    }
}

