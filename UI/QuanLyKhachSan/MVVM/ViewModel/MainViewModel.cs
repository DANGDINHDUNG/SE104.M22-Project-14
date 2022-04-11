using System;
using QuanLyKhachSan.Core;

namespace QuanLyKhachSan.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand RoomsViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }

        public RoomsViewModel RoomsVM { get; set; }
        public DiscoveryViewModel DiscoveryVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            RoomsVM = new RoomsViewModel();
            DiscoveryVM = new DiscoveryViewModel();

            CurrentView = RoomsVM;

            RoomsViewCommand = new RelayCommand(o =>
            {
                CurrentView = RoomsVM;
            });

            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVM;
            });

        }
    }
}
