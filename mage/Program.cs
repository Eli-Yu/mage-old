﻿using System;
using System.IO;
using System.Windows.Forms;

namespace mage
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // check for opening rom directly
            string[] args = Environment.GetCommandLineArgs();
            FormMain form = new FormMain();
            if (args.Length > 1)
            {
                string path = args[1];
                if (File.Exists(path))
                    form.OpenROM(path);
            }

            Application.Run(form);
        }

        public static string Version { get { return "1.4.2"; } }
        public static string ShortVersion { get { return "1.4"; } }

    }
}
