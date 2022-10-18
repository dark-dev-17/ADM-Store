using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using System.Data;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services
{
    internal class ConnectionDB
    {
        private SqlConnection _SqlConnection;
        private readonly string _stringConnection = "";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ConnectionDB()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _stringConnection = "Server=(localdb)\\MSSQLLocalDB;Database=admstore;Trusted_Connection=True;";
        }

        public string IsOpen()
        {
            if (_SqlConnection.State != ConnectionState.Open)
            {
                return "No connection to DB";
            }
            return "Connected to db";
        }

        public void Open()
        {
            _SqlConnection = new SqlConnection(_stringConnection);
            _SqlConnection.Open();
        }

        public void Close()
        {
            if( _SqlConnection == null)
            {
                throw new NullReferenceException(nameof(_SqlConnection));
            }

            _SqlConnection.Close();
        }
    }
}
