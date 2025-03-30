using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SSRS_Sync
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            UserLookAndFeel.Default.SetSkinStyle(GetRandomStyle());
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }

        private static SkinStyle GetRandomStyle()
        {
            var themes=new List<SkinStyle>();
            themes.Add(SkinStyle.WXI);
            themes.Add(SkinStyle.Bezier);
            themes.Add(SkinStyle.Black);
            themes.Add(SkinStyle.DevExpress);
            themes.Add(SkinStyle.McSkin);
            themes.Add(SkinStyle.Office2007Blue);
            themes.Add(SkinStyle.Office2016Colorful);
            themes.Add(SkinStyle.Office2019White);
            themes.Add(SkinStyle.VisualStudio2010);
            themes.Add(SkinStyle.VisualStudio2013Light);
            themes.Add(SkinStyle.Xmas2008Blue);
            return themes.OrderBy(x=>Guid.NewGuid()).Take(1).First();
        }
    }
}
