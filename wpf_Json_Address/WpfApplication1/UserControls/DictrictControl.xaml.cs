using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace WpfApplication1.UserControls
{
    /// <summary>
    /// DictrictControl.xaml 的交互逻辑
    /// </summary>
    public partial class DictrictControl : UserControl
    {
        public DictrictControl()
        {
            InitializeComponent();
        }
        public string Path
        {
            get;
            set;
        }
       
        
        private string _province;
        public string Province
        {
            get
            {
                if (com_province.SelectedValue == null)
                    return null;
                JProperty o = (JProperty)com_province.SelectedValue;
                JToken j = (JValue)o.Value[0];
                return j.ToString();
            }
            set { _province = value; }
        }

        private string _city;
        public string City
        {
            get
            {
                if (com_city.SelectedValue == null)
                    return null;
                JProperty o = (JProperty)com_city.SelectedValue;
                JToken j = (JValue)o.Value[0];
                return j.ToString();

            }
            set {  _city=value; }
        }

        private string _county;
        public string County
        {
            get
            {
                if (com_county.SelectedValue == null)
                    return null;
                JProperty o = (JProperty)com_county.SelectedValue;
                JToken j = (JValue)o.Value[0];
                return j.ToString();
            }
            set { _county=value; }
        }
       
 

        public string ProvinceID
        {
            get;
            set;
        }

        public static ArrayList province = new ArrayList();
        public static ArrayList city = new ArrayList();
        public static ArrayList county = new ArrayList();

        public static JObject district;
        public void GrertDic()
        {
            string DomaingPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = DomaingPath + "District.json";
            this.Path = path;
            if (File.Exists(path))
            {
                string jsonText = ReadFileUnicode();
                JObject jo = JObject.Parse(jsonText.Substring(1, jsonText.Length - 1));

                district = jo;


                foreach (JProperty p in jo.Children())
                {
                    if (p.Name.ToString().Substring(2, 4) == "0000")
                    {

                        province.Add(p);
                    }

                }
            }
        }


        public string ReadFileUnicode()
        {
            FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read);

            byte[] data = new byte[fs.Length];

            fs.Read(data, 0, data.Length);
            fs.Close();
            return System.Text.Encoding.Unicode.GetString(data);
        }

        private void com_province_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            city.Clear();
            county.Clear();
            if (com_province.SelectedValue == null)
                return;
            JProperty jp = (JProperty)com_province.SelectedValue;
            string id = jp.Name.Substring(0, 2);

            ProvinceID = id;

            foreach (JProperty p in district.Children())
            {
                if (p.Name.ToString().Substring(0, 2) == id && p.Name.ToString().Substring(4, 2) == "00" && p.Name.ToString().Substring(2, 2) != "00")
                {

                    city.Add(p);
                }

            }
            com_city.ItemsSource = null;

            com_city.ItemsSource = city;
            com_city.SelectedIndex = 0;
        }

        private void com_city_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            county.Clear();
            if (com_city.SelectedValue == null)
                return;
            JProperty jp = (JProperty)com_city.SelectedValue;
            string id = jp.Name.Substring(2, 2);


            foreach (JProperty p in district.Children())
            {
                 if (p.Name.ToString().Substring(0, 2) == ProvinceID && p.Name.ToString().Substring(2, 2) == id && p.Name.ToString().Substring(4, 2)!="00")
                {

                    county.Add(p);
                }

            }
            com_county.ItemsSource = null;
            com_county.ItemsSource = county;
            com_county.SelectedIndex = 0;
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            GrertDic();


            com_province.ItemsSource = province;


            foreach (JProperty jp in province)
            {
                JToken j = (JValue)jp.Value[0];
                if (j.ToString() == _province)
                {
                    com_province.Text = jp.ToString();
                }
            }
            foreach (JProperty jp in city)
            {
                JToken j = (JValue)jp.Value[0];
                if (j.ToString() == _city)
                {
                    com_city.Text = jp.ToString();
                }
            }

            foreach (JProperty jp in county)
            {
                JToken j = (JValue)jp.Value[0];
                if (j.ToString() == _county)
                {
                    com_county.Text = jp.ToString();
                }
            }

        }

    }
    public class DictrictConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (!(value is JProperty))
                return "";

            JProperty o = (JProperty)value;



            return o.Value[0];


        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
