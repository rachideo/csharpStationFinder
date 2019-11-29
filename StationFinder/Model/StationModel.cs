using System.ComponentModel;
using System.Collections.Generic;


namespace StationFinder.Model

{
    public class StationModel { }

    public class Station : INotifyPropertyChanged     
    {
        private string stationName;

        private string stationLines;

        private string stationLat;

        private string stationLon;

        private string stationPos;

        public string StationName { get => stationName; set => stationName = value; }

        public string StationLines { get => stationLines; set => stationLines = value; }

        public string StationLat { get => stationLat; set => stationLat = value; }

        public string StationLon { get => stationLon; set => stationLon = value; }

        public string StationPos { get => stationPos; set => stationPos = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
