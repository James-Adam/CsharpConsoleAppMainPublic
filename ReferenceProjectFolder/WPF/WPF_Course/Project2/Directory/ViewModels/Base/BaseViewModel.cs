﻿using System.ComponentModel;

namespace Project2.Directory.ViewModels.Base
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    //[ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}