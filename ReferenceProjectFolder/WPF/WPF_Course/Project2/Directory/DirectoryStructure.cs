using Project2.Directory.Data;
using System.Collections.Generic;
using System.Linq;

namespace Project2.Directory
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Get every logical drive on the machine
            return System.IO.Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Gets the directories top-level content
        /// </summary>
        /// <param name="fullPath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // Create empty list
            List<DirectoryItem> items = new();

            #region Get Folders

            // Try and get directories from the folder ignoring any issues doing so
            try
            {
                string[] dirs = System.IO.Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }
            }
            catch { }

            #endregion Get Folders

            #region Get Files

            // Try and get files from the folder ignoring any issues doing so
            try
            {
                string[] fs = System.IO.Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
                }
            }
            catch { }

            #endregion Get Files

            return items;
        }

        #region Helpers

        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // If we have no path, return empty
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            // Make all slashes back slashes
            string normalizedPath = path.Replace('/', '\\');

            // Find the last backslash in the path
            int lastIndex = normalizedPath.LastIndexOf('\\');

            // If we don't find a backslash, return the path itself
            if (lastIndex <= 0)
            {
                return path;
            }

            // Return the name after the last back slash
            return path[(lastIndex + 1)..];
        }

        #endregion Helpers
    }
}