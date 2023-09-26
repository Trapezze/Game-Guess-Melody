using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessMelody
{
    public partial class fParam : Form
    {
        public fParam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Victorina.allDirectories = cbAllDirectories.Checked;
            Victorina.GameDureation = Convert.ToInt32(cbGameDuration.Text);
            Victorina.MusicDuration = Convert.ToInt32(cbMusicDuration.Text);
            Victorina.randomStart = cbRandomStart.Checked;
            Victorina.Writeparam();
             this.Hide();
            //Скрываем Главное меню
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Set();
            this.Hide();
        }
        void Set()
        {
            cbAllDirectories.Checked = Victorina.allDirectories;
            cbGameDuration.Text = Victorina.GameDureation.ToString();
            cbMusicDuration.Text = Victorina.MusicDuration.ToString();
            cbRandomStart.Checked = Victorina.randomStart;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK);
            {
                string[] music_list=System.IO.Directory.GetFiles(fbd.SelectedPath, "*.mp3", cbAllDirectories.Checked?System.IO.SearchOption.AllDirectories:System.IO.SearchOption.TopDirectoryOnly);
                //Здесь создан обработчик для subfolers который обрабатывает если истина, если ложь то обработки нет
                Victorina.lastFolder = fbd.SelectedPath;
                listBox1.Items.Clear();
                //
                listBox1.Items.AddRange(music_list);
                //Предварительная очистка, для того чтобы при каждом запуске не добавалялись одни и те же композиции, то есть не засоряли память и не было путаницы среди композиций
                Victorina.list.Clear();
                Victorina.list.AddRange(music_list);
            }
            //Здесь описан процесс откуда программа будет брать музыку и какого формата
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
           //Логика для закрытия окна настроек. 
        }

        private void fParam_Load(object sender, EventArgs e)
        {
            Set();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Victorina.list.ToArray());
        }
    }
}
