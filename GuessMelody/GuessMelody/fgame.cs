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
    public partial class fgame : Form
    {
        Random rnd = new Random();

        public fgame()
        {
            InitializeComponent();
        }

        void MakeMusic()
        {
            int n = rnd .Next(0, Victorina.list.Count);
            WMP.URL = Victorina.list[1];
            //WMP.Ctlcontrols.play();
            Victorina.list.RemoveAt(n);
            lblMusicCount.Text = Victorina.list.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
            MakeMusic();
        }

        private void fgame_FormClosed(object sender, FormClosedEventArgs e)
        {
            WMP.Ctlcontrols.stop();
            //При закрытии музыка останавливается. 
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            timer1.Start();
            WMP.Ctlcontrols.play();
        }

        private void lblMusicCount_Click(object sender, EventArgs e)
        {

        }

        private void fgame_Load(object sender, EventArgs e)
        {
            lblMusicCount.Text = Victorina.list.ToString();
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Victorina.GameDureation;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if (progressBar1.Value == progressBar1.Maximum) {
                timer1.Stop();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            WMP.Ctlcontrols.pause();
        }
    }
}
