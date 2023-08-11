using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ModernVPN.Core;
using ModernVPN.MVVM.Model;

namespace ModernVPN.MVVM.ViewModel;

internal class ProtectionViewModel : ObservableObject
{
    private string _connectionStatus;

    public ProtectionViewModel()
    {
        Servers = new ObservableCollection<ServerModel>();
        for (var i = 0; i < 1; i++)
            Servers.Add(new ServerModel
            {
                Country = "USA"
            });

        ConnectCommand = new RelayCommand(o =>
        {
            ConnectionStatus = "Connecting";
            Process process = new();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer vpnbook dd4e58m /phonebook:./VPN/VPN.bpk");

            _ = process.Start();
            process.WaitForExit();

            switch (process.ExitCode)
            {
                case 0:
                    Console.WriteLine("Success!");
                    break;

                case 691:
                    Console.WriteLine("Wrong credentials!");
                    break;

                default:
                    Console.WriteLine($"Error: {process.ExitCode}");
                    break;
            }
        });
        //ServerBuilder();
    }

    public ObservableCollection<ServerModel> Servers { get; set; }

    public string ConnectionStatus
    {
        get => _connectionStatus;
        set
        {
            _connectionStatus = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand ConnectCommand { get; set; }
}