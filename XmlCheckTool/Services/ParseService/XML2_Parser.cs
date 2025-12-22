using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using XmlCheckTool.Models.BangChiTieu;

namespace XmlCheckTool.Services.ParseService
{
  
    public static class XML2_Parser
    {
        public static List<XML2_Model> Parse(XDocument docXML)
        {

            var result = new List<XML2_Model>();

            XNamespace ns = docXML.Root.GetDefaultNamespace();
            Console.WriteLine(ns);
            var thuocNodes = docXML
                .Descendants(ns + "CHI_TIET_THUOC");
            Console.WriteLine(thuocNodes);
            //Console.WriteLine(thuocNodes);

            foreach (var node in thuocNodes)
            {

                var thuoc = new XML2_Model
                {
                    //Console.WriteLine(node.Element(ns + "MA_LK")?.Value?.Trim());
                    MA_LK = node.Element(ns + "MA_LK")?.Value?.Trim(),
                    STT = node.Element(ns + "STT")?.Value?.Trim(),
                    MA_THUOC = node.Element(ns + "MA_THUOC")?.Value?.Trim(),

                    SO_LUONG = ParseDecimal(node.Element(ns + "SO_LUONG")?.Value),
                    DON_GIA = ParseDecimal(node.Element(ns + "DON_GIA")?.Value),
                    THANH_TIEN_BV = ParseDecimal(node.Element(ns + "THANH_TIEN_BV")?.Value),
                    THANH_TIEN_BH = ParseDecimal(node.Element(ns + "THANH_TIEN_BH")?.Value)
                };

                result.Add(thuoc);
            }
            
            return result;
        }
        private static decimal ParseDecimal(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            return decimal.TryParse(
                value,
                NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint,
                new CultureInfo("vi-VN"),
                out var result
            ) ? result : 0;
        }
    }

}
