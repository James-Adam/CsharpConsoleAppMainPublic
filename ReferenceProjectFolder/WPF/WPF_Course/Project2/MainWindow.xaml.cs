using Project2.Directory.ViewModels;

using System.Windows;

namespace Project2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region constructors

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DirectoryStructureViewModel();
        }

        #endregion constructors

        #region OnLoaded

        /// <summary>
        /// when application first opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //get every logical drive on the machine
            foreach (var drive in System.IO.Directory.GetLogicalDrives())
            {
                //create new item
                var item = new TreeViewItem()
                {
                    //set header and path
                    Header = drive,
                    //and the full path

                    Tag = drive
                };

                //add dumy item
                item.Items.Add(null);

                //listen out for item being expanded
                item.Expanded += Folder_Expanded;

                //add to main  tree view
                FolderView.Items.Add(item);
            }
        }

        #endregion OnLoaded

        #region Folder Expanded

        /// <summary>
        /// when a folder is expanded, find the subfolders, files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial checks

            var item = (TreeViewItem)sender;
            // if item only contains dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }

            //clear dummy data
            item.Items.Clear();

            //get full path
            var fullPath = (string)item.Tag;

            #endregion Initial checks

            #region Get folders

            //create a blank list for directories
            var directories = new List<string>();
            //try get direcotries and ignore errror
            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch
            {
            }
            //foreach directory
            directories.ForEach(directoryPath =>
            {
                //create directory item
                var subItem = new TreeViewItem()
                {
                    //set header as folder name
                    Header = GetFileFolderName(directoryPath),
                    //tag as full path
                    Tag = directoryPath
                };
                //add dummy item so we can expand folder
                subItem.Items.Add(null);

                //handle expanding
                subItem.Expanded += Folder_Expanded;
                //add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion Get folders

            #region Get files

            //create a blank list for files
            var files = new List<string>();
            //try get files and ignore errror
            try
            {
                var fs = System.IO.Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch
            {
            }
            //foreach file
            files.ForEach(filePath =>
            {
                //create file item
                var subItem = new TreeViewItem()
                {
                    //set header as file name
                    Header = GetFileFolderName(filePath),
                    //tag as full path
                    Tag = filePath
                };

                //add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion Get files
        }
        */

        #endregion Folder Expanded

        #region Helpers

        /// <summary>
        /// find the file or folder name from a full path
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        /*
        public static string GetFileFolderName(string path)
        {
            //if we have no path, return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            //make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');

            //find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            //if we dont find a backslash return the path itself
            if (lastIndex <= 0)
            { return path; }

            //return the name after the last backslash
            return path.Substring(lastIndex + 1);
        }
        */

        #endregion Helpers
    }
}