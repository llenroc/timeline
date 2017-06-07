using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Timeline
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            populateData();
        }

        private void populateData()
        {
            // Make some meaningful times.
            var now = DateTime.Now; ;
            var justNow = now - new TimeSpan(0, 4, 0);
            var fiveMinutesAgo = now - new TimeSpan(0, 5, 0);
            var twoHoursAgo = now - new TimeSpan(2, 0, 0);

            var timeline = new DataTimeline()
            {
                Title = "House of Cards",
                Subtitle = "Washington Express",
                Icon = "Icon1.jpg"
            };

            // Users, are reused in the messages.
            var aralyel = new DataUser()
            {
                Avatar = "Avatar1.jpg",
                ScreenName = "Andrea Rayel",
                Handle = "@aralyel",
                Online = true
            };

            var asonga = new DataUser()
            {
                Avatar = "Avatar2.jpg",
                ScreenName = "Asonga Refref",
                Handle = "@asonga"
            };

            // Messages and splitter in between.
            var items = new List<IData>();
            items.Add(new DataMessage()
            {
                User = aralyel,
                Message = "In enim justo, rhoncus ut, imper diet a, venenatis vitae, justo. Nulldictum felis eu pede mollis pretium.",
                Issued = justNow, //new DateTime(2017, 6, 7, 13, 22, 0),
                Pulse = true
            });

            items.Add(new DataMessage()
            {
                User = asonga,
                Message = "Justo dictum felis eu pede.",
                Issued = fiveMinutesAgo, //new DateTime(2017, 6, 7, 13, 23, 0),
                Pulse = true
            });

            items.Add(new DataSplitter()
            {
                Duration = new TimeSpan(0, 14, 33)
            });

            items.Add(new DataMessage()
            {
                User = aralyel,
                Message = "In enim justo, rhoncus ut, imper diet a, venenatis vitae, justo. Nulldictum felis eu pede mollis pretium.",
                Issued = twoHoursAgo, // new DateTime(2017, 6, 7, 13, 22, 0),
                Pulse = false
            });

            // Set bindings to the relevant controls.
            TimelineHeader.BindingContext = timeline;
            TimelineList.ItemsSource = items;
        }
    }
}
