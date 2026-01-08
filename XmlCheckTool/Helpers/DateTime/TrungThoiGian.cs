namespace XmlCheckTool.Helpers
{
    using System;
    using System.Globalization;

    public static class DateTimeHelper
    {
        private static readonly string[] SupportedFormats =
        {
            "yyyyMMdd",
            "yyyy-MM-dd",
            "yyyyMMddHHmm",
            "yyyyMMddHHmmss"
        };

        public static bool TryNormalizeNgayTHYL(string input, out string normalizedDate)
        {
            normalizedDate = null;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();

            if (DateTime.TryParseExact(
                input,
                SupportedFormats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime date))
            {
                normalizedDate = date.ToString("yyyyMMdd");
                return true;
            }

            return false;
        }
    }
}
