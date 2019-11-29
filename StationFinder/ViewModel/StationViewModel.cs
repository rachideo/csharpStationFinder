using MyLib;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using StationFinder.Model;
using System.Windows.Input;

namespace StationFinder.ViewModel
{
    public class StationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Model.Station> _stations;
        string _latitude;
        string _longitude;
        int _radius;

        public StationViewModel()
        {
            Latitude = "5.727718";
            Longitude = "45.185603";
            Radius = 1000;

            SearchButton = new RelayCommand(LoadStations);
        }

        public ICommand SearchButton { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Model.Station> Stations
        {
            get { return _stations; }
            set
            {
                if (_stations != value)
                {
                    _stations = value;
                    RaisePropertyChanged(nameof(Stations));
                }
            }
        }



        public string Latitude
        {
            get { return _latitude; }
            set
            {
                if (_latitude != value)
                {
                    _latitude = value;
                    RaisePropertyChanged(nameof(Latitude));
                }
            }
        }
        public string Longitude
        {
            get { return _longitude; }
            set
            {
                if (_longitude != value)
                {
                    _longitude = value;
                    RaisePropertyChanged(nameof(Longitude));
                }
            }
        }
        public int Radius
        {
            get { return _radius; }
            set
            {
                if (_radius != value)
                {
                    _radius = value;
                    RaisePropertyChanged(nameof(Radius));
                }
            }
        }

        public void LoadStations()
        {
            ObservableCollection<Model.Station> stations = new ObservableCollection<Model.Station>();

            SubMain launch = new SubMain();
            Dictionary<string, EmptyObject> myStations = launch.Submainer(false, "https://data.metromobilite.fr/api/linesNear/json?x=" + Latitude + "&y=" + Longitude + "&dist=" + Radius + "&details=true");
            char[] CharToTrim = { 'G', 'R', 'E', 'N', 'O', 'B', 'L', 'E', ','};

            foreach (KeyValuePair<string, EmptyObject> kvp in myStations)
            {

                stations.Add(new Model.Station
                {
                    StationName = kvp.Key.TrimStart(CharToTrim),
                    StationLat = kvp.Value.lat.ToString(),
                    StationLon = kvp.Value.lon.ToString(),
                    StationPos = kvp.Value.lat.ToString().Replace(',', '.') + "," + kvp.Value.lon.ToString().Replace(',', '.'),              
                    StationLines = string.Join(", ", kvp.Value.lines.ToArray())
                });
            }
            Stations = stations;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
