using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace GuessMelody
{
    static class Victorina
    {
        static public List<string> list = new List<string>();
        static public int GameDureation = 35;
        //Длительность раунда
        static public int MusicDuration = 15;
        //Длительность продолжительности отрывка во время раунда
        static public bool randomStart = false;
        //Либо композиция проигрывается с начала либо со случайного места
        static public string lastFolder = " ";
        //Выбор где находится папка с композициями
        static public bool allDirectories = false;
        //

        static public void ReadMusic()
        {
            try
            {
                string[] music_files = Directory.GetFiles(lastFolder, "*.mp3", allDirectories ? SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly);
                list.Clear();
                list.AddRange(music_files);
            }
            catch
            {
            }
        }

        static string regKeyname = "Software\\MyCompanyname\\GuessMelody";
        public static void Writeparam()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.CreateSubKey(regKeyname);
                rk.SetValue("lastFolder", lastFolder);
                rk.SetValue("Random", randomStart);
                rk.SetValue("GameDuration", GameDureation);
                rk.SetValue("MusicDuration", MusicDuration);
                rk.SetValue("AllDirectories", allDirectories);
            }
            finally
            {
                if(rk != null) rk.Close();
            }
        }

        public static void Readparam()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.OpenSubKey(regKeyname);
                if (rk != null)
                {
                    lastFolder = (string)rk.GetValue("lastFolder");
                    GameDureation = (int)rk.GetValue("GameDuration");
                    randomStart = Convert.ToBoolean(rk.GetValue("RandomStart", false));
                    MusicDuration = (int)rk.GetValue("MusicDuration");
                    allDirectories = Convert.ToBoolean(rk.GetValue("AllDirectories"));
                }
            }
            finally
            {
                if(rk != null) rk.Close();
            }
        }

    }
}
