using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using XmlCheckTool.Helpers;
using XmlCheckTool.Models.BangChiTieu;

namespace XmlCheckTool.Services.ParseService
{
    public static class XML4_Parser
    {
        public static List<XML4_Model> Parse(XDocument docXML)
        {

            var result = new List<XML4_Model>();
            var thuocNodes = docXML.Descendants("CHI_TIET_CLS");
            Debug.WriteLine(thuocNodes.ToString());
            foreach (var node in thuocNodes)
            {
                var thuoc = new XML4_Model
                {
                    MA_LK = node.GetValue("MA_LK"),
                    STT = node.GetValue("STT"),
                    MA_DICH_VU = node.GetValue("MA_DICH_VU"),
                    MA_CHI_SO = node.GetValue("MA_CHI_SO"),
                    GIA_TRI = node.GetValue("GIA_TRI"),
                    DON_VI_DO = node.GetValue("DON_VI_DO"),
                    MO_TA = node.GetValue("MO_TA"),
                    KET_LUAN = node.GetValue("KET_LUAN"),
                    NGAY_KQ = node.GetValue("NGAY_KQ"),
                    MA_BS_DOC_KQ = node.GetValue("MA_BS_DOC_KQ"),
                    DU_PHONG = node.GetValue("DU_PHONG"),
                };

                result.Add(thuoc);
            }
            return result;
        }
    }
}
