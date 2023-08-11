using ChatClient.MVVM.Core;
using ChatClient.Net;

namespace ChatClient.MVVM.ViewModel
{
    public class MainViewModel
    {
        public RelayCommand ConnectToServerCommand { get; set; }

        public Server _server;
        public MainViewModel()
        {
            _server = new Server();
            ConnectToServerCommand = new RelayCommand(o => _server.ConnectToServer());
        }
    }
}
