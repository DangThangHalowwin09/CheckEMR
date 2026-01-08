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
        // ================= COMMAND =================
        public RelayCommand ImportXmlCommand { get; }
        public RelayCommand ClearXmlCommand { get; }

        // ================= UI COLLECTION =================
        public ObservableCollection<XML1_Model> XML1_UI { get; } = new();
        public ObservableCollection<XML2_Model> XML2_UI { get; } = new();
        public ObservableCollection<XML3_Model> XML3_UI { get; } = new();
        public ObservableCollection<XML4_Model> XML4_UI { get; } = new();
        public ObservableCollection<XML1_Model> XML5_UI { get; } = new();

        // ================= SERVICE =================
        private readonly IXmlImportService _xmlService;
        private readonly IFilePickerService _filePicker;

        // ================= STATE =================
        private bool _canClear;
        public bool CanClear
        {
            get => _canClear;
            set
            {
                _canClear = value;
                OnPropertyChanged();
            }
        }

        // ================= CONSTRUCTOR =================
        public MainViewModel()
        {
            _filePicker = new FilePickerService();
            _xmlService = new XmlImportService();

            ImportXmlCommand = new RelayCommand(ImportXml);
            ClearXmlCommand = new RelayCommand(ClearXml, () => CanClear);
        }

        // ================= IMPORT =================
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

                    foreach (var item in result.XML2_List)
                        XML2_UI.Add(item);

                    foreach (var item in result.XML3_List)
                        XML3_UI.Add(item);

                    foreach (var item in result.XML4_List)
                        XML4_UI.Add(item);

                    // Sau khi import thành công
                    CanClear = true;
                    ClearXmlCommand.RaiseCanExecuteChanged();
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

        // ================= CLEAR =================
        private void ClearXml()
        {
            if (MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ dữ liệu đã import?",
                "Xác nhận",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) != MessageBoxResult.Yes)
            {
                return;
            }

            XML1_UI.Clear();
            XML2_UI.Clear();
            XML3_UI.Clear();
            XML4_UI.Clear();
            XML5_UI.Clear();

            CanClear = false;
        }
    }
}
