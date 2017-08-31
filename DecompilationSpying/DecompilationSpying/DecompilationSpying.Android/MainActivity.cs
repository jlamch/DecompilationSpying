using Android.App;
using Android.OS;
using Android.Widget;
using System.Diagnostics;

namespace DecompilationSpying.Droid
{
    [Activity(Label = "DecompilationSpying.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private TextView textView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource, and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += Button_Click;

            textView = FindViewById<TextView>(Resource.Id.myLabel);
            textView.SetLines(25);
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            var c = new AsyncSleepyMethods();
            var sw = new Stopwatch();
            sw.Start();

            textView.Text += await c.CallSleepyComplicatedAwaiting();
            textView.Text += $"sw:{sw.ElapsedMilliseconds} " + System.Environment.NewLine;
            sw.Restart();

            ///////////////////////////////////////////////
            sw.Stop();

            textView.Text += "ready all " + System.Environment.NewLine;
        }
    }
}