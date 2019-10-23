using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.pointAtHead.Enabled = false;
            this.PointAway.Enabled = false;
            this.SpinChamber.Enabled = false;
            this.Fire.Enabled = false;
        }
        int shots_left=3;
        int cham_loc =  1;
        int bullet_loc;
        int stayAway = 2;
        Random ran = new Random();
        
        private void pointAtHead_Click(object sender, EventArgs e)
        {
            this.gun.Location = new Point(196, 95);

        }

        private void PointAway_Click(object sender, EventArgs e)
        {
            this.gun.Location = new Point(290, 95);
        }

        private void SpinChamber_Click(object sender, EventArgs e)
        {
            if(cham_loc==6)
            {
                cham_loc = 0;
            }
            cham_loc++;
            this.ChamberLocation.Text = "Chamber Position=" + cham_loc;
        }

        private void LoadBullet_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(WindowsFormsApp2.Properties.Resources.reload);
            audio.Play();
            bullet_loc = ran.Next(1, 6);
            this.LoadBullet.Enabled = false;
            this.pointAtHead.Enabled = true;
            this.PointAway.Enabled = true;
            this.SpinChamber.Enabled = true;
            this.Fire.Enabled = true;
        }

        public void showAnimatedPictureBox()
        {
            person.Image = Properties.Resources.dead;
            person.Refresh();
            person.Visible = true;
        }

        private void Fire_Click(object sender, EventArgs e)
        {
           
            if (this.gun.Location.X == 196)
            {
                if (bullet_loc == cham_loc)
                {
                    showAnimatedPictureBox();
                    SoundPlayer audio = new SoundPlayer(WindowsFormsApp2.Properties.Resources.fire);
                    audio.Play();
                    this.Fire.Visible = false;
                    this.Status.Text = "Died";
                    this.Status.Visible = true;
                    this.PlayAgain.Visible = true;
                    this.PointAway.Visible = false;
                    this.pointAtHead.Visible = false;
                    this.LoadBullet.Visible = false;
                    this.SpinChamber.Visible = false;
                }
                else
                {
                    shots_left--;
                    this.ShotsLeft.Text = "Shots Left=" + shots_left;
                }
            }
            else
            {
                stayAway--;
                if (bullet_loc == cham_loc)
                {
                    SoundPlayer audio = new SoundPlayer(WindowsFormsApp2.Properties.Resources.fire);
                    audio.Play();
                    this.Fire.Visible = false;
                    this.Status.Text = "Survived";
                    this.Status.Visible = true;
                    this.PlayAgain.Visible = true;
                    this.PointAway.Visible = false;
                    this.pointAtHead.Visible = false;
                    this.LoadBullet.Visible = false;
                    this.SpinChamber.Visible = false;
                }
                else
                {
                    shots_left--;
                    this.ShotsLeft.Text = "Shots Left=" + shots_left;
                }
            }
            if (shots_left == 0)
            {
                this.Fire.Visible = false;
                this.Status.Text = "Survived";
                this.Status.Visible = true;
                this.PlayAgain.Visible = true;
                this.PointAway.Visible = false;
                this.pointAtHead.Visible = false;
                this.LoadBullet.Visible = false;
                this.SpinChamber.Visible = false;
            }
            
            if (cham_loc == 6)
            {
                cham_loc = 0;
            }
            cham_loc++;
            this.ChamberLocation.Text = "Chamber Position=" + cham_loc;
            if (stayAway == 0)
            {
                this.gun.Location = new Point(196, 95);
                this.PointAway.Enabled = false;
            }

        }


        private void PlayAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
