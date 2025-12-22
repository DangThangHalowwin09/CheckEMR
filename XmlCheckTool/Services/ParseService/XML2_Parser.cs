using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using XmlCheckTool.Models.BangChiTieu;
using XmlCheckTool.Helpers;

namespace XmlCheckTool.Services.ParseService
{
  
    public static class XML2_Parser
    {
        public static List<XML2_Model> Parse(XDocument docXML)
        {

            var result = new List<XML2_Model>();
            var thuocNodes = docXML.Descendants("CHI_TIET_THUOC");
            Debug.WriteLine(thuocNodes.ToString());
            foreach (var node in thuocNodes)
            {
                var thuoc = new XML2_Model
                {
                    MA_LK = node.GetValue("MA_LK"),
                    STT = node.GetValue("STT"),
                    MA_THUOC = node.GetValue("MA_THUOC"),

                    SO_LUONG = ParserFunctionHelper.Parse(node.Element("SO_LUONG")),
                    DON_GIA = ParserFunctionHelper.Parse(node.Element("DON_GIA")),
                    THANH_TIEN_BV = ParserFunctionHelper.Parse(node.Element("THANH_TIEN_BV")),
                    THANH_TIEN_BH = ParserFunctionHelper.Parse(node.Element("THANH_TIEN_BH"))
                };

                result.Add(thuoc);
            }
            return result;
        }
        
    }

}
