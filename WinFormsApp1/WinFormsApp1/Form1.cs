using System.CodeDom.Compiler;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{    
    public partial class Form1 : Form
    {
        static int[,] grid = new int[9, 9];
        static bool[,] zeroGrid = new bool[9, 9];
        static Random ran = new Random();
        public Form1()
        {
            InitializeComponent();
            GenerateMap();
        }
                
        public void GenerateMap() //создание пустого поля
        {
            for (int i = 0; i < 8; i++) //первая строка уже есть
            {
                dataGridView1.Rows.Add();
            }

            /* делаем красивое поле */
            for (int i = 0; i < 9; i++) //здесь происходит выравнивание размеров ячеек
            {
                DataGridViewColumn column = dataGridView1.Columns[i];
                column.Width = (int)(dataGridView1.Width / 9f);
                DataGridViewRow row = dataGridView1.Rows[i];
                row.Height = (int)(dataGridView1.Height / 9f);
            }
            dataGridView1.Width = dataGridView1.Columns[1].Width * 9;
            /* теперь поле ровное */

            /* покраска поля */
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightCyan;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightBlue;
                    dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.LightBlue;
                }
            }

            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightCyan;
                }
            }
            /* конец покраски */
        }

        static void Generator() //Базовое заполнение
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = ((i * 3 + i / 3 + j) % 9 + 1); 
                }
            }
        }
        static void Transponing() //Транспонирование
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int tmp = grid[i, j];
                    grid[i, j] = grid[j, i];
                    grid[j, i] = tmp;
                }
            }
        }

        static void SwapRows() //Замена рядов
        {
            Random ran = new Random();
            int first = ran.Next(1, 3);
            int second = ran.Next(1, 3);
            int third = ran.Next(4, 6);
            int fourth = ran.Next(4, 6);
            int fifth = ran.Next(7, 9);
            int sixth = ran.Next(7, 9);
            for (int k = 0; k < 9; k++)
            {
                int tmp = grid[first - 1, k];
                grid[first - 1, k] = grid[second - 1, k];
                grid[second - 1, k] = tmp;
            }
            for (int k = 0; k < 9; k++)
            {
                int tmp = grid[third - 1, k];
                grid[third - 1, k] = grid[fourth - 1, k];
                grid[fourth - 1, k] = tmp;
            }
            for (int k = 0; k < 9; k++)
            {
                int tmp = grid[fifth - 1, k];
                grid[fifth - 1, k] = grid[sixth - 1, k];
                grid[sixth - 1, k] = tmp;
            }

        }

        static void SwapColumns() //Замена столбцов
        {
            Transponing();
            SwapRows();
            Transponing();
        }

        public void Filling()
        {
            int rows = dataGridView1.RowCount;
            int cols = dataGridView1.ColumnCount;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] != -1)
                        dataGridView1.Rows[0].Cells[i].Value = grid[i, j];
                    else continue;
                }
            }
        }

        private void СложныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //делаем отмеченным нужный уровень сложности
            сложныйToolStripMenuItem.Checked = true;
            среднийToolStripMenuItem.Checked = false;
            легкийToolStripMenuItem1.Checked = false;
        }

        private void СреднийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //делаем отмеченным нужный уровень сложности
            сложныйToolStripMenuItem.Checked = false;
            среднийToolStripMenuItem.Checked = true;
            легкийToolStripMenuItem1.Checked= false;
        }

        private void ЛегкийToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //делаем отмеченным нужный уровень сложности
            сложныйToolStripMenuItem.Checked = false;
            среднийToolStripMenuItem.Checked = false;
            легкийToolStripMenuItem1.Checked = true; //установлен по умолчанию
        }              

        private void НоваяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid = new int[9, 9];
            zeroGrid = new bool[9, 9];

            dataGridView1.Rows.Clear(); //очищаем поле для генерации нового уровня
            GenerateMap(); //генерируем карту
            int mixx = ran.Next(50, 500); //количество перемешиваний
            Generator(); //заполняем карту
            for (int i = 0; i < mixx; i++)
            {
                Transponing();
                SwapRows();
                SwapColumns();
            }

            /* расставляем цифры */
            if (сложныйToolStripMenuItem.Checked)
            {
                //удаляем некоторые значения в клетках рандомно
                int delete1 = ran.Next(56, 61);
                for (int k = 0; k < delete1; k++)
                {
                    int i = ran.Next() % 9;
                    int j = ran.Next() % 9;
                    if (!zeroGrid[i, j]) //Проверка на пустую ячейку
                    {
                        grid[i, j] = -1;
                        zeroGrid[i, j] = !zeroGrid[i, j];
                    }
                    else { k--; }
                }
                Filling();
            }
            else if (среднийToolStripMenuItem.Checked)
            {
                //удаляем некоторые значения в клетках рандомно
                int delete2 = ran.Next(51, 56);
                for (int k = 0; k < delete2; k++)
                {
                    int i = ran.Next() % 9;
                    int j = ran.Next() % 9;
                    if (!zeroGrid[i, j]) //Проверка на пустую ячейку
                    {
                        grid[i, j] = -1;
                        zeroGrid[i, j] = !zeroGrid[i, j];
                    }
                    else { k--; }
                }
                Filling();
            }
            else if (легкийToolStripMenuItem1.Checked)
            {
                //удаляем некоторые значения в клетках рандомно
                int delete3 = ran.Next(46, 51);
                for (int k = 0; k < delete3; k++)
                {
                    int i = ran.Next() % 9;
                    int j = ran.Next() % 9;
                    if (!zeroGrid[i, j]) //Проверка на пустую ячейку
                    {
                        grid[i, j] = -1;
                        zeroGrid[i, j] = !zeroGrid[i, j];
                    }
                    else { k--; }
                }
                Filling();
            }    
            /* конец расстановок */
        }
    }
}
