using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Polyland
{
    public class ConfigurationData : INotifyPropertyChanged
    {
        /// <summary>
        /// @author John Ellis
        /// View modal
        /// </summary>
        public ObservableCollection<MyPolygon> MetallicPolygons { get; set; }//list of all polygons with metallic ratios displayed in the list box
        public ObservableCollection<System.Windows.Point> MyPoints { get; set; }//vertices of the selected metallic polygon displayed on the canvas
        public ObservableCollection<MyLine> MetallicLines { get; private set; }//lines with matching metallic ratios
        public const int LargestPossiblePolygonSize = 1000;
        public const string MyString = "Enter a number between 3-1000";
        private int _largestPolygonSize;//number of sides of the largest polygon to test
        public int LargestPolygonSize
        {
            get { return _largestPolygonSize; }
            set { _largestPolygonSize = value ; OnPropertyChanged("LargestPolygonSize"); }
        }

        private MyPolygon _selectedPolygon;//currently selected polygon in the listbox
        public MyPolygon SelectedPolygon
        {
            get { return _selectedPolygon; }
            set {
                _selectedPolygon = value;
                OnPropertyChanged("SelectedPolygon");

                MyPoints = new ObservableCollection<System.Windows.Point>();
                if (_selectedPolygon != null && _selectedPolygon.Vertices != null)
                {
                    foreach (var v in _selectedPolygon.Vertices)
                    {
                        MyPoints.Add(new System.Windows.Point(v.X + 50, v.Y + 50));
                    }
                }
                OnPropertyChanged("MyPoints");

                MetallicLines = new ObservableCollection<MyLine>();
                
                if (_selectedPolygon != null && _selectedPolygon.Vertices != null)
                {
                    foreach (var r in _selectedPolygon.MetallicRatios)
                    {
                        double middleX = 50;
                        double middleY = 50;
                        Point2D start = _selectedPolygon.Vertices[0];
                        Point2D end = _selectedPolygon.Vertices[r.IndexForDenominator];
                        MyLine myLine = new MyLine()
                        {
                            From = new Point(start.X + middleX, start.Y + middleY),
                            To = new Point(end.X + middleX, end.Y + middleY),
                            ColourString = (r.RatioIndex == 1) ? "Gold" : "Silver"
                        };
                        end = _selectedPolygon.Vertices[r.IndexForNumerator];
                        MyLine myLineB = new MyLine()
                        {
                            From = new Point(start.X + middleX, start.Y + middleY),
                            To = new Point(end.X + middleX, end.Y + middleY),
                            ColourString = (r.RatioIndex == 1) ? "Gold" : "Silver"
                        };
                        
                        MetallicLines.Add(myLine);
                        MetallicLines.Add(myLineB);
                        
                    }
                   
                }
                OnPropertyChanged("MetallicLines");
            }
        }

     
        public ConfigurationData()
        {
            LargestPolygonSize = 8;
        }

        //below is the boilerplate code supporting PropertyChanged events:
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

       
        /// <summary>
        /// Check Polygons from 3-sides to LargestPolygonSize
        /// This can take some time
        /// </summary>
        public void CheckPolygons()
        {
            var metallicPolygons = new List<MyPolygon>();
            for (int i = 3; i <= LargestPolygonSize; i++)
            {
                MyPolygon polygon = new MyPolygon(i);
                if (polygon.MetallicRatios.Count > 0)
                {
                    metallicPolygons.Add(polygon);
                }
            }
            MetallicPolygons = new ObservableCollection<MyPolygon>(metallicPolygons);
            OnPropertyChanged("MetallicPolygons");
            SelectedPolygon = metallicPolygons.Count>0 ? metallicPolygons[0] : null;
        }
    }


    
}
