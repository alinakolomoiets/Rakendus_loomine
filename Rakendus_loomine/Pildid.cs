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
	public partial class Pildid : Form
	{
            Button selge;
            Button sulge;
            Button näidata;
            PictureBox pilt;
            TableLayoutPanel tableLayoutPanel1;
            CheckBox box;
            OpenFileDialog openFileDialog;
            public Pildid()
            {
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Pildid";

            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            this.Controls.Add(this.tableLayoutPanel1);

            pilt = new PictureBox()
            {
                BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(2, 2),
                Size = new System.Drawing.Size(100, 100),
                TabIndex = 0,
                TabStop = false
            };
            tableLayoutPanel1.Controls.Add(pilt, 0, 0);
            tableLayoutPanel1.SetCellPosition(pilt, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel1.SetColumnSpan(pilt, 2);


            box = new CheckBox()
            {
                Text = "box",
                AutoSize = true,
                BackColor = Color.White,
                ForeColor = Color.Black,

            };
            tableLayoutPanel1.Controls.Add(box, 0, 1);
            box.CheckedChanged += Stretch_CheckedChanged;


            sulge = new Button()
            {
                Text = "Kinni",
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
            selge = new Button()
            {
                Text = "Kustuta",
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
            näidata = new Button()
            {
                Text = "Näita",
                BackColor = Color.White,
                ForeColor = Color.Black,

            };
            näidata.Click += Tegevus;
            selge.Click += Tegevus;
            sulge.Click += Tegevus;
            Button[] buttons = { selge, näidata, sulge };
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle,
            };
            flowLayoutPanel.Controls.AddRange(buttons);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel, 1, 1);
            this.Controls.Add(tableLayoutPanel1);

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";

        }

        private void Stretch_CheckedChanged(object sender, EventArgs e)
        {
            if (box.Checked)
                pilt.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pilt.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void Tegevus(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            if (nupp_sender.Text == "Näita")
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pilt.Load(openFileDialog.FileName);
                }
            }
            else if (nupp_sender.Text == "Kustuta")
            {
                pilt.Image = null;
            }
            else if (nupp_sender.Text == "Kinni")
            {
                this.Close();
            }
        }
    }
}
