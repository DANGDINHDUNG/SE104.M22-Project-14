using System;
using QuanLyKhachSan.Core;

namespace QuanLyKhachSan.MVVM.ViewModel.SubViewModel
{
    class MainSettingsViewModel : ObservableObject
    {
        public RelayCommand SettingRoomsViewCommand { get; set; }
        public RelayCommand SettingRoomStatusesViewCommand { get; set; }
        public RelayCommand SettingRoomTypesViewCommand { get; set; }
        public RelayCommand SettingRulesViewCommand { get; set; }

        public SettingRoomsViewModel SettingRoomsVM { get; set; }
        public SettingRoomStatusesViewModel SettingRoomStatusesVM { get; set; }
        public SettingRoomTypesViewModel SettingRoomTypesVM { get; set; }
        public SettingRulesViewModel SettingRulesVM { get; set; }

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

        public MainSettingsViewModel()
        {
            SettingRoomsVM = new SettingRoomsViewModel();
            SettingRoomStatusesVM = new SettingRoomStatusesViewModel();
            SettingRoomTypesVM = new SettingRoomTypesViewModel();
            SettingRulesVM = new SettingRulesViewModel();

            CurrentView = SettingRoomsVM;

            SettingRoomsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingRoomsVM;
            });

            SettingRoomStatusesViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingRoomStatusesVM;
            });

            SettingRoomTypesViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingRoomTypesVM;
            });

            SettingRulesViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingRulesVM;
            });
        }
    }
}
