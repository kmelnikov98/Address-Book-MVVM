using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListView
{
    public static class FileOps
    {
        public static string SelectFileFolder()
        {
            var folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            string files = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                files = folderDialog.SelectedPath;
                return files;
            }

            return files;
        }
    }
}
