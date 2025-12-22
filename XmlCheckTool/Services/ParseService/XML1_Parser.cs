using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using XmlCheckTool.Models.BangChiTieu;

namespace XmlCheckTool.Services.ParseService
{
    public static class XML1_Parser
    {
        public static XML1_Model Parse(XDocument doc)
        {

            return new XML1_Model
            {
                MA_LK = GetValue(doc, "MA_LK"),
                STT = GetValue(doc, "STT"),
                HO_TEN = GetValue(doc, "HO_TEN"),
                SO_CCCD = GetValue(doc, "SO_CCCD"),
                MA_BN = GetValue(doc, "MA_BN")
            };
        }

        private static string? GetValue(XDocument doc, string elementName)
        {
            return doc
                .Descendants()
                .FirstOrDefault(x => x.Name.LocalName == elementName)
                ?.Value
                .Trim();
        }
    }
}
