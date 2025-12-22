using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace XmlCheckTool.Services.FileServices
{
    public interface IFilePickerService
    {
        string[] PickFiles();
    }
    public class FilePickerService : IFilePickerService
    {
        public string[] PickFiles()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                Multiselect = true
            };

            if (dialog.ShowDialog() == true)
                return dialog.FileNames;

            return Array.Empty<string>();
        }
    }
}
