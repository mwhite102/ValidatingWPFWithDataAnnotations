using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ValidatingWithDataAnnotationsDemo.Models;

namespace ValidatingWithDataAnnotationsDemo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }

        /// <summary>
        /// Gets an ObservableCollection of PersonModel objects
        /// </summary>
        public ObservableCollection<PersonModel> People { get; private set; } = new ObservableCollection<PersonModel>();

        private PersonModel _NewPersonModel;

        /// <summary>
        /// Gets or sets the NewPersonModel
        /// </summary>
        public PersonModel NewPersonModel
        {
            get { return _NewPersonModel; }
            set
            {
                if (_NewPersonModel != value)
                {
                    _NewPersonModel = value;
                    RaisePropertyChanged();
                }
            }
        }

        private PersonModel _SelectedPersonModel;

        /// <summary>
        /// Gets or sets the SelectedPersonModel
        /// </summary>
        public PersonModel SelectedPersonModel
        {
            get { return _SelectedPersonModel; }
            set
            {
                if (_SelectedPersonModel != value)
                {
                    _SelectedPersonModel = value;
                    RaisePropertyChanged();
                }
            }
        }

        #region Private Methods

        private void DoAddNew()
        {
            NewPersonModel = new PersonModel();
        }

        private void DoCancel()
        {
            NewPersonModel = null;
        }

        private void DoDelete()
        {
            People.Remove(SelectedPersonModel);
            SelectedPersonModel = null;
        }

        private void DoSave()
        {
            People.Add(NewPersonModel);
            NewPersonModel = null;
        }

        #endregion

        #region Commands

        private ICommand _AddCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(AddCommandExecute);
                }
                return _AddCommand;
            }
        }

        private void AddCommandExecute()
        {
            DoAddNew();
        }

        private ICommand _DeleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand(DeleteCommandExceute, DeleteCommandCanExecute);
                }
                return _DeleteCommand;
            }
        }

        private void DeleteCommandExceute()
        {
            DoDelete();
        }

        private bool DeleteCommandCanExecute()
        {
            return _SelectedPersonModel != null;
        }

        private ICommand _ExitCommand;

        public ICommand ExitCommand
        {
            get
            {
                if (_ExitCommand == null)
                {
                    _ExitCommand = new RelayCommand(ExitCommandExecute);
                }
                return _ExitCommand;
            }
        }

        private void ExitCommandExecute()
        {
            App.Current.Shutdown(0);
        }

        private ICommand _SaveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(SaveCommandExecute, SaveCommandCanExecute);
                }
                return _SaveCommand;
            }
        }

        private void SaveCommandExecute()
        {
            DoSave();
        }

        private bool SaveCommandCanExecute()
        {
            return NewPersonModel != null && NewPersonModel.IsValid();
        }

        private ICommand _CancelEditCommand;

        public ICommand CancelEditCommand
        {
            get
            {
                if (_CancelEditCommand == null)
                {
                    _CancelEditCommand = new RelayCommand(CancelEditCommandExecute);
                }
                return _CancelEditCommand;
            }
        }

        private void CancelEditCommandExecute()
        {
            DoCancel();
        }

        #endregion
    }
}