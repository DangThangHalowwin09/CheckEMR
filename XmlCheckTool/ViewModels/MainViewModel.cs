using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using XmlCheckTool.Commands;
using XmlCheckTool.Models;
using XmlCheckTool.Models.BangChiTieu;
using XmlCheckTool.Services;
using XmlCheckTool.Services.FileServices;

namespace XmlCheckTool.ViewModels
{
    public class MainViewModel
    {
        public RelayCommand ImportXmlCommand { get; }

        public ObservableCollection<XML1_Model> XML1 { get; } = new();
        public ObservableCollection<XML1_Model> XML2_List { get; } = new();
        public ObservableCollection<XML1_Model> XML3_List { get; } = new();
        public ObservableCollection<XML1_Model> XML4_List { get; } = new();
        public ObservableCollection<XML1_Model> XML5_List { get; } = new();

        private readonly IXmlImportService _xmlService;
        private readonly IFilePickerService _filePicker;
        public MainViewModel()
        {
            _filePicker = new FilePickerService();
            _xmlService = new XmlImportService();
            ImportXmlCommand = new RelayCommand(ImportXml);
        }
        private void ImportXml()
        {
            var files = _filePicker.PickFiles();
            if (files.Length == 0) return;

            foreach (var file in files)
            {
                try
                {
                    var result = _xmlService.Import(file);
                    XML1.Add(result.XML1_List);
                    //BenhNhanList.AddRange(result.BenhNhans);
                    //DichVuList.AddRange(result.DichVus);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Lỗi file:\n{file}\n\n{ex.Message}",
                        "XML lỗi",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
            }
        }

    }
}
