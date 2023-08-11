using System.Windows;
using System.Windows.Input;

namespace ChatClient;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private void WindowStateButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow.WindowState =
            Application.Current.MainWindow.WindowState != WindowState.Maximized
                ? WindowState.Maximized
                : WindowState.Normal;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}