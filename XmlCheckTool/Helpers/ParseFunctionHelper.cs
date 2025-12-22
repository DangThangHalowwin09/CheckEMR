using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace XmlCheckTool.Helpers
{
    public static class ParserFunctionHelper
    {
        public static decimal Parse(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            return decimal.TryParse(
                value.Trim(),
                NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint,
                new CultureInfo("vi-VN"),
                out var result
            ) ? result : 0;
        }
        public static decimal Parse(XElement? element)
        {
            return Parse(element?.Value);
        }
        public static string GetValue(this XElement parent, string name)
        {
            return parent.Element(name)?.Value?.Trim() ?? string.Empty;
        }
    }
}
