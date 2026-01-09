using System;
using System.Collections.Generic;
using System.Text;

namespace XmlCheckTool.Models.BangChiTieu
{
    public class XmlImportResult
    {
        public XML1_Model? XML1 { get; set; }

        // XML2 → XML15
        public List<XML2_Model> XML2_List { get; set; } = new();
        public List<XML3_Model> XML3_List { get; set; } = new();
        public List<XML4_Model> XML4_List { get; set; } = new();

    }
}
