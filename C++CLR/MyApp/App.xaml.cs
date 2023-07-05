using MyLibrarySharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace MyApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AlgoManager.Initialize();

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string arch = "x86";
            if(Environment.Is64BitProcess)
            {
                arch = "x64";
            }
            var asmfile = System.IO.Path.Combine(path, String.Format("runtimes/win-{0}/native/MyLibraryCLR.dll", arch));

            try
            {
                var asm = Assembly.LoadFile(asmfile);
                var types = asm.GetExportedTypes();
                foreach (Type type in types)
                {
                    if (type.GetInterface("IPlugin") != null)
                    {
                        var obj = Activator.CreateInstance(type);
                        if (obj != null)
                        {
                            var plugin = (IPlugin)obj;
                            plugin.Initialize();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}
