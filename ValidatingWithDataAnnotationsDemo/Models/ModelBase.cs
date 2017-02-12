using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ValidatingWithDataAnnotationsDemo.Models
{
    /// <summary>
    /// ModelBase derives from MVVM Light's ObservableObject and implements IDataErrorInfo
    /// </summary>
    public class ModelBase : ObservableObject, IDataErrorInfo
    {
        #region IDataErrorInfo

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                return OnValidate(columnName);
            }
        }

        /// <summary>
        /// Validates properties using DataAnnotations
        /// </summary>
        /// <param name="propertyName">The instance property name to be validated</param>
        /// <returns>An error message string if the property is not valid, or an empty string if the value is valid</returns>
        protected virtual string OnValidate(string propertyName)
        {
            string result = string.Empty;

            // Get the value for the propertyName to be validated
            var value = this.GetType().GetProperty(propertyName).GetValue(this);

            // Create a list of ValidationResults
            List<ValidationResult> validationResults = new List<ValidationResult>();

            // Create the ValidationContext
            ValidationContext context = new ValidationContext(this);

            // Set the MemberName on the ValidationContext to the propertyName being validated
            context.MemberName = propertyName;

            // Do the validation
            bool isValid = Validator.TryValidateProperty(value, context, validationResults);

            if (!isValid)
            {
                // Get the error message
                result = validationResults.First().ErrorMessage;
            }

            return result;
        }

        #endregion
    }
}
