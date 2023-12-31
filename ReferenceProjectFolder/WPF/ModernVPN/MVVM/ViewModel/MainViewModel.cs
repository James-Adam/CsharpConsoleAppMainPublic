﻿using System.Windows;
using ModernVPN.Core;

namespace ModernVPN.MVVM.ViewModel;

internal class MainViewModel : ObservableObject
{
    //property full
    private object _currentView;

    //constructor
    public MainViewModel()
    {
        ProtectionVM = new ProtectionViewModel();
        SettingsVM = new SettingsViewModel();
        CurrentView = ProtectionVM;

        Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        //initialise command
        MoveWindowCommand = new RelayCommand(o => Application.Current.MainWindow.DragMove());
        ShutdownWindowCommand = new RelayCommand(o => Application.Current.Shutdown());
        MaximizeWindowCommand = new RelayCommand(o =>
        {
            Application.Current.MainWindow.WindowState =
                Application.Current.MainWindow.WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
        });
        MinimizeWindowCommand =
            new RelayCommand(o => Application.Current.MainWindow.WindowState = WindowState.Minimized);

        ShowProtectionView = new RelayCommand(o => CurrentView = ProtectionVM);
        ShowSettingsView = new RelayCommand(o => CurrentView = SettingsVM);
    }

    /// <summary>
    //Commands
    /// <summary>
    /// </summary>
    /// </summary>
    public RelayCommand MoveWindowCommand { get; set; }

    public RelayCommand ShutdownWindowCommand { get; set; }
    public RelayCommand MaximizeWindowCommand { get; set; }
    public RelayCommand MinimizeWindowCommand { get; set; }

    public RelayCommand ShowProtectionView { get; set; }
    public RelayCommand ShowSettingsView { get; set; }

    public object CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public ProtectionViewModel ProtectionVM { get; set; }
    public SettingsViewModel SettingsVM { get; set; }
}