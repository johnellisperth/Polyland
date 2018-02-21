using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Polyland
{
    public class PointCollectionConverter : IValueConverter
    {
        /// <summary>
        /// Convert an observeable collection of System.Windows.Points to PointCollection
        /// used by the xaml
        /// </summary>
        /// <param name="value">observeable collection of System.Windows.Points </param>
        /// <param name="targetType">eg PointCollection </param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value !=null && value.GetType() == typeof(ObservableCollection<Point>) 
                && targetType == typeof(PointCollection))
            {
                var pointCollection = new PointCollection();
                foreach (var point in value as ObservableCollection<Point>)
                    pointCollection.Add(point);
                return pointCollection;
            }
            return null;

        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null; //not needed
        }

        
    }


    
}
