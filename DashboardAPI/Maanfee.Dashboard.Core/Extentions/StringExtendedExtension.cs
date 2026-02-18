using System.Linq;

namespace Maanfee.Dashboard.Core
{
    public static class StringExtendedExtension
	{
        public static T? TrimStringAndCheckPersianSpecialLetter<T>(this T? input) where T : class
        {
            if (input == null)
				return null;

            var stringProperties = input.GetType().GetProperties()
				.Where(p => p.PropertyType == typeof(string) && p.CanWrite);

			foreach (var stringProperty in stringProperties)
			{
                var currentValue = stringProperty.GetValue(input, null) as string;
                if (currentValue != null)
					stringProperty.SetValue(input, currentValue.Trim().Replace("ي", "ی").Replace("ك", "ک"), null);
			}
			return input;
		}

        // ********************************************

        /// <summary>Trim all String properties of the given object.</summary>
        public static T? TrimString<T>(this T? input) where T : class
        {
            if (input == null)
                return null;

            var stringProperties = input.GetType().GetProperties()
				.Where(p => p.PropertyType == typeof(string) && p.CanWrite);

			foreach (var stringProperty in stringProperties)
			{
                var currentValue = stringProperty.GetValue(input, null) as string;
                if (currentValue != null)
					stringProperty.SetValue(input, currentValue.Trim(), null);
			}
			return input;
		}

        // ********************************************

        public static T? CheckPersianSpecialLetter<T>(this T? input) where T : class
        {
            if (input == null)
                return null;

            var stringProperties = input.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string) && p.CanWrite);

            foreach (var stringProperty in stringProperties)
            {
                var currentValue = stringProperty.GetValue(input, null) as string;
                if (currentValue != null)
                    stringProperty.SetValue(input, currentValue.Trim().Replace("ي", "ی").Replace("ك", "ک"), null);
            }
            return input;
        }

        public static string CheckPersianSpecialLetter(this string Value)
        {
            return Value.Trim().Replace("ي", "ی").Replace("ك", "ک");
        }
    }
}
