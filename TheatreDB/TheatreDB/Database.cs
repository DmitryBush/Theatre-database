using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreDB
{
    class DataBase
    {
        private static readonly string connectStr
                = "Host=localhost;port=5432;Username=guest;Password=guest;Database=theatre";
        private static NpgsqlConnection conn = new NpgsqlConnection(connectStr);

        ~DataBase()
        {
            DisconnectDBAsync();
        }

        public void ConnectDB()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public async void DisconnectDBAsync()
        {
            if (conn.State != ConnectionState.Closed)
                await conn.CloseAsync();
        }

        public NpgsqlConnection GetConnection()
        { return conn; }
    }
}
