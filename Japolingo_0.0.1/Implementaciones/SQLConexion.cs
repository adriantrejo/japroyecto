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
            con.Open();
        }

        public void close()
        {
            con.Close();
        }

        public DataTable select(string Sselect, string [] parameters)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(Sselect, con);

            for(int i=0; i<parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue((i + 1).ToString(), parameters[i]);
            }

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }

        /*--------------------------------DOING----------------------------*/
        public int update(string SUpdate,string [] parameters)
        {
            SqlCommand cmd = new SqlCommand(SUpdate,con);
            for(int i=0; i<parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue((i + 1).ToString(), parameters[i]);
            }
            int affectedRows = cmd.ExecuteNonQuery();

            return affectedRows;
        }
        public int insert(string SInsert, string [] parameters)
        {
            SqlCommand cmd = new SqlCommand(SInsert,con);
            for(int i=0; i<parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue((i + 1).ToString(), parameters[i]);
            }
            int affectedRows = cmd.ExecuteNonQuery();

            return affectedRows;
        }
    }
}
