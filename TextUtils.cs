using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace eu4NET
{
    class TextUtils
    {
        public static string FromChars(string text, int mode = 2)
        {
            switch (mode)
            {
                /*case 1:
                    byte[] from = Encoding.GetEncoding(1252).GetBytes(text);
                    byte[] to = Encoding.Convert(Encoding.GetEncoding(1251), Encoding.UTF8, from);

                    return Encoding.UTF8.GetString(to);*/
                case 2:
                    return FromGeks(text);
                default:
                    return text;
            }
        }

        public static string ToChars(string text, int mode = 2)
        {
            switch (mode)
            {
                /*case 1:
                    byte[] from = Encoding.UTF8.GetBytes(text);
                    byte[] to = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(1251), from);

                    return Encoding.GetEncoding(1252).GetString(to);*/
                case 2:
                    return ToGeks(text);
                default:
                    return text;
            }
        }

        /*public static string ConvertFromOldToNew(string text)
        {
            return ToGeks(text);
        }

        public static string ConvertFromNewToOld(string text)
        {
            return FromGeks(text);
        }*/

        public static bool ContainRu(string text, string match)
        {
            if (string.IsNullOrEmpty(match)) return false;

            return Regex.IsMatch(text, match, RegexOptions.IgnoreCase);
        }

        public static void SetChars(string filename)
        {
            SetChartable(filename);
        }

        /*public static void TChars(string text)
        {
            StringBuilder s = new StringBuilder(text);
            ToChars(s, s.Capacity);

            byte[] from = Encoding.UTF8.GetBytes(s.ToString());

            foreach(byte b in from)
            {
                Console.WriteLine(b);
            }

            MessageBoxEx.Show(s.ToString());
        }*/
        [DllImport(@"converter.dll", CharSet = CharSet.Unicode)]
        static extern void SetChartable([MarshalAs(UnmanagedType.LPWStr)] string filename);

        [DllImport(@"converter.dll", CharSet = CharSet.Unicode)]
        static extern string FromGeks([MarshalAs(UnmanagedType.LPWStr)] string text);

        [DllImport(@"converter.dll", CharSet = CharSet.Unicode)]
        static extern string ToGeks([MarshalAs(UnmanagedType.LPWStr)] string text);

        /*[DllImport(@"libconverterC.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern void ToChars(StringBuilder text, int len);*/
    }
}
