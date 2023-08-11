using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.View
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                _ = e.Parameter.ToString();
            }

            base.OnNavigatedTo(e);
        }

        //dispacher// check code
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            //MyViewModel.UpdateButton(sender);
            _ = ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
        }
    }
}