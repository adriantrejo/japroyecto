using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Japolingo_0._0._1.GUI;
using System.Text.RegularExpressions;

namespace Japolingo_0._0._1.Implementaciones
{
    class Examen
    {
        public List<string> preguntas = new List<string>();
        public List<string> respuestas = new List<string>();
        public List<string> tipo = new List<string>();
        public List<string> Id_preguntas = new List<string>();
        public string usrlvl;
        public string username = Launcher.Userdata.Nombreusuario;

        public string SustituirTildes(string inputString)
        {
            Regex a = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex e = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex i = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex o = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex u = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            Regex n = new Regex("[ñ|Ñ]", RegexOptions.Compiled);
            inputString = a.Replace(inputString, "a");
            inputString = e.Replace(inputString, "e");
            inputString = i.Replace(inputString, "i");
            inputString = o.Replace(inputString, "o");
            inputString = u.Replace(inputString, "u");
            inputString = n.Replace(inputString, "n");
            return inputString;
        }
        public string ExtractNumber(string original)
        {
            return new string(original.Where(c => Char.IsNumber(c)).ToArray());
        }
        public void RellenarListas()
        {
            try
            {
                SQLConexion con = new SQLConexion(Launcher.Cadena.CadenaC);
                con.open();
                String[] sqlParams1 = new string[] { username };
                DataTable dt1 = con.select("SELECT [Nivel] FROM Usuarios WHERE [Nombre Usuario] = @1", sqlParams1);

                usrlvl = dt1.Rows[0][0].ToString();
                String[] sqlParams2 = new string[] { usrlvl };
                DataTable dt2 = con.select("SELECT * FROM Preguntas LEFT JOIN Preguntas_Nivel ON Preguntas.Id = Preguntas_Nivel.Id WHERE Preguntas_Nivel.Nivel <= @1", sqlParams2);

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    preguntas.Add(dt2.Rows[i][1].ToString());
                    respuestas.Add(dt2.Rows[i][2].ToString());
                    tipo.Add(dt2.Rows[i][3].ToString());
                    Id_preguntas.Add(dt2.Rows[i][0].ToString());
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
        public List<List<string>> Randomize(int n, List<string> listap, List<string> listar, List<string> listaids)
        {
            try
            {
                List<List<string>> randomList = new List<List<string>>();
                List<string> randompList = new List<string>();
                List<string> randomrList = new List<string>();
                List<string> randomIdList = new List<string>();
                Random r = new Random();
                int randomIndex = 0;
                int i = 0;
                while (i < n)
                {
                    randomIndex = r.Next(0, listap.Count); //Choose a random object in the list
                    randompList.Add(listap[randomIndex]); // añadimos a la lista de preguntas
                    randomrList.Add(listar[randomIndex]); // añadimos a la lista de respuestas
                    randomIdList.Add(listaids[randomIndex]); // añadimos a la lista de respuestas
                    listap.RemoveAt(randomIndex); //remove to avoid duplicates
                    listar.RemoveAt(randomIndex); //remove to avoid duplicates
                    listaids.RemoveAt(randomIndex); //remove to avoid duplicates
                    i++;
                }
                randomList.Add(randompList);
                randomList.Add(randomrList);
                randomList.Add(randomIdList);
                return randomList; //return the new random list


            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new List<List<string>>();
            }
        }
        public List<int> Correctas(List<string> respuestasI, List<string> respuestasC)
        {
            try
            {
                List<int> correctas = new List<int>();
                for (int i = 0; i < respuestasI.Count; i++)
                {
                    if (respuestasI[i].Equals(respuestasC[i]))
                    {
                        correctas.Add(i);
                    }
                }
                return correctas;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new List<int>();
            }
        }
        public void ColorP(TextBox txtb, List<int> correctas, List<string> respuestasC, int i)
        {
            try
            {
                //MessageBox.Show("La correcta es " + respuestasC[9 - i]);
                if (correctas.Contains(9 - i))
                {
                    txtb.ForeColor = Color.Green;
                }
                else
                {
                    txtb.ForeColor = Color.Red;
                    txtb.Text = respuestasC[9 - i];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
            }
        }
        public void ActNivel(int score, string usrlvl)
        {
            try
            {
                if (score >= 6)
                {
                    SQLConexion con = new SQLConexion(Launcher.Cadena.CadenaC);
                    con.open();
                    string aux = usrlvl;
                    usrlvl = (System.Convert.ToInt32(aux) + 1).ToString();
                    String[] sqlParams2 = new string[] { username, usrlvl };
                    int dt2 = con.update("UPDATE Usuarios SET Nivel = @2 WHERE [Nombre Usuario] = @1", sqlParams2);
                    MessageBox.Show("Enhorabuena has subido de nivel a la " + usrlvl);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
            }
        }
        public void InsertarPreguntas(List<int> puntuaciones, List<string> ids)
        {
            try
            {
                SQLConexion con = new SQLConexion(Launcher.Cadena.CadenaC);
                con.open();
                String[] sqlParams1 = new String[] { };
                DataTable dt1 = con.select("SELECT TOP 1 Id FROM Preguntas_Contestadas ORDER BY Id desc ", sqlParams1);
                string lastId = dt1.Rows[0][0].ToString();
                for (int i = 0; i < ids.Count; i++)
                {
                    lastId = (Convert.ToInt32(lastId) + 1).ToString();
                    int aux = 0;
                    if (puntuaciones.Contains(i))
                    {
                        aux = 1;
                    }
                    String[] sqlParams2 = new String[] { lastId, Launcher.Userdata.IdUsuario, ids[i], aux.ToString() };
                    int dt2 = con.update("INSERT INTO Preguntas_Contestadas (Id, Id_usuario, Id_pregunta, Scoring) VALUES (@1,@2,@3,@4)", sqlParams2);

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
        public void CheckBox(RadioButton rb, List<bool> arrayBool, int i)
        {
            try
            {
                if (arrayBool[i])
                {
                    rb.Checked = true;
                }
                else
                {
                    rb.Checked = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
            }
        }
        public List<bool> GenerateArray(List<string> respuestasC)
        {
            try
            {
                List<bool> RadioButtons = new List<bool> { };
                for (int i = 0; i < respuestasC.Count(); i++)
                {
                    if ((respuestasC[i]).Equals("Sí"))
                    {
                        RadioButtons.Add(true);
                        RadioButtons.Add(false);
                    }
                    else
                    {
                        RadioButtons.Add(false);
                        RadioButtons.Add(true);
                    }
                }
                return RadioButtons;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new List<bool> { };
            }
        }
        public List<bool> GenerateArrayColor(List<string> respuestasI, List<string> respuestasC)
        {
            try
            {
                List<bool> RadioButtonsC = new List<bool> { };
                for (int i = 0; i < respuestasC.Count(); i++)
                {
                    if (!SustituirTildes(respuestasI[i]).Equals(SustituirTildes(respuestasC[i])))
                    {
                        if (!(respuestasC[i]).Equals("Sí"))
                        {
                            RadioButtonsC.Add(false);
                            RadioButtonsC.Add(true);
                        }
                        else
                        {
                            RadioButtonsC.Add(true);
                            RadioButtonsC.Add(false);
                        }
                    }
                    else
                    {
                        RadioButtonsC.Add(false);
                        RadioButtonsC.Add(false);
                    }
                }
                return RadioButtonsC;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new List<bool> { };
            }
        }
        public void ColorR(RadioButton rb, List<bool> RadioButtonsC, int i)
        {
            try
            {
                if (RadioButtonsC[i])
                {
                    rb.ForeColor = Color.Red;
                }
                
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
    

