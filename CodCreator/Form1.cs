using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CodCreator
{
    public partial class Form1 : Form
    {
        StringBuilder scriptBuilder = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("3х3");
            checkedListBox1.Items.Add("5х5");
            checkedListBox1.Items.Add("7х7");
            checkedListBox1.Items.Add("9х9", true);
            checkedListBox2.Items.Add("Зверху вниз");
            checkedListBox2.Items.Add("Зліва Направо");
            checkedListBox2.Items.Add("Повна дзеркальність");

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Crate_Click(object sender, EventArgs e)
        {
            // Формуємо матрицю предметів
            string[,] items = new string[9, 9];
            {
                items[0, 0] = t11.Text;
                items[0, 1] = t12.Text;
                items[0, 2] = t13.Text;
                items[0, 3] = t14.Text;
                items[0, 4] = t15.Text;
                items[0, 5] = t16.Text;
                items[0, 6] = t17.Text;
                items[0, 7] = t18.Text;
                items[0, 8] = t19.Text;

                items[1, 0] = t21.Text;
                items[1, 1] = t22.Text;
                items[1, 2] = t23.Text;
                items[1, 3] = t24.Text;
                items[1, 4] = t25.Text;
                items[1, 5] = t26.Text;
                items[1, 6] = t27.Text;
                items[1, 7] = t28.Text;
                items[1, 8] = t29.Text;

                items[2, 0] = t31.Text;
                items[2, 1] = t32.Text;
                items[2, 2] = t33.Text;
                items[2, 3] = t34.Text;
                items[2, 4] = t35.Text;
                items[2, 5] = t36.Text;
                items[2, 6] = t37.Text;
                items[2, 7] = t38.Text;
                items[2, 8] = t39.Text;

                items[3, 0] = t41.Text;
                items[3, 1] = t42.Text;
                items[3, 2] = t43.Text;
                items[3, 3] = t44.Text;
                items[3, 4] = t45.Text;
                items[3, 5] = t46.Text;
                items[3, 6] = t47.Text;
                items[3, 7] = t48.Text;
                items[3, 8] = t49.Text;

                items[4, 0] = t51.Text;
                items[4, 1] = t52.Text;
                items[4, 2] = t53.Text;
                items[4, 3] = t54.Text;
                items[4, 4] = t55.Text;
                items[4, 5] = t56.Text;
                items[4, 6] = t57.Text;
                items[4, 7] = t58.Text;
                items[4, 8] = t59.Text;

                items[5, 0] = t61.Text;
                items[5, 1] = t62.Text;
                items[5, 2] = t63.Text;
                items[5, 3] = t64.Text;
                items[5, 4] = t65.Text;
                items[5, 5] = t66.Text;
                items[5, 6] = t67.Text;
                items[5, 7] = t68.Text;
                items[5, 8] = t69.Text;

                items[6, 0] = t71.Text;
                items[6, 1] = t72.Text;
                items[6, 2] = t73.Text;
                items[6, 3] = t74.Text;
                items[6, 4] = t75.Text;
                items[6, 5] = t76.Text;
                items[6, 6] = t77.Text;
                items[6, 7] = t78.Text;
                items[6, 8] = t79.Text;

                items[7, 0] = t81.Text;
                items[7, 1] = t82.Text;
                items[7, 2] = t83.Text;
                items[7, 3] = t84.Text;
                items[7, 4] = t85.Text;
                items[7, 5] = t86.Text;
                items[7, 6] = t87.Text;
                items[7, 7] = t88.Text;
                items[7, 8] = t89.Text;

                items[8, 0] = t91.Text;
                items[8, 1] = t92.Text;
                items[8, 2] = t93.Text;
                items[8, 3] = t94.Text;
                items[8, 4] = t95.Text;
                items[8, 5] = t96.Text;
                items[8, 6] = t97.Text;
                items[8, 7] = t98.Text;
                items[8, 8] = t99.Text;
            }


            // Формуємо рядок шаблону згідно з отриманими даними
            StringBuilder scriptBuilder = new StringBuilder();


            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    switch (i)
                    {
                        case 3:
                            GenerateScript(items, scriptBuilder, 0, 9, false);
                            break;
                        case 2:
                            GenerateScript(items, scriptBuilder, 1, 8, false);
                            break;
                        case 1:
                            GenerateScript(items, scriptBuilder, 2, 7, false);
                            break;
                        case 0:
                            GenerateScript(items, scriptBuilder, 3, 6, true);
                            break;
                    }
                    break;
                }
            }
            scriptBuilder.AppendLine("]));");
            // Виводимо результат
            Out.Text = scriptBuilder.ToString();

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Зміна верстаку
            if (e.Index < 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Зміна дзеркала
            if (e.Index < 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox2.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void GenerateScript(string[,] items, StringBuilder scriptBuilder, int s, int f, bool type)
        {
            // Формуємо вихідний предмет
            string outputItem = OutItem.Text;

            if (type)
            {
                scriptBuilder.AppendLine($"recipes.addShaped({outputItem},");
                scriptBuilder.AppendLine("([");
                for (int i = s; i < f; i++)
                {
                    scriptBuilder.Append("[");
                    for (int j = s; j < f; j++)
                    {
                        scriptBuilder.Append(items[i, j] != null ? $" {items[i, j]} " : " null ");
                        if (j < f - 1)
                            scriptBuilder.Append(", ");
                    }
                    if (i != f - 1)
                    {
                        scriptBuilder.AppendLine("],");
                    }
                    else
                    {
                        scriptBuilder.AppendLine("]");
                    }
                }
            } else
            {
                scriptBuilder.AppendLine($"ru.minecraftonly.BigCraft.addShaped(1,{outputItem},");
                scriptBuilder.AppendLine("([");
                for (int i = s; i < f; i++)
                {
                    scriptBuilder.Append("[");
                    for (int j = s; j < f; j++)
                    {
                        scriptBuilder.Append(items[i, j] != null ? $" {items[i, j]} " : " null ");
                        if (j < f - 1)
                            scriptBuilder.Append(", ");
                    }
                    if (i != f - 1)
                    {
                        scriptBuilder.AppendLine("],");
                    }
                    else
                    {
                        scriptBuilder.AppendLine("]");
                    }
                }
            }

           
        }
        
        private void Clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    // Формуємо ім'я текстового поля на основі індексів і очищаємо його
                    System.Windows.Forms.TextBox textBox = Controls.Find($"t{i}{j}", true).FirstOrDefault() as System.Windows.Forms.TextBox;
                    textBox?.Clear();
                }
            }

        }

        private void Mirror_Click(object sender, EventArgs e)
        {
            //Зверху вниз
            if (checkedListBox2.GetItemChecked(0))
            {
                for (int i = 0; i <= 4; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        string textBoxName = "t" + (i + 1).ToString() + (j + 1).ToString();
                        string OuttextBoxName = "t" + (9 - i).ToString() + (j + 1).ToString();
                        System.Windows.Forms.TextBox currentTextBox = Controls.Find(textBoxName, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                        System.Windows.Forms.TextBox outTextBox = Controls.Find(OuttextBoxName, true).FirstOrDefault() as System.Windows.Forms.TextBox;

                        if (currentTextBox != null && !string.IsNullOrWhiteSpace(currentTextBox.Text))
                        {
                            outTextBox.Text = currentTextBox.Text;
                        }
                    }
                }
            }

            //Зліва направо
            if (checkedListBox2.GetItemChecked(1))
            {
                for (int i = 0; i <= 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string textBoxName = "t" + (i + 1).ToString() + (j + 1).ToString();
                        string OuttextBoxName = "t" + (i + 1).ToString() + (9 - j).ToString();
                        System.Windows.Forms.TextBox currentTextBox = Controls.Find(textBoxName, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                        System.Windows.Forms.TextBox outTextBox = Controls.Find(OuttextBoxName, true).FirstOrDefault() as System.Windows.Forms.TextBox;

                        if (currentTextBox != null && !string.IsNullOrWhiteSpace(currentTextBox.Text))
                        {
                            outTextBox.Text = currentTextBox.Text;
                        }
                    }
                }
            }

            //Повне відзеркалення
            if (checkedListBox2.GetItemChecked(2))
            {
                for (int i = 0; i <= 4; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        string textBoxName = "t" + (i + 1).ToString() + (j + 1).ToString();
                        string OuttextBoxName = "t" + (9 - i).ToString() + (j + 1).ToString();
                        System.Windows.Forms.TextBox currentTextBox = Controls.Find(textBoxName, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                        System.Windows.Forms.TextBox outTextBox = Controls.Find(OuttextBoxName, true).FirstOrDefault() as System.Windows.Forms.TextBox;

                        if (currentTextBox != null && !string.IsNullOrWhiteSpace(currentTextBox.Text))
                        {
                            outTextBox.Text = currentTextBox.Text;
                        }
                    }
                }
                for (int i = 0; i <= 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string textBoxName = "t" + (i + 1).ToString() + (j + 1).ToString();
                        string OuttextBoxName = "t" + (i + 1).ToString() + (9 - j).ToString();
                        System.Windows.Forms.TextBox currentTextBox = Controls.Find(textBoxName, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                        System.Windows.Forms.TextBox outTextBox = Controls.Find(OuttextBoxName, true).FirstOrDefault() as System.Windows.Forms.TextBox;

                        if (currentTextBox != null && !string.IsNullOrWhiteSpace(currentTextBox.Text))
                        {
                            outTextBox.Text = currentTextBox.Text;
                        }
                    }
                }

            }
        }

    }
}
