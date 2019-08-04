using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Japolingo_0._0._1.Implementaciones
{
    class Kanji
    {
        public int[,] HashMap(Bitmap bitmap)
        {
            try
            {
                var imgArray = new int[bitmap.Width, bitmap.Height];
                var blackArgb = Color.Black.ToArgb();
                var whiteArgb = Color.White.ToArgb();
                int iaux = 0;
                int jaux = 0;

                for (var i = 0; i < bitmap.Width; i++)
                {
                    for (var j = 0; j < bitmap.Height; ++j)
                    {

                        var pixelCol = bitmap.GetPixel(i, j);

                        if (pixelCol.ToArgb() == blackArgb)
                        {
                            imgArray[i, j] = 1;
                        }
                        else
                        {
                            imgArray[i, j] = 0;
                        }

                        jaux = j;
                    }
                    iaux = i;
                }

                return imgArray;

                /*for (int w = 0; w < jaux; w++)
                {
                    for (int h = 0; h < iaux; h++)
                    {
                        Console.Write(imgArray[h, w]);
                    }

                    Console.Write('\n');
                }*/
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new int[0, 0];
            }
        }
        public int NormInfMatrix(int[,] Matrix)
        {
            try
            {
                int numberofColumns = Matrix.GetLength(1);
                int numberofRows = Matrix.GetLength(0);
                int[] columnSum = new int[numberofColumns];

                for (int j = 0; j < numberofColumns; j++)
                {
                    int aux = 0;
                    for (int i = 0; i < numberofRows; i++)
                    {
                        aux += Math.Abs(Matrix[i, j]);
                    }
                    columnSum[j] = aux;
                }
                return columnSum.Max();

            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return 0;
            }

        }
        public float Distance(int[,] Matrix1, int[,] Matrix2)
        {
            try
            {
                int numberofColumns = Matrix1.GetLength(1);
                int numberofRows = Matrix1.GetLength(0);
                int poss = numberofColumns * numberofRows;
                int distance = 0;
                float perc = 0;

                for (int i = 0; i < numberofRows; i++)
                {
                    for (int j = 0; j < numberofColumns; j++)
                    {
                        distance+= Math.Abs(Matrix1[i, j] - Matrix2[i, j]);
                    }
                }
                perc = float.Parse(distance.ToString()) / float.Parse(poss.ToString());
                return perc;
                //return (NormInfMatrix(Diference(Matrix1, Matrix2)));
            }

            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return -1;
            }
        }
        public int[,] Diference(int[,] Matrix1, int[,] Matrix2)
        {
            try
            {
                //MessageBox.Show("El tamaño de la matriz 1 es de " + Matrix1.GetLength(0) + " filas y " +  Matrix1.GetLength(1) + " columnas");
                //MessageBox.Show("El tamaño de la matriz 2 es de " + Matrix2.GetLength(0) + " filas y " + Matrix2.GetLength(1) + " columnas");
                int numberofColumns = Matrix1.GetLength(1);
                int numberofRows = Matrix1.GetLength(0);
                int[,] ResultMatrix = new int[numberofRows, numberofColumns];

                for (int i = 0; i < numberofRows; i++)
                {
                    for (int j = 0; j < numberofColumns; j++)
                    {
                        ResultMatrix[i, j] = Matrix1[i, j] - Matrix2[i, j];
                    }
                }
                return ResultMatrix;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new int[0, 0];
            }
        }
        /*public List<List<int>> SparseM(int[,] Matrix)
        {
            try
            {
                List<List<int>> sparseN = new List<List<int>>();
                int numberofColumns = Matrix.GetLength(1);
                int numberofRows = Matrix.GetLength(0);

                for (int i = 0; i < numberofRows; i++)
                {
                    for (int j = 0; j < numberofColumns; j++)
                    {
                        ResultMatrix[i, j] = Matrix1[i, j] - Matrix2[i, j];
                    }
                }
                return sparseN;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new List<List<int>>();
            }
        }*/
        public void SaveMatrix(int[,] Matrix)
        {
            try
            {
                string[,] dataTable = new string[Matrix.GetLength(0), Matrix.GetLength(1)];
                int numberofColumns = Matrix.GetLength(1);
                int numberofRows = Matrix.GetLength(0);

                for (int i = 0; i < numberofRows; i++)
                {
                    for (int j = 0; j < numberofColumns; j++)
                    {
                        dataTable[i, j] = Matrix[i, j].ToString();
                    }
                }


                List<string> linesToWrite = new List<string>();
                for (int rowIndex = 0; rowIndex < numberofRows; rowIndex++)
                {
                    StringBuilder line = new StringBuilder();
                    for (int colIndex = 0; colIndex < numberofColumns; colIndex++)
                        line.Append(dataTable[rowIndex, colIndex]).Append(",");
                    linesToWrite.Add(line.ToString());
                }
                string path = Launcher.Directory.Path + "\\src\\Kanjis\\" + "Kanji0" + ".txt";

                System.IO.File.WriteAllLines(path, linesToWrite.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
            }
        }
        public int[,] Traspose(int[,] Matrix)
        {
            try
            {
                int numberofColumns = Matrix.GetLength(1);
                int numberofRows = Matrix.GetLength(0);
                int[,] ResultMatrix = new int[numberofColumns,numberofRows];

                for (int i = 0; i < numberofRows; i++)
                {
                    for (int j = 0; j < numberofColumns; j++)
                    {
                        ResultMatrix[j, i] = Matrix[i, j];
                    }
                }
                return ResultMatrix;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new int[0, 0];
            }
        }
        public int[,] GetMatrix(string path)
        {
            try
            {
                int[][] list = File.ReadAllLines(path).Select(l => l.Split(',').Select(i => int.Parse(i)).ToArray()).ToArray();
                return JaggedToMultidimensional(list);

            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new int[0, 0];
            }
        }
        public T[,] JaggedToMultidimensional<T>(T[][] jaggedArray)
        {
            try
            {
                int rows = jaggedArray.Length;
                int cols = jaggedArray.Max(subArray => subArray.Length);
                T[,] array = new T[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    cols = jaggedArray[i].Length;
                    for (int j = 0; j < cols; j++)
                    {
                        array[i, j] = jaggedArray[i][j];
                    }
                }
                return array;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new T[0, 0];
            }

        }
        public List<string> returnlecture(string kanji)
        {
            try
            {
                string path = Launcher.Directory.Path + "\\src\\Kanjis\\kanjis.csv";

                List<string> lectures = new List<string>();

                List<string> list1 = new List<string>();
                List<string> list2 = new List<string>();
                List<string> list3 = new List<string>();
                List<string> list4 = new List<string>();

                using (var reader = new StreamReader(path))
                {                   
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        list1.Add(values[0]);
                        list2.Add(values[1]);
                        list3.Add(values[2]);
                        list4.Add(values[3]);
                    }
                }
                int index = list2.FindIndex(a => a.Contains(kanji));

                lectures.Add(list3[index]);
                lectures.Add(list4[index]);
                lectures.Add(list1[index]);

                return lectures;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return new List<string>();
            }
        }
    }
}
