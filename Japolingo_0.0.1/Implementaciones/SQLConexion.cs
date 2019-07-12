using System;
using System.Data.SqlClient;
using Japolingo_0._0._1.Interfaces;
using System.Windows.Forms;
using System.Data;

namespace Japolingo_0._0._1.Implementaciones
{
    class SQLConexion : Iconexion
    {
        private string ConnectionString;
        private SqlConnection con;

        public SQLConexion(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            this.con = new SqlConnection(ConnectionString);
            
        }

        public void open()
        {
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
            }
        }

        public void close()
        {
            try
            {
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
            }
        }

        public DataTable select(string Sselect, string [] parameters)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(Sselect, con);

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.AddWithValue((i + 1).ToString(), parameters[i]);
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new DataTable();
            }
        }

        public int update(string SUpdate,string [] parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(SUpdate, con);
                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.AddWithValue((i + 1).ToString(), parameters[i]);
                }
                int affectedRows = cmd.ExecuteNonQuery();

                return affectedRows;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return 0;
            }
        }
        public int insert(string SInsert, string [] parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(SInsert, con);
                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.AddWithValue((i + 1).ToString(), parameters[i]);
                }
                int affectedRows = cmd.ExecuteNonQuery();

                return affectedRows;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return 0;
            }
        }
        public void executeNonQuery(string insertString)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(insertString, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
            }
        }
    }
}
