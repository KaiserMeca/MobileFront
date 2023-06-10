using MobileFront.Models;
using System.Globalization;

namespace MobileFront.Converters
{
    /// <summary>
    /// Converts the value of a DepartmentEnum object to its string representation.
    /// </summary>
    public class DepartmentConverter : IValueConverter
    {
        /// <summary>
        /// Converts a DepartmentEnum object to its corresponding string representation.
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="targetType">(unused)</param>
        /// <param name="parameter">(unused)</param>
        /// <param name="culture">(unused)</param>
        /// <returns>The string representation of the DepartmentEnum object</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DepartmentEnum department)
            {
                switch (department)
                {
                    case DepartmentEnum.HQ:
                        return "HQ";
                    case DepartmentEnum.Store1:
                        return "Store1";
                    case DepartmentEnum.Store2:
                        return "Store2";
                    case DepartmentEnum.Store3:
                        return "Store3";
                    case DepartmentEnum.MaintenanceStation:
                        return "MaintenanceStation";
                }
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
