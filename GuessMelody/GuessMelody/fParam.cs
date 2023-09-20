﻿using System;
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
             this.Hide();
            //Скрываем Главное меню
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK);
            {
                string[] music_list=System.IO.Directory.GetFiles(fbd.SelectedPath, "*.mp3", cbAllDirectories.Checked?System.IO.SearchOption.AllDirectories:System.IO.SearchOption.TopDirectoryOnly);
                //Здесь создан обработчик для subfolers который обрабатывает если истина, если ложь то обработки нет
                listBox1.Items.Clear();
                //
                listBox1.Items.AddRange(music_list);
            }
            //Здесь описан процесс откуда программа будет брать музыку и какого формата
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
           //Логика для закрытия окна настроек. 
        }
    }
}
