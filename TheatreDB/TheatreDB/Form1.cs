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
        private static readonly DataBase db = new DataBase();
        public theatre()
        {
            InitializeComponent();
            db.ConnectDB();
            LoadEventsScreen();
        }

        // Asynchronous element loading
        private async void LoadEventsScreen()
        {

            DataTable dt = new DataTable();
            try
            {
                using (var command = 
                    new NpgsqlCommand("select events.id, name, date_event, initial_price, " +
                    "url from events left join events_photo on events.id = events_photo.event_id " +
                    "order by date_event asc;", 
                    db.GetConnection()))
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
                EventButton button = new EventButton(row);
                button.SetPanelLocation(initX + (397 * rowCountElem),
                    initY);
                Controls.Add(button.GetPanel());
                rowCountElem++;

                if (rowCountElem >= 3)
                {
                    initY += 270;
                    rowCountElem = 0;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void theatre_Load(object sender, EventArgs e)
        {

        }
    }
}
