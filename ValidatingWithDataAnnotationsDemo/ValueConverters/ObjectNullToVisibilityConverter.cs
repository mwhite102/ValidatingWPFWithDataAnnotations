using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ValidatingWithDataAnnotationsDemo.ValueConverters
{
    /// <summary>
    /// Returns a Visibility value based of if the value object is null or not
    /// </summary>
    class ObjectNullToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Returns a Visibility value based of if the value object is null or not
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Visibility.Visible if the value is not null, otherwise returns Visibility.Hidden</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            Visibility defaultVisiblity = Visibility.Hidden;

            if (parameter != null && parameter is Visibility)
            {
                defaultVisiblity = (Visibility)parameter;
            }

            return value == null ? defaultVisiblity : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
