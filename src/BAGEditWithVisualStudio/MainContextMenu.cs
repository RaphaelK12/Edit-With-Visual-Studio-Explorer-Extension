using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAG.EditWithVisualStudio
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, "*")]
    public class MainContextMenu : SharpContextMenu
    {
        private static readonly string launcher = "devenv.exe";

        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override ContextMenuStrip CreateMenu()
        {
            var menu = new ContextMenuStrip();

            var openInVsItem = new ToolStripMenuItem
            {
                Image = Properties.Resources.vsicon,
                Text = "Edit with Visual Studio"
            };

            openInVsItem.Click += (sender, args) =>
            {
                Task.Factory.StartNew(() => OpenFile(SelectedItemPaths));

            };

            menu.Items.Add(openInVsItem);

            return menu;
        }

        private string getpath()
        {
            string path = string.Empty;
            var names = Enum.GetNames(typeof(VisualStudioVersion)).Reverse();

            foreach (var name in names)
            {
                var version = (VisualStudioVersion) Enum.Parse(typeof(VisualStudioVersion), name);
                path = VSPath.GetVisualStudioInstallationDir(version) + launcher;
                if (File.Exists(path))
                {
                    return path;
                }
            }
            return string.Empty;
        }

        private void OpenFile(IEnumerable<string> selected)
        {
            var fileCmd = "/edit \"" + string.Join("\" \"", selected) + "\"";
            var vsPath = getpath();

            if (string.IsNullOrEmpty(vsPath))
            {
                MessageBox.Show("Cannot find Visual Studio", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Process.Start(vsPath, fileCmd);
            }
        }
    }
}
