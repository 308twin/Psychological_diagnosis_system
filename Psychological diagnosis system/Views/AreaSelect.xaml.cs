using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Psychological_diagnosis_system.Models;
namespace Psychological_diagnosis_system.Views
{
    /// <summary>
    /// AreaSelect.xaml 的交互逻辑
    /// </summary>
    public partial class AreaSelect : UserControl, INotifyPropertyChanged
    {
        
        private IList<Province> _provinces = new List<Province>();

        public static readonly DependencyProperty ProvinceProperty = DependencyProperty.Register("Province", typeof(string), typeof(AreaSelect), new FrameworkPropertyMetadata(string.Empty));
        public static readonly DependencyProperty CityProperty = DependencyProperty.Register("City", typeof(string), typeof(AreaSelect), new FrameworkPropertyMetadata(string.Empty));
        public static readonly DependencyProperty CountyProperty = DependencyProperty.Register("County", typeof(string), typeof(AreaSelect), new FrameworkPropertyMetadata(string.Empty));


        public IList<Province> Provinces
        {
            get
            {
                return _provinces;
            }
            set
            {
                _provinces.Clear();
                if (value != null)
                {
                    foreach (Province province in value)
                    {
                        _provinces.Add(province);
                    }
                }
            }
        }

        public AreaSelect()
        {
            InitializeComponent();
            this.Content.DataContext = this;
            this.PropertyChanged += SelectedArea_PropertyChanged;
        }

        private void SelectedArea_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(Province + " " + City + " " + County);
        }


        private string _province;
        private string _city;
        private string _county;

        public string Province
        {
            get { return _province; }
            set
            {
                _province = value;
                _city = string.Empty;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Province"));
                }
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                _county = string.Empty;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("City"));
                }
            }
        }
        public string County
        {
            get { return _county; }
            set
            {
                _county = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("County"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
