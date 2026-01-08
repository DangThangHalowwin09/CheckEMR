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
                    MA_KHOA = node.GetValue("MA_KHOA"),
                    MA_BAC_SI = node.GetValue("MA_BAC_SI"),
                    MA_DICH_VU = node.GetValue("MA_DICH_VU"),
                    NGAY_YL = node.GetValue("NGAY_YL"),
                    NGAY_TH_YL = node.GetValue("NGAY_TH_YL"),
                    MA_PTTT = node.GetValue("MA_PTTT"),
                };

                result.Add(thuoc);
            }
            return result;
        }
        
    }

}
