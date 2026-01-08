using System;
using System.Collections.ObjectModel;
using System.Windows;
using XmlCheckTool.Commands;
using XmlCheckTool.Models;
using XmlCheckTool.Models.BangChiTieu;
using XmlCheckTool.Services;
using XmlCheckTool.Services.FileServices;

namespace XmlCheckTool.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand ImportXmlCommand { get; }
        public RelayCommand ClearXmlCommand { get; }

        public ObservableCollection<XML1_Model> XML1_UI { get; } = new();
        public ObservableCollection<XML2_Model> XML2_UI { get; } = new();
        public ObservableCollection<XML3_Model> XML3_UI { get; } = new();
        public ObservableCollection<XML4_Model> XML4_UI { get; } = new();

        private readonly IXmlImportService _xmlService;
        private readonly IFilePickerService _filePicker;

        public MainViewModel()
        {
            _filePicker = new FilePickerService();
            _xmlService = new XmlImportService();

            ImportXmlCommand = new RelayCommand(ImportXml);
            ClearXmlCommand = new RelayCommand(ClearXml, CanClear);
        }

        /// <summary>
        /// Chỉ cần có dữ liệu là button Clear sáng
        /// </summary>
        private bool CanClear()
        {
            return XML1_UI.Count > 0
                || XML2_UI.Count > 0
                || XML3_UI.Count > 0
                || XML4_UI.Count > 0;
        }

        private void ImportXml()
        {
            var files = _filePicker.PickFiles();
            if (files == null || files.Length == 0)
                return;

            foreach (var file in files)
            {
                try
                {
                    var result = _xmlService.Import(file);

                    XML1_UI.Add(result.XML1);
                    result.XML2_List.ForEach(XML2_UI.Add);
                    result.XML3_List.ForEach(XML3_UI.Add);
                    result.XML4_List.ForEach(XML4_UI.Add);
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

            // 🔴 DÒNG QUAN TRỌNG – NẾU THIẾU → BUTTON KHÔNG SÁNG
            ClearXmlCommand.RaiseCanExecuteChanged();
        }

        private void ClearXml()
        {
            if (MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ dữ liệu đã import?",
                "Xác nhận",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            XML1_UI.Clear();
            XML2_UI.Clear();
            XML3_UI.Clear();
            XML4_UI.Clear();

            ClearXmlCommand.RaiseCanExecuteChanged();
        }
    }
}
