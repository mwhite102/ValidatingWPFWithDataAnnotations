using System.ComponentModel.DataAnnotations;

namespace ValidatingWithDataAnnotationsDemo.Models
{
    /// <summary>
    /// Represents a Person
    /// </summary>
    /// <remarks>
    /// The PersonModel derives from ModelBase which in turn derives from MVVM Light's Observable object and
    /// also implements IDataErrorInfo to enable validation via DataAnnotations
    /// </remarks>
    public class PersonModel :  ModelBase
    {
        private string _FirstName;

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _LastName;

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int? _Age;

        /// <summary>
        /// Gets or sets the Age
        /// </summary>
        [Required(ErrorMessage = "Please enter an age")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int? Age
        {
            get { return _Age; }
            set
            {
                if (_Age != value)
                {
                    _Age = value;
                    RaisePropertyChanged();
                }
            }
        }        
    }
}
