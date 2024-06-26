﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheatreDB
{
    internal class EventButton
    {
        private static int copyCount = 0;
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
            nameEvent.Name = $"name{copyCount}";
            nameEvent.Size = new System.Drawing.Size(138, 32);
            nameEvent.TabIndex = 1;
            nameEvent.Text = "Name Event";

            // Price text
            initPrice.AutoSize = true;
            initPrice.Font = 
                new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            initPrice.Location = new System.Drawing.Point(213, 174);
            initPrice.Name = $"price{copyCount}";
            initPrice.Size = new System.Drawing.Size(95, 25);
            initPrice.TabIndex = 2;
            initPrice.Text = "От 1000 р.";

            // Date init
            dateEvent.AutoSize = true;
            dateEvent.Font = new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dateEvent.Location = new System.Drawing.Point(4, 174);
            dateEvent.Name = $"date{copyCount}";
            dateEvent.Size = new System.Drawing.Size(148, 25);
            dateEvent.TabIndex = 3;
            dateEvent.Text = "Пн, 29 Янв 17:00";

            // Picture of event
            picEvent.BackColor = System.Drawing.Color.Gainsboro;
            picEvent.Location = new System.Drawing.Point(0, 0);
            picEvent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picEvent.Name = $"pictureBox{copyCount}";
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
            panel.Name = $"panel{copyCount}";
            panel.Size = new System.Drawing.Size(311, 211);
            panel.TabIndex = 3;

            copyCount++;
        }

        public EventButton(DataRow row)
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
            nameEvent.Name = $"name{copyCount}";
            nameEvent.Size = new System.Drawing.Size(138, 32);
            nameEvent.TabIndex = 1;
            SetName((string)row["name"]);

            // Price text
            initPrice.AutoSize = true;
            initPrice.Font =
                new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            initPrice.Location = new System.Drawing.Point(213, 174);
            initPrice.Name = $"price{copyCount}";
            initPrice.Size = new System.Drawing.Size(95, 25);
            initPrice.TabIndex = 2;
            SetPrice((int)row["initial_price"]);

            // Date init
            dateEvent.AutoSize = true;
            dateEvent.Font = new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dateEvent.Location = new System.Drawing.Point(4, 174);
            dateEvent.Name = $"date{copyCount}";
            dateEvent.Size = new System.Drawing.Size(148, 25);
            dateEvent.TabIndex = 3;
            SetEvent((DateTime)row["date_event"]);

            // Picture of event
            picEvent.BackColor = System.Drawing.Color.Gainsboro;
            picEvent.Location = new System.Drawing.Point(0, 0);
            picEvent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picEvent.Name = $"pictureBox{copyCount}";
            picEvent.Size = new System.Drawing.Size(311, 133);
            picEvent.TabIndex = 0;
            picEvent.TabStop = false;
            SetPicture((string)row["url"]);

            // Panel controll
            panel.Controls.Add(nameEvent);
            panel.Controls.Add(initPrice);
            panel.Controls.Add(picEvent);
            panel.Controls.Add(dateEvent);
            panel.Cursor = System.Windows.Forms.Cursors.Hand;
            panel.Location = new System.Drawing.Point(21, 122);
            panel.Name = $"panel{copyCount}";
            panel.Size = new System.Drawing.Size(311, 211);
            panel.TabIndex = 3;

            copyCount++;
        }

        public void SetName(string name)
        { nameEvent.Text = name; }

        public void SetEvent(DateTime reader)
        {
            dateEvent.Text = $"{DefineDayOfWeek(reader.DayOfWeek)}, {reader.Day} " +
                $"{DefineMonth(reader.Month)} {FormattingClock(reader.Hour)}:" +
                $"{FormattingClock(reader.Minute)}";
        }

        private string DefineDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return "Пн";
                case DayOfWeek.Tuesday:
                    return "Вт";
                case DayOfWeek.Wednesday:
                    return "Ср";
                case DayOfWeek.Thursday:
                    return "Чт";
                case DayOfWeek.Friday:
                    return "Пт";
                case DayOfWeek.Saturday:
                    return "Сб";
                case DayOfWeek.Sunday:
                    return "Вс";
                default:
                    return "NaN";
            }
        }

        private string DefineMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "Янв";
                case 2:
                    return "Фев";
                case 3:
                    return "Март";
                case 4:
                    return "Апр";
                case 5:
                    return "Май";
                case 6:
                    return "Июнь";
                case 7:
                    return "Июль";
                case 8:
                    return "Авг";
                case 9:
                    return "Сент";
                case 10:
                    return "Окт";
                case 11:
                    return "Нояб";
                case 12:
                    return "Дек";
                default:
                    return "NaN";
            }
        }

        private string FormattingClock(int clock)
        {
            if (clock < 10)
                return $"0{clock}";
            else
                return $"{clock}";
        }

        public void SetPrice(int price)
        { initPrice.Text = $"От {price} р."; }

        public void SetPicture(string URL)
        { picEvent.LoadAsync(URL); }

        public Panel GetPanel() { return panel; }

        public void SetPanelLocation(int x, int y) 
        { panel.Location = new System.Drawing.Point(x, y); }
    }
}
