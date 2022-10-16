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
	public partial class Sobitamise_mäng : Form
	{
		Button nupp1 , nupp2;
        Random random = new Random();
		int rida = 0;
		int tulp = 0;
		List<string> icons = new List<string>()
        {
                "!", "!", "N", "N", ",", ",", "k", "k",
                 "b", "b", "v", "v", "w", "w", "z", "z"
        };
			List<string> icns1 = new List<string>()
        {
                "!", "!", "N", "N", ",", ",", "k", "k",
                 "b", "b", "v", "v", "w", "w", "z", "z",
				 "e", "e", "q", "q", "f", "f", "t", "t",
				  "r", "r", "s", "s", "x", "x", "a", "a"
        };

        public Timer timer = new Timer { Interval = 750 };

        Label firstClicked = null;
        Label secondClicked = null;
		Label clickLabel;
        Label lbl;
        TableLayoutPanel tableLayoutPanel1;
		public Sobitamise_mäng()

		{
			nupp1 = new Button()
			{
				Text = "Level 1",
				Location = new Point(100, 520),
				Size = new System.Drawing.Size(100, 20),
			};
			nupp2 = new Button()
			{
				Text = "Level 2",
				Location = new Point(200, 520),
				Size = new System.Drawing.Size(100, 20),
			};

			this.Controls.Add(nupp1);
			nupp1.Click += Level;
			this.Controls.Add(nupp2);
			nupp2.Click += Level;

			this.Size = new System.Drawing.Size(800, 600);
			this.Text = "Sobitamise Mäng";
			this.MaximizeBox = false;

			clickLabel = new Label
			{
				Location = new Point(350, 520),
				Text = "Click: ",
				AutoSize = false,
				BorderStyle = BorderStyle.FixedSingle,
				Size = new System.Drawing.Size(200, 30),
				Font = new Font("Times New Roman", 20, FontStyle.Bold)
			};
			this.Controls.Add(clickLabel);


			tableLayoutPanel1 = new TableLayoutPanel()
			{
				ColumnCount = 4,
				Location = new System.Drawing.Point(3, 4),
				Name = "tableLayoutPanel1",
				Size = new System.Drawing.Size(527, 506),
				TabIndex = 0,
				CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
				BackColor = System.Drawing.Color.CornflowerBlue,
			};

			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));


			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.Controls.Add(tableLayoutPanel1);
		}
		private void Level (object sender, EventArgs e)//Tase . Nuppude vajutamisel valitakse tase
		{
			Button nupp_sender = (Button)sender;
			if (nupp_sender.Text == "Level 1")//lihtne tase
			{
				tableLayoutPanel1.RowCount = 4;
				tableLayoutPanel1.ColumnCount = 4;
				for (int j = 0; j <= 15; j++)
					{
						lbl = new Label()
						{

							BackColor = System.Drawing.Color.CornflowerBlue,
							AutoSize = false,
							Dock = System.Windows.Forms.DockStyle.Fill,
							TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
							Font = new System.Drawing.Font("Webdings", 48, System.Drawing.FontStyle.Bold),
							Text = "",
						};
						tableLayoutPanel1.Controls.Add(lbl , rida, tulp);
						rida++;
						lbl.ForeColor = lbl.BackColor;
						//clickLabel.Click += ButtonClicked;
						lbl.Click += label1_Click;
				}
					tulp++;
					rida = 0;
				foreach (Control control in tableLayoutPanel1.Controls)
					{
						Label iconLabel = control as Label;
						if (iconLabel != null)
						{
							int randomNumber = random.Next(icons.Count);
							iconLabel.Text = icons[randomNumber];
							iconLabel.ForeColor = iconLabel.BackColor;
							icons.RemoveAt(randomNumber);
						}
					}
					timer.Tick += timer1_Tick;

			}
			if (nupp_sender.Text == "Level 2")//keeruline tase
			{
				tableLayoutPanel1.RowCount = 8;
				tableLayoutPanel1.ColumnCount = 4;
				for (int j = 0; j <= 31; j++)
				{
					lbl = new Label()
					{
						BackColor = System.Drawing.Color.CornflowerBlue,
						AutoSize = false,
						Dock = System.Windows.Forms.DockStyle.Fill,
						TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
						Font = new System.Drawing.Font("Webdings", 48, System.Drawing.FontStyle.Bold),
						Text = "c",
					};
					tableLayoutPanel1.Controls.Add(lbl, rida, tulp);
					rida++;
					lbl.ForeColor = lbl.BackColor;
					lbl.Click += label1_Click;
				}
				tulp++;
				rida = 0;
				foreach (Control control in tableLayoutPanel1.Controls)
				{
					Label iconLabel = control as Label;
					if (iconLabel != null)
					{
						int randomNumber = random.Next(icns1.Count);
						iconLabel.Text = icns1[randomNumber];
						iconLabel.ForeColor = iconLabel.BackColor;
						icns1.RemoveAt(randomNumber);
					}
				}
				timer.Tick += timer1_Tick;
			}
		}

		int clickCount;
		private void label1_Click(object sender, EventArgs e)
        {
			lbl.Text = (clickCount++).ToString();

			if (timer.Enabled == true)
				return;

			Label clickedLabel = sender as Label;

			if (clickedLabel != null)
			{
				if (clickedLabel.ForeColor == Color.Black)
					return;


				if (firstClicked == null)
				{
					firstClicked = clickedLabel;
					firstClicked.ForeColor = Color.Black;
					return;
				}

					secondClicked = clickedLabel;
					secondClicked.ForeColor = Color.Black;
					CheckForWinner();
					
                if (firstClicked.Text == secondClicked.Text)
					{
						firstClicked = null;
						secondClicked = null;
						return;
					}
					timer.Start();
			}

		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			timer.Stop();

			firstClicked.ForeColor = firstClicked.BackColor;
			secondClicked.ForeColor = secondClicked.BackColor;

			firstClicked = null;
			secondClicked = null;
		}
		private void CheckForWinner()
		{
			foreach (Control control in tableLayoutPanel1.Controls)
			{
				Label iconLabel = control as Label;

				if (iconLabel != null)
				{
					if (iconLabel.ForeColor == iconLabel.BackColor)
						return;
				}
			}
			MessageBox.Show("You matched all the icons!", "Congratulations");
			Close();
		}
	}
}
