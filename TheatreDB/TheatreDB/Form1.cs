using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheatreDB
{
    public partial class theatre : Form
    {
        private static DataBase db = new DataBase();
        public theatre()
        {
            InitializeComponent();
            db.ConnectDB();
            LoadEventsScreen();
            //TestButtons();
        }

        private async void LoadEventsScreen()
        {

            DataTable dt = new DataTable();
            try
            {
                using (var command = new NpgsqlCommand("select * from events", db.GetConnection()))
                using (var reader = await command.ExecuteReaderAsync())
                    dt.Load(reader);
            }
            catch (Exception)
            {
                throw;
            }
            
            int rowCountElem = 0;
            int initX = EventButton.defPosX;
            int initY = EventButton.defPosY;
            foreach (DataRow row in dt.Rows)
            {
                //label1.Text = (string)row["name"];
                EventButton button = new EventButton();
                button.SetPanelLocation(initX + 397 * rowCountElem, //rowCountElem,
                    initY);
                button.SetName((string)row["name"]);
                button.SetEvent((DateTime)row["date_event"]);
                button.SetPrice((int)row["initial_price"]);
                button.SetPicture(
                    "https://files.libertycity.net/download/gtasa_newskins/fulls/2020-12/dzhonni-silverkhend-iz-cyberpunk-2077_1686006013_124853.jpg");
                Controls.Add(button.GetPanel());
                rowCountElem++;

                if (rowCountElem >= 3)
                {
                    initY += 270;
                    rowCountElem = 0;
                }
            }
        }

        private void TestButtons()
        {
            int initX = EventButton.defPosX;
            int initY = EventButton.defPosY;
            for (int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    EventButton button = new EventButton();
                    button.SetPanelLocation(initX + 397 * j,
                        initY);
                    button.SetName("Test" + j);
                    button.SetPrice(1000 * j);
                    button.SetPicture(
                        "https://files.libertycity.net/download/gtasa_newskins/fulls/2020-12/dzhonni-silverkhend-iz-cyberpunk-2077_1686006013_124853.jpg");
                    Controls.Add(button.GetPanel());
                }
                initY += 270;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void theatre_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
