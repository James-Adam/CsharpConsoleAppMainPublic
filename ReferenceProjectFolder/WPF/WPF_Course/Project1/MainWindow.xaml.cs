using System.Windows;
using System.Windows.Controls;

namespace Project1;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ApplyButton_Click(object sender, RoutedEventArgs e)
    {
        _ = MessageBox.Show($"The Description is {DescriptionText.Text}");
    }

    private void ResetButton_Click(object sender, RoutedEventArgs e)
    {
        WeldCheckBox.IsChecked = AssemblyCheckBox.IsChecked = PlasmaCheckBox.IsChecked = LaserCheckBox.IsChecked =
            PurchaseCheckBox.IsChecked = LetheCheckBox.IsChecked = DrillCheckBox.IsChecked =
                FoldCheckBox.IsChecked = RollCheckBox.IsChecked = SawCheckBox.IsChecked = false;
    }

    private void RefreshButton_Click(object sender, RoutedEventArgs e)
    {
        _ = MessageBox.Show($"The Description is {DescriptionText.Text}");
    }

    private void Checkbox_Checked(object sender, RoutedEventArgs e)
    {
        LengthText.Text += ((CheckBox)sender).Content;
    }

    private void FinishDropdown_SelectionChanged(object sender, SelectionChangedEventArgs? e)
    {
        if (NoteText == null)
        {
            return;
        }

        ComboBox combo = (ComboBox)sender;
        ComboBoxItem value = (ComboBoxItem)combo.SelectedValue;
        NoteText.Text = (string)value.Content;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        FinishDropdown_SelectionChanged(FinishDropdown, null);
    }

    private void SupplierNameText_TextChanged(object sender, TextChangedEventArgs e)
    {
        MassText.Text = SupplierNameText.Text;
    }
}