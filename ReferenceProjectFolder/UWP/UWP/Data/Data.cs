using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Data.Json;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP.Data
{
    //Binding Data items and collections to layout
    public class Data
    {
        public Data()
        {
            D1 = "My Data String";
            D2 = 42;
            D3 = new DateTime(2018, 1, 1);
        }

        //building models and videw models
        public Data(string d1, int d2, DateTime d3)
        {
            D1 = d1;
            D2 = d2;
            D3 = d3;
        }

        public string D1 { get; set; }
        public int D2 { get; set; }
        public DateTime D3 { get; set; }

        public string Summary => string.Concat(D1, " x ", D2.ToString(), " at ", D3.ToString());
    }

    public class DataViewModel : INotifyPropertyChanged
    {
        private int thinkness = 1;

        public DataViewModel()
        {
            Datas.Add(new Data());
            Datas.Add(new Data());
            Datas.Add(new Data());
            Datas.Add(new Data());
            Datas.Add(new Data());
            PropertyChanged += DataViewModel_PropertyChanged;
        }

        public Data DefaultData { get; } = new Data();

        public ObservableCollection<Data> Datas { get; } = new ObservableCollection<Data>();

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => ((INotifyPropertyChanged)Datas).PropertyChanged += value;
            remove => ((INotifyPropertyChanged)Datas).PropertyChanged -= value;
        }

        //building models and videw models
        private void DataViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //renew datas contents
        }

        public void InsertData()
        {
            Datas.Add(new Data("Inserted", 58, DateTime.Now.AddDays(5)));
        }

        public void AddData(Data d)
        {
            Datas.Add(d);
        }

        public void RemoveData(Data d)
        {
            _ = Datas.Remove(d);
        }

        public async void UpdateButton(object sender)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High, () =>
                {
                    Button b = (Button)sender;
                    b.BorderThickness = new Thickness(thinkness++);
                });
        }

        //using HTTP to call API
        //public async void MakeHTTPClientRequest()
        //{
        //    HttpClient hc = new HttpClient();
        //    HttpRequestHeaders hdrs = hc.DefaultRequestHeaders;
        //    hdrs.UserAgent.Add(new ProductInfoHeaderValue("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW94; Trident/6.0)"));
        //    HttpResponseMessage hrm = await hc.GetAsync(new Uri("http://myweb.service.com"));
        //    hrm.EnsureSuccessStatusCode();
        //    string body = await hrm.Content.ReadAsStringAsync();
        //}a

        //json deserialization
        public string JavascriptDeserialization(string body)
        {
            JsonObject js = JsonValue.Parse(body).GetObject();
            _ = js.GetNamedString("myText");
            _ = js.GetNamedNumber("myDouble");
            _ = js.GetNamedArray("myArray");

            js["myNewValue"] = JsonValue.CreateStringValue("MyNewText");
            js["mynewDouble"] = JsonValue.CreateNumberValue(123.4567);

            string newBody = js.Stringify();
            return newBody;
        }

        public async Task MakeHTTPClientRequest()
        {
            HttpClient hc = new HttpClient();
            _ = hc.DefaultRequestHeaders;
            hc.BaseAddress = new Uri("http://");

            HttpResponseMessage response = await hc.PostAsync("/request", new StringContent(""));
            _ = JavascriptDeserialization(response.Content.ToString());
        }
    }
}