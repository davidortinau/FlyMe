using FlyMe.ViewModels.Messages;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TinyMessenger;
using Xamarin.Forms;

namespace FlyMe.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        TinyMessengerHub _hub;

        private bool _isNotLoggedIn;
        public bool IsNotLoggedIn
        {
            get
            {
                return _isNotLoggedIn;
            }
            set
            {
                SetProperty(ref _isNotLoggedIn, value);
            }
        }

        public AppViewModel()
        {
            _hub = DependencyService.Resolve<TinyMessengerHub>();
            _hub.Subscribe<LoggedInMessage>(OnLoggedIn);
            _hub.Subscribe<LoggedOutMessage>(OnLoggedOut);
        }

        private void OnLoggedIn(LoggedInMessage obj)
        {
            IsNotLoggedIn = false;
        }

        private void OnLoggedOut(LoggedOutMessage obj)
        {
            IsNotLoggedIn = true;
        }
    }
}
