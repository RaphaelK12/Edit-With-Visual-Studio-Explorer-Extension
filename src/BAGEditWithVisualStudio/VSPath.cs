using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BAG.EditWithVisualStudio
{
    public enum VisualStudioVersion { VS2012 = 110, VS2010 = 100, VS2008 = 90, VS2005 = 80, VSNet2003 = 71, VSNet2002 = 70, Other = 0 };

    internal static class VSPath
    {
        internal static string GetVisualStudioInstallationDir(VisualStudioVersion version)
        {
            string registryKeyString = String.Format(@"SOFTWARE{0}Microsoft\VisualStudio\{1}",
                Environment.Is64BitProcess ? @"\Wow6432Node\" : "\\",
                GetVersionNumber(version));

            using (var localMachineKey = Registry.LocalMachine.OpenSubKey(registryKeyString))
            {
                return localMachineKey.GetValue("InstallDir") as string;
            }
        }

        private static string GetVersionNumber(VisualStudioVersion version)
        {
            if (version == VisualStudioVersion.Other) throw new Exception("Not supported version");

            return ((int)version / 10) + ".0";
        }
    }
}
