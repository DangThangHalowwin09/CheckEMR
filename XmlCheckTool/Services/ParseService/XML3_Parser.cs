using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using XmlCheckTool.Helpers;
using XmlCheckTool.Models.BangChiTieu;

namespace XmlCheckTool.Services.ParseService
{
    public static class XML3_Parser
    {
        public static List<XML3_Model> Parse(XDocument docXML)
        {

            var result = new List<XML3_Model>();
            var thuocNodes = docXML.Descendants("CHI_TIET_DVKT");
            Debug.WriteLine(thuocNodes.ToString());
            foreach (var node in thuocNodes)
            {
                var thuoc = new XML3_Model
                {
                    MA_LK = node.GetValue("MA_LK"),
                    STT = node.GetValue("STT"),
                    MA_DICH_VU = node.GetValue("MA_DICH_VU"),

                    SO_LUONG = ParserFunctionHelper.Parse(node.Element("SO_LUONG")),
                    PHAM_VI = ParserFunctionHelper.Parse(node.Element("PHAM_VI")),
                    DON_GIA_BV = ParserFunctionHelper.Parse(node.Element("DON_GIA_BV")),
                    DON_GIA_BH = ParserFunctionHelper.Parse(node.Element("DON_GIA_BH"))
                };

                result.Add(thuoc);
            }
            return result;
        }
    }
}
