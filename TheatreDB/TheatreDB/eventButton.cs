using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheatreDB
{
    internal class EventButton
    {
        public const int defPosX = 21, defPosY = 122;
        private PictureBox picEvent = new PictureBox();
        private Label nameEvent, dateEvent, initPrice;
        private Button button;
        private Panel panel = new Panel();
        public EventButton()
        {
            nameEvent = new Label();
            dateEvent = new Label();
            initPrice = new Label();

            // Name of Event init
            nameEvent.AutoSize = true;
            nameEvent.Font = 
                new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            nameEvent.Location = new System.Drawing.Point(3, 136);
            nameEvent.Name = "label1";
            nameEvent.Size = new System.Drawing.Size(138, 32);
            nameEvent.TabIndex = 1;
            nameEvent.Text = "Name Event";

            // Price text
            initPrice.AutoSize = true;
            initPrice.Font = 
                new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            initPrice.Location = new System.Drawing.Point(213, 174);
            initPrice.Name = "label2";
            initPrice.Size = new System.Drawing.Size(95, 25);
            initPrice.TabIndex = 2;
            initPrice.Text = "От 1000 р.";

            // Date init
            dateEvent.AutoSize = true;
            dateEvent.Font = new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dateEvent.Location = new System.Drawing.Point(4, 174);
            dateEvent.Name = "label9";
            dateEvent.Size = new System.Drawing.Size(148, 25);
            dateEvent.TabIndex = 3;
            dateEvent.Text = "Пн, 29 Янв 17:00";

            // Picture of event
            picEvent.BackColor = System.Drawing.Color.Gainsboro;
            picEvent.Location = new System.Drawing.Point(0, 0);
            picEvent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picEvent.Name = "pictureBox1";
            picEvent.Size = new System.Drawing.Size(311, 133);
            picEvent.TabIndex = 0;
            picEvent.TabStop = false;

            // Panel controll
            panel.Controls.Add(nameEvent);
            panel.Controls.Add(initPrice);
            panel.Controls.Add(picEvent);
            panel.Controls.Add(dateEvent);
            panel.Cursor = System.Windows.Forms.Cursors.Hand;
            panel.Location = new System.Drawing.Point(21, 122);
            panel.Name = "panel1";
            panel.Size = new System.Drawing.Size(311, 211);
            panel.TabIndex = 3;
        }

        public void SetName(string name)
        { nameEvent.Text = name; }

        public void SetPrice(int price)
        { initPrice.Text = $"От {price} р."; }

        public void SetPicture(string path)
        { picEvent.ImageLocation = path; }

        public Panel GetPanel() { return panel; }

        public void SetPanelLocation(int x, int y) 
        { panel.Location = new System.Drawing.Point(x, y); }
    }
}
