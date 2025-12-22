using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using XmlCheckTool.Models;
using XmlCheckTool.Models.BangChiTieu;
using XmlCheckTool.Services.ParseService;

namespace XmlCheckTool.Services.FileServices
{
    public interface IXmlImportService
    {
        XmlImportResult Import(string xmlPath);
    }

    public class XmlImportService : IXmlImportService
    {
        public XmlImportResult Import(string xmlPath)
        {
            var doc = XDocument.Load(xmlPath);

            var result = new XmlImportResult
            {
                XML1 = XML1_Parser.Parse(doc),
                XML2_List = XML2_Parser.Parse(doc)
                //BenhNhans = ParseBenhNhan(doc),
                //DichVus = ParseDichVu(doc),
                //Thuocs = ParseThuoc(doc)
            };

            return result;
        }
    }
}
