using System;
using System.Collections.Generic;
using System.Text;
using XmlCheckTool.Helpers;
using XmlCheckTool.Models.BangChiTieu;

namespace XmlCheckTool.Services.ValidationService
{
   /* public static class XmlValidationService
    {
        public static string CheckDuplicateDoctorDate(List<XML3_Model> xmlList)
        {
            if (xmlList == null || xmlList.Count == 0)
                return string.Empty;



            StringBuilder result = new StringBuilder();

            foreach (var xml in xmlList)
            {
                if (xml.XML3_List == null || xml.XML3_List.Count == 0)
                    continue;

                var duplicateGroups = xml.XML3_List
                    .Select(x =>
                    {
                        if (DateTimeHelper.TryNormalizeNgayTHYL(x.NGAYTH_YL, out string normalized))
                        {
                            return new
                            {
                                x.MA_BAC_SI,
                                NGAYTH_YL = normalized
                            };
                        }
                        return null;
                    })
                    .Where(x => x != null && !string.IsNullOrWhiteSpace(x.MA_BAC_SI))
                    .GroupBy(x => new { x.MA_BAC_SI, x.NGAYTH_YL })
                    .Where(g => g.Count() > 1);

                foreach (var group in duplicateGroups)
                {
                    result.AppendLine(
                        $"MA_LK: {xml.MA_LK} | " +
                        $"MA_BAC_SI: {group.Key.MA_BAC_SI} | " +
                        $"NGAYTH_YL: {group.Key.NGAYTH_YL}"
                    );
                }
            }

            return result.ToString();
        }
    }*/
}
