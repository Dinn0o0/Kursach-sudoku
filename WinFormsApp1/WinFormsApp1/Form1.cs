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

        private void GenerateMap() //создание пустого поля
        {
            for (int i = 0; i < 8; i++) //первая строка уже есть
            {
                dataGridView1.Rows.Add(); //добавляет строки в dataGridView1
            }
            
            /* делаем красивое поле */
            for (int i = 0; i < 9; i++) //здесь происходит выравнивание размеров ячеек
            {
                DataGridViewColumn column = dataGridView1.Columns[i]; //выбор i-го столбца
                column.Width = (int)(dataGridView1.Width / 9f); //деление пространства dataGridView1 на 9 частей
                DataGridViewRow row = dataGridView1.Rows[i]; // см выше
                row.Height = (int)(dataGridView1.Height / 9f);
            }
            dataGridView1.Width = dataGridView1.Columns[1].Width * 9; //коррекция ширины
            /* теперь поле ровное */

            /* покраска поля */
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightCyan; //красим в голубой
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

        private void BasicFill() //хорошее готовое поле. Но оно полностью заполнено. Полностью решено
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = ((i * 3 + i / 3 + j) % 9 + 1);  //Базовое заполнение
                }
            }
        }

        private void Filling()
        {
            int rows = dataGridView1.RowCount;
            int cols = dataGridView1.ColumnCount;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] != -1) //если ячейка не пустая
                    {
                        dataGridView1.Rows[i].Cells[j].Value = grid[i, j];
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.DarkViolet; //цвет цифр по умолчанию
                    }
                    else continue; //проходим далее
                }
            }
        }

        private static void Deleting(int delete0)
        {
            for (int k = 0; k < delete0; k++)
            {
                int i = ran.Next() % 9; //случайное число выбирается и находится остаток от деления на 9
                int j = ran.Next() % 9;
                if (!zeroGrid[i, j]) //Проверка на пустую ячейку
                {
                    grid[i, j] = -1;
                    zeroGrid[i, j] = !zeroGrid[i, j];
                }
                else { k--; }
            }
        }

        /* реакции на нажатие */
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
            легкийToolStripMenuItem1.Checked = false;
        }

        private void ЛегкийToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //делаем отмеченным нужный уровень сложности
            сложныйToolStripMenuItem.Checked = false;
            среднийToolStripMenuItem.Checked = false;
            легкийToolStripMenuItem1.Checked = true; //установлен по умолчанию
        }
        /* закончились реакции */

        static void Transponing() //Транспонирование. Решаемость не меняется
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int tmp = grid[i, j];
                    grid[i, j] = grid[j, i];
                    grid[j, i] = tmp;

                    bool tmp1 = zeroGrid[i, j];
                    zeroGrid[i, j] = zeroGrid[j, i];
                    zeroGrid[j, i] = tmp1;
                }
            }
        }

        static void SwapRows() //строки в тройках меняются местами
        {
            //первая тройка
            int first = ran.Next(1, 3);
            int second = ran.Next(1, 3);

            //вторая тройка
            int third = ran.Next(4, 6);
            int fourth = ran.Next(4, 6);

            //третья тройка
            int fifth = ran.Next(7, 9);
            int sixth = ran.Next(7, 9);

            //начинаем перемешивать
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
        { //гарантировано, что меняются только столбцы в тройках
            Transponing(); //превращаем столбцы в строки
            SwapRows(); //перемешивание строк
            Transponing(); //транспонирование
        }

        private void НоваяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;

            //создание нового поля
            grid = new int[9, 9];
            zeroGrid = new bool[9, 9];

            dataGridView1.Rows.Clear(); //очищаем поле для генерации нового уровня

            GenerateMap(); //генерируем карту
            BasicFill();

            int mixx = ran.Next(10, 100); //выбираем число перемешиваний. Можно не 40. И не 50
            //гарантировано, что поле решаемо (см код выше)
            for (int i = 0; i < mixx; i++)
            {
                Transponing();
                SwapRows();
                SwapColumns();
            }

            /* удаляем цифры */
            if (сложныйToolStripMenuItem.Checked)
            {
                //удаляем некоторые значения в клетках рандомно
                int delete1 = ran.Next(56, 61);
                Deleting(delete1);
            }
            else if (среднийToolStripMenuItem.Checked)
            {
                //удаляем некоторые значения в клетках рандомно
                int delete2 = ran.Next(51, 56);
                Deleting(delete2);
            }
            else if (легкийToolStripMenuItem1.Checked)
            {
                //удаляем некоторые значения в клетках рандомно
                int delete3 = ran.Next(46, 51);
                Deleting(delete3);
            }
            Filling();
            /* конец расстановок */
        }

        private int ColoringFore(int i, int j, int allCells) //выделение ошибок
        {
            dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Red; //красим циферки
            allCells = 0; //не считаем цифры, не считаем ничего
            pon.Visible = true; //делаем видимой кнопку
            return (allCells);
        }

        private int CheckingMap(int prov)
        {
            int rows = 9; //кол-во строк
            int cols = 9; //кол-во столбцов
            int allCells = 0; //подсчет правильно поставленных цифр -> понадобится для проверки на окончание игры
            
            //заполняем сетку
            for (int i = 0; i < rows; i++)
            {
                int f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0, f6 = 0, f7 = 0, f8 = 0, f9 = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] != -1)
                    {
                        switch (grid[i, j])
                        {
                            case 1: f1++; allCells++; break;
                            case 2: f2++; allCells++; break;
                            case 3: f3++; allCells++; break;
                            case 4: f4++; allCells++; break;
                            case 5: f5++; allCells++; break;
                            case 6: f6++; allCells++; break;
                            case 7: f7++; allCells++; break;
                            case 8: f8++; allCells++; break;
                            case 9: f9++; allCells++; break;
                        }
                    }
                }

                //извлекаем флаги-счетчики
                if (f1 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 1 && zeroGrid[i, j])
                        {
                            if(prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f2 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 2 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f3 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 3 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f4 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 4 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f5 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 5 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f6 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 6 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f7 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 7 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f8 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 8 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
                if (f9 > 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == 9 && zeroGrid[i, j])
                        {
                            if (prov == 0)
                                allCells = ColoringFore(i, j, allCells);
                            else
                                allCells = ColoringFore(j, i, allCells);
                        }
                    }
                }
            }//здесь заканчивается проверка строк на повторяющиеся цифры
            return allCells; //возвращаем кол-во клеток
        }

        private int VeryfySquares()
        {
            int val = 0;
            for (int n = 0; n < 3; n++)
            {
                for (int m = 0; m < 3; m++)
                {
                    List<int> list = new List<int>(9); //список всех правильных клеток
                    List<int> itmp = new List<int>(9);
                    List<int> jtmp = new List<int>(9);
                    /* начинаем проверку в квадрате */
                    for (int i = 0 + n * 3; i < 3 + n * 3; i++) //проверка в квадрате
                    {
                        for (int j = 0 + 3 * m; j < 3 + 3 * m; j++) 
                        {
                            val = grid[i, j];
                            if (val == -1)   // если val=-1 -> не заполенная клетка
                            {
                                continue;
                            }
                            if (list.Contains(val)) //если в квадрате уже есть это значение
                            {
                                if (!zeroGrid[i, j]) //если по умолчанию
                                {
                                    int index = list.IndexOf(val);
                                    ColoringFore(itmp[index], jtmp[index], 0);
                                }  
                                else //не по умолчанию
                                    ColoringFore(i, j, 0); //? красит только последнее вхождение. Эффективно при общей проверке. Неэффективно при частичной, тк красит даже цифры по умолчанию
                                return 0; //обнуляем клетки
                            }
                            else
                            {
                                list.Add(val); //значения нет -> добавляем
                                itmp.Add(i); //сохр коорд
                                jtmp.Add(j);
                            }
                        }
                    }
                    /* конец проверки */
                }
            }
            return 81; //все клетки прошли проверку
        }
        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int allCells = 0; //подсчет правильно поставленных цифр -> понадобится для проверки на окончание игры
            int rows = dataGridView1.RowCount; //кол-во строк
            int cols = dataGridView1.ColumnCount; //кол-во столбцов

            for (int i = 0; i < rows; i++)
            {
                int f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0, f6 = 0, f7 = 0, f8 = 0, f9 = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) != "")
                    {
                        grid[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                        switch (grid[i, j])
                        {
                            case 1: f1++; allCells++; break;
                            case 2: f2++; allCells++; break;
                            case 3: f3++; allCells++; break;
                            case 4: f4++; allCells++; break;
                            case 5: f5++; allCells++; break;
                            case 6: f6++; allCells++; break;
                            case 7: f7++; allCells++; break;
                            case 8: f8++; allCells++; break;
                            case 9: f9++; allCells++; break;
                        }
                    }
                }

                
            }

            allCells += CheckingMap(0); //проверка на строки
            Transponing(); //проверка столбцов
            allCells += CheckingMap(1);
            Transponing(); //возвращаем сетку на место                       
            allCells += VeryfySquares(); //проверка на квадраты

            if(allCells == 81*3)
            {
                label1.Visible = true;
            }            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ничего
        }

        private void Pon_Click(object sender, EventArgs e)
        {
            //поменяем стиль обратно
            pon.Visible = false;            
            int rows = dataGridView1.RowCount;
            int cols = dataGridView1.ColumnCount;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] != -1 && zeroGrid[i, j]) //если ячейка не пустая
                    {
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Black; //заливка ячеек по умолчанию
                    }
                    else continue; //проходим далее
                }
            }
        }
    }
}
