using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {        
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
                    //DGV1.Rows[j].Cells[i].Style.BackColor = Color.LightBlue;
                }
            }
            /* конец покраски */

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
            dataGridView1.Rows.Clear(); //очищаем поле для генерации нового уровня
            GenerateMap(); //генерируем карту
            Random r = new Random();
            int helpCells = 0;

            /* расставляем цифры */
            if (сложныйToolStripMenuItem.Checked)
            {
                helpCells = r.Next(4, 6); //число клеток с проставленными цифрами
                
            }
            else if (среднийToolStripMenuItem.Checked)
            {
                helpCells = r.Next(5, 7); //число клеток с проставленными цифрами

            }
            else if (легкийToolStripMenuItem1.Checked)
            {
                helpCells = r.Next(6, 8); //число клеток с проставленными цифрами

            }    
            /* конец расстановок */
        }
    }
}
