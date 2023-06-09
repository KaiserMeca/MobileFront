using MobileFront.Models;
using System.Globalization;

namespace MobileFront.Converters
{
    public class DepartmentConverter : IValueConverter
    {
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
