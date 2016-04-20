using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracker.Models
{
    [ImplementPropertyChanged]
    class BusSighting
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public double Longatude { get; set; }
        public double Latitude { get; set; }
    }
}
