﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Japolingo_0._0._1.Implementaciones
{
    class Estadistica
    {
        public void GetStatistics(List<string> type, List<double> score)
        {
            try
            {
                SQLConexion con = new SQLConexion(Launcher.Cadena.CadenaC);
                con.open();
                string userid = Launcher.Userdata.IdUsuario;
                String[] sqlParams = new string[] { userid };
                DataTable dt = con.select("SELECT p.Tipo, AVG(CAST(pc.Scoring AS DECIMAL(10,2)))*10 AS 'AVG' FROM dbo.Preguntas_contestadas pc LEFT JOIN dbo.Preguntas p ON pc.Id_Pregunta=p.Id WHERE [Id_Usuario] = @1 GROUP BY p.Tipo", sqlParams);
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("No hay estadísticas para el usuario");
                }
                else
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        type.Add(dt.Rows[i][0].ToString());
                        score.Add(System.Convert.ToDouble(dt.Rows[i][1].ToString()));
                    }
                }
                con.close();

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
