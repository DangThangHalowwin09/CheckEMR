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
                    MA_PTTT_QT = node.GetValue("MA_PTTT_QT"),
                    MA_VAT_TU = node.GetValue("MA_VAT_TU"),
                    MA_NHOM = node.GetValue("MA_NHOM"),
                    GOI_VTYT = node.GetValue("GOI_VTYT"),
                    TEN_VAT_TU = node.GetValue("TEN_VAT_TU"),
                    TEN_DICH_VU = node.GetValue("TEN_DICH_VU"),
                    MA_XANG_DAU = node.GetValue("MA_XANG_DAU"),
                    DON_VI_TINH = node.GetValue("DON_VI_TINH"),
                    PHAM_VI = node.GetValue("PHAM_VI"),


                    SO_LUONG = node.GetValue("SO_LUONG"),
                    DON_GIA_BV = node.GetValue("DON_GIA_BV"),
                    DON_GIA_BH = node.GetValue("DON_GIA_BH"),
                    TT_THAU = node.GetValue("TT_THAU"),
                    TYLE_TT_DV = node.GetValue("TYLE_TT_DV"),
                    TYLE_TT_BH = node.GetValue("TYLE_TT_BH"),
                    THANH_TIEN_BV = node.GetValue("THANH_TIEN_BV"),
                    THANH_TIEN_BH = node.GetValue("THANH_TIEN_BH"),
                    T_TRANTT = node.GetValue("T_TRANTT"),
                    T_NGUONKHAC_NSNN = node.GetValue("T_NGUONKHAC_NSNN"),
                    T_NGUONKHAC_VTNN = node.GetValue("T_NGUONKHAC_VTNN"),
                    T_NGUONKHAC_VTTN = node.GetValue("T_NGUONKHAC_VTTN"),
                    T_NGUONKHAC_CL = node.GetValue("T_NGUONKHAC_CL"),
                    T_NGUONKHAC = node.GetValue("T_NGUONKHAC"),
                    T_BNTT = node.GetValue("T_BNTT"),
                    T_BNCCT = node.GetValue("T_BNCCT"),
                    T_BHTT = node.GetValue("T_BHTT"),
                    MA_KHOA = node.GetValue("MA_KHOA"),
                    MA_GIUONG = node.GetValue("MA_GIUONG"),
                    MA_BAC_SI = node.GetValue("MA_BAC_SI"),
                    NGUOI_THUC_HIEN = node.GetValue("NGUOI_THUC_HIEN"),
                    MA_BENH = node.GetValue("MA_BENH"),
                    MA_BENH_YHCT = node.GetValue("MA_BENH_YHCT"),
                    NGAY_YL = node.GetValue("NGAY_YL"),
                    NGAY_TH_YL = node.GetValue("NGAY_TH_YL"),
                    NGAY_KQ = node.GetValue("NGAY_KQ"),
                    MA_PTTT = node.GetValue("MA_PTTT"),
                    VET_THUONG_TP = node.GetValue("VET_THUONG_TP"),
                    PP_VO_CAM = node.GetValue("PP_VO_CAM"),
                    VI_TRI_TH_DVKT = node.GetValue("VI_TRI_TH_DVKT"),
                    MA_MAY = node.GetValue("MA_MAY"),
                    MA_HIEU_SP = node.GetValue("MA_HIEU_SP"),
                    TAI_SU_DUNG = node.GetValue("TAI_SU_DUNG"),
                    DU_PHONG = node.GetValue("DU_PHONG"),

                };

                result.Add(thuoc);
            }
            return result;
        }
    }
}
