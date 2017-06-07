using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Timeline
{
    public class DataMessage : IData, INotifyPropertyChanged
    {
        public DataUser User { get; set; }

        public String Message { get; set; }

        public DateTime Issued { get; set; }

        public bool Pulse { get; set; }

        public bool NotPulse { get { return !Pulse; } set { Pulse = !value; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public DataMessage()
        {
            // Updates the "elapsed time" field and fires a property changed event.
            Device.StartTimer(TimeSpan.FromSeconds(30), () =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ElapsedString"));
                return true;
            });
        }

        public String ElapsedString
        {
            get
            {
                // Format the elapsed time by checking a few constraints and selecting the output appropriately.
                var now = DateTime.Now;
                var diff = now-Issued;
                if (diff.TotalMinutes < 5)
                    return "Just Now";
                else if (diff.TotalMinutes < 60)
                    return $"{Math.Floor(diff.TotalMinutes)}m";
                else if (diff.TotalHours < 24)
                    return $"{Math.Floor(diff.TotalHours)} hrs";

                return $"{Math.Floor(diff.TotalDays)}d";
            }
        }

        public String AbsoluteString
        {
            get
            {
                if (Issued == null)
                    return "";

                // If on same day, format by time, otherwise by day.
                var now = DateTime.Now;
                if (now.Date == Issued.Date)
                    return Issued.TimeOfDay.ToString(@"hh\:mm");
                else
                    return Issued.Date.ToString(@"MM\/dd\/yyyy");
            }
        }

        //  public String PulseImageName { get { return Pulse ? "Graph.jpg" : "Graph2.jpg"; } }
    }
}
