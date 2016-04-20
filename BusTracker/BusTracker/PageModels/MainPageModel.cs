using BusTracker.Models;
using FreshMvvm;
using Plugin.Geolocator;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BusTracker.PageModels
{
    [ImplementPropertyChanged]
    class MainPageModel : FreshBasePageModel
    {
        public ObservableCollection<BusSighting> BusSightings { get; set; } = new ObservableCollection<BusSighting>();

        public string NewBusName { get; set; }

        public MainPageModel()
        {
            BusSightings.Add(new BusSighting { Name = "Bus 1" });
            BusSightings.Add(new BusSighting { Name = "Bus 2" });
        }

        public Command AddBusCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;

                    var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);


                    var sighting = new BusSighting
                    {
                        Name = NewBusName,
                        Latitude = position.Latitude,
                        Longatude = position.Longitude
                    };

                    BusSightings.Add(sighting);
                    NewBusName = string.Empty;
                });
            }
        }
    }
}
