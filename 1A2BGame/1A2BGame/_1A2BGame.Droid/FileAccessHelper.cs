using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace _1A2BGame.Droid
{
    public class FileAccessHelper
    {
        /// <summary>
        /// 取得Android資料目錄
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetLocalFilePath(string filename) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }
    }
}