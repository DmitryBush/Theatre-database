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
        }

        private async void LoadEventsScreen()
        {
            try
            {
                using (var command = new NpgsqlCommand("select name from events", db.GetConnection()))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var someFieldValue = reader["name"];
                        label1.Text = (string)someFieldValue;
                    }
                }
            }
            catch (Exception)
            {
                throw;
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
    }
}
