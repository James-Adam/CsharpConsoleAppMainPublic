using ChatClient.MVVM.Core;
using ChatClient.MVVM.Model;
using ChatClient.Net;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ChatClient.MVVM.ViewModel;

public class MainViewModel : ObservableObject //New project
{
    private readonly Server _server;

    private ContactModel _selectedContact;

    public MainViewModel()
    {
        //Messages = new ObservableCollection<MessageModel>();
        Messages = new ObservableCollection<string>();
        Contacts = new ObservableCollection<ContactModel>();

        _server = new Server();

        _server.connectedEvent += UserConnected;
        _server.msgRecievedEvent += MessageRecieved;
        _server.userDisconnectEvent += RemoveUser;

        ConnectToServerCommand = new RelayCommand(o => _server.ConnectToServer(Username!),
            o => !string.IsNullOrEmpty(Username));

        SendMessageCommand = new RelayCommand(o => _server.SendMessageToServer(Message),
            o => !string.IsNullOrEmpty(Message));

        #region edit

        //SendMessageCommand = new RelayCommand(o =>
        //{
        //    Messages.Add(new MessageModel
        //    {
        //        Message = Message,
        //        FirstMessage = false
        //    });
        //});

        //Message = "";

        //Messages.Add(new MessageModel
        //{
        //    Username = "Allison",
        //    UsernameColor = "#409aff",
        //    ImageSource = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.rd.com%2Flist%2Fonline-dating-profile-photos%2F&psig=AOvVaw02VofUdXl5sIqfJTCyXgXl&ust=1679149320261000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCLj27eiU4_0CFQAAAAAdAAAAABAD",
        //    Message = "Test",
        //    Time = DateTime.Now,
        //    IsNativeOrigin = false,
        //    FirstMessage = true
        //});

        //for (int i = 0; i < 3; i++)
        //{
        //    Messages.Add(new MessageModel
        //    {
        //        Username = "Allison",
        //        UsernameColor = "#409aff",
        //        ImageSource = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.rd.com%2Flist%2Fonline-dating-profile-photos%2F&psig=AOvVaw02VofUdXl5sIqfJTCyXgXl&ust=1679149320261000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCLj27eiU4_0CFQAAAAAdAAAAABAD",
        //        Message = "Test",
        //        Time = DateTime.Now,
        //        IsNativeOrigin = false,
        //        FirstMessage = false
        //    });
        //}

        //for (int i = 0; i < 4; i++)
        //{
        //    Messages.Add(new MessageModel
        //    {
        //        Username = "Bunny",
        //        UsernameColor = "#409aff",
        //        ImageSource = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.rd.com%2Flist%2Fonline-dating-profile-photos%2F&psig=AOvVaw02VofUdXl5sIqfJTCyXgXl&ust=1679149320261000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCLj27eiU4_0CFQAAAAAdAAAAABAD",
        //        Message = "Test",
        //        Time = DateTime.Now,
        //        IsNativeOrigin = true,

        //    });
        //}

        //Messages.Add(new MessageModel
        //{
        //    Username = "Bunny",
        //    UsernameColor = "#409aff",
        //    ImageSource = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.rd.com%2Flist%2Fonline-dating-profile-photos%2F&psig=AOvVaw02VofUdXl5sIqfJTCyXgXl&ust=1679149320261000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCLj27eiU4_0CFQAAAAAdAAAAABAD",
        //    Message = "Last",
        //    Time = DateTime.Now,
        //    IsNativeOrigin = true,

        //});

        //for (int i = 0; i < 5; i++)
        //{
        //    Contacts.Add(new ContactModel
        //    {
        //        Username = $"Allison {i}",
        //        ImageSource = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTphAbq94anCiggoj1vunoslO_ubuk8O-vTblv9shnqk9OzEH_Bz6UcFQwWgSmpmhqwFD0&usqp=CAU",
        //        Messages = Messages
        //    });
        //}

        #endregion edit
    }

    //
    //public ObservableCollection<MessageModel> Messages { get; set; }
    public ObservableCollection<string> Messages { get; set; }

    public ObservableCollection<ContactModel> Contacts { get; set; }
    public RelayCommand ConnectToServerCommand { get; set; }
    public RelayCommand SendMessageCommand { get; set; }

    public ContactModel SelectedContact
    {
        get => _selectedContact;
        set
        {
            _selectedContact = value;
            OnPropertyChanged();
        }
    }

    public string Username { get; set; }

    //commands
    // public ContactModel SelectedContact { get; set; }
    private string _message { get; set; }

    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    private void MessageRecieved()
    {
        string msg = _server.PacketReader.ReadMessage();
        Application.Current.Dispatcher.Invoke(() => Messages.Add(msg));
    }

    private void UserConnected()
    {
        ContactModel contact = new()
        {
            Username = _server.PacketReader.ReadMessage(),
            UID = _server.PacketReader.ReadMessage()
        };

        if (!Contacts.Any(x => x.UID == contact.UID))
        {
            Application.Current.Dispatcher.Invoke(() => Contacts.Add(contact));
        }
    }

    private void RemoveUser()
    {
        string uid = _server.PacketReader.ReadMessage();
        ContactModel? contact = Contacts.Where(x => x.UID == uid).FirstOrDefault();
        _ = Application.Current.Dispatcher.Invoke(() => Contacts.Remove(contact!));
    }

    /// <summary>
    /// </summary>
    // public ObservableCollection<UserModel> Users { get; set; } public
    // ObservableCollection<string> Messages { get; set; } public RelayCommand
    // ConnectToServerCommand { get; set; } public RelayCommand SendMessageCommand { get; set; }

    // public string Username { get; set; } public string Message { get; set; }

    // private Server _server;

    // public MainViewModel() { Users = new ObservableCollection<UserModel>(); Messages = new ObservableCollection<string>();

    // _server = new Server();

    // _server.connectedEvent += UserConnected; _server.msgRecievedEvent += MessageRecieved;
    // _server.userDisconnectEvent += RemoveUser;

    // ConnectToServerCommand = new RelayCommand(o => _server.ConnectToServer(Username), o => !string.IsNullOrEmpty(Username));

    // SendMessageCommand = new RelayCommand(o => _server.SendMessageToServer(Message), o =>
    // !string.IsNullOrEmpty(Message)); }

    // private void MessageRecieved() { var msg = _server.PacketReader.ReadMessage();
    // Application.Current.Dispatcher.Invoke(() => Messages.Add(msg)); }

    // private void UserConnected() { var user = new UserModel { Username =
    // _server.PacketReader.ReadMessage(), UID = _server.PacketReader.ReadMessage(), };

    // if (!Users.Any(x => x.UID == user.UID)) { Application.Current.Dispatcher.Invoke(() =>
    // Users.Add(user)); } }

    //    private void RemoveUser()
    //    {
    //        var uid = _server.PacketReader.ReadMessage();
    //        var user = Users.Where(x => x.UID == uid).FirstOrDefault();
    //        Application.Current.Dispatcher.Invoke(() => Users.Remove(user));
    //    }
    //}
}