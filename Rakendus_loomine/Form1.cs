using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rakendus_loomine
{
	public partial class Form1 : Form
	{
		Button Pildi;
		Button Matem;
		Button Mäng;
		public Form1()
		{

            Height = 720;
            Width = 1280;
            BackColor = Color.LightBlue;
            ForeColor = Color.Black;
            Text = "Peamine Vorm";

            Pildi = new Button();
            Pildi.Text = "Pildi vaata";
            Pildi.ForeColor = Color.Black;
            Pildi.BackColor = Color.White;
            Pildi.Width = 150;
            Pildi.Height = 50;
            Pildi.Location = new Point(150, 300);
            this.Controls.Add(Pildi);
            Pildi.Click += Pildid_Click;


            Matem = new Button();
            Matem.Text = "Matemaatika";
            Matem.ForeColor = Color.Black;
            Matem.BackColor = Color.White;
            Matem.Width = 150;
            Matem.Height = 50;
            Matem.Location = new Point(300, 300);



            Mäng = new Button();
            Mäng.Text = "Mäng";
            Mäng.ForeColor = Color.Black;
            Mäng.BackColor = Color.White;
            Mäng.Width = 150;
            Mäng.Height = 50;
            Mäng.Location = new Point(450, 300);
            this.Controls.Add(Mäng);
            this.Controls.Add(Matem);
            this.Controls.Add(Pildi);
			Mäng.Click += Mäng_Click;
			Pildi.Click += Pildid_Click;
			Matem.Click += Matemaatika_Click;

		}
		private void Mäng_Click(object sender, EventArgs e)
		{
			Sobitamise_mäng mängVaatamine = new Sobitamise_mäng();
			mängVaatamine.ShowDialog();
		}
		private void Matemaatika_Click(object sender, EventArgs e)
		{
			Matemaatika matemVaatamine = new Matemaatika();
			matemVaatamine.ShowDialog();
		}

		private void Pildid_Click(object sender, EventArgs e)
		{
			Pildid piltVaatamine = new Pildid();
			piltVaatamine.ShowDialog();
		}
	}
}
