using Project2.Directory.Data;
using Project2.Directory.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace Project2.Directory.ViewModels
{
    /// <summary>
    /// The view model for the applications main Directory view
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            // Get the logical drives
            System.Collections.Generic.List<DirectoryItem> children = DirectoryStructure.GetLogicalDrives();

            // Create the view models from the data
            Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }

        #endregion Constructor
    }
}