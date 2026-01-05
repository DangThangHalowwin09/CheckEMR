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

        public ObservableCollection<XML1_Model> XML1_UI { get; } = new();
        public ObservableCollection<XML2_Model> XML2_UI { get; } = new();
        public ObservableCollection<XML3_Model> XML3_UI { get; } = new();
        public ObservableCollection<XML4_Model> XML4_UI { get; } = new();
        public ObservableCollection<XML1_Model> XML5_UI { get; } = new();

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
                    XML1_UI.Add(result.XML1);
                    foreach(var XML in result.XML2_List)
                    {
                        XML2_UI.Add(XML);                    
                    }
                    foreach (var XML in result.XML3_List)
                    {
                        XML3_UI.Add(XML);
                    }
                    foreach (var XML in result.XML4_List)
                    {
                        XML4_UI.Add(XML);
                    }
                  
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
