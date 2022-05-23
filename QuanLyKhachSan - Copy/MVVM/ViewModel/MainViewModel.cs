using System;
using QuanLyKhachSan.Core;

namespace QuanLyKhachSan.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand RoomsViewCommand { get; set; }
        public RelayCommand RoomRentalViewCommand { get; set; }
        public RelayCommand PaymentViewCommand { get; set; }
        public RelayCommand ReportationViewCommand { get; set; }
        public RelayCommand ServicesViewCommand { get; set; }
        public RelayCommand CustomersViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }

        public RoomsViewModel RoomsVM { get; set; }
        public RoomRentalViewModel RoomRentalVM { get; set; }
        public PaymentViewModel PaymentVM { get; set; }
        public ReportationViewModel ReportationVM { get; set; }
        public ServicesViewModel ServicesVM { get; set; }
        public CustomersViewModel CustomersVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }

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
            RoomRentalVM = new RoomRentalViewModel();
            PaymentVM = new PaymentViewModel();
            ReportationVM = new ReportationViewModel();
            ServicesVM = new ServicesViewModel();
            CustomersVM = new CustomersViewModel();
            SettingsVM = new SettingsViewModel();

            CurrentView = RoomsVM;

            RoomsViewCommand = new RelayCommand(o =>
            {
                CurrentView = RoomsVM;
            });

            RoomRentalViewCommand = new RelayCommand(o =>
            {
                CurrentView = RoomRentalVM;
            });

            PaymentViewCommand = new RelayCommand(o =>
            {
                CurrentView = PaymentVM;
            });

            ReportationViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReportationVM;
            });

            ServicesViewCommand = new RelayCommand(o =>
            {
                CurrentView = ServicesVM;
            });

            CustomersViewCommand = new RelayCommand(o =>
            {
                CurrentView = CustomersVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });

        }
    }
}