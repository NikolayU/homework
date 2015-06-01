using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testovoe
{
    public partial class TestTask : Form
    {
        public TestTask()
        {
            InitializeComponent();
        }

        OpenFileDialog openFileDialog2 = new OpenFileDialog();
        OpenFile of = new OpenFile();
        string[] dictionary;  // словарь
        int n ;  // счетчик созданных файлов (0 не пишется)
        const int N = 20;  // количество строк в одном файле

        private void button1_Click(object sender, EventArgs e)
        {
            dictionary = of.getDictionary();
            DictionaryPath.Text = of.Fpath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
             openFileDialog2 = of.getFile();
            TextPath.Text = of.Fpath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DictionaryPath.Text != "" && TextPath.Text != "")
            {
                string[] slova = new string[1000];  // массив слов строки файла с текстом
                char[] simvol;  
                int stroka = 0;
                StreamWriter sw = new StreamWriter("C:/HTMLFile.html", true, System.Text.Encoding.Default);
                using (StreamReader sr = new StreamReader(openFileDialog2.FileName, System.Text.Encoding.Default))
                {
                    bool eq = false;  
                    sw.WriteLine("<html>");

                    // Отделение знаков препинания:
                    while (sr.Peek() >= 0)
                    {
                        Array.Clear(slova, 0, slova.Length);
                        simvol = sr.ReadLine().ToCharArray();
                        int k = 0;
                        for (int l = 0; l < simvol.Length; l++)
                        {
                            if (simvol[l] != ' ' && simvol[l] != ',' && simvol[l] != '.' && simvol[l] != '!' && simvol[l] != '?')
                            {
                                slova[k] += simvol[l];
                            }
                            else
                            {
                                slova[k + 1] += simvol[l];
                                k += 2;
                            }
                        }

                        // Поиск совпадающих слов и запись:
                        for (int i = 0; i < slova.Length; i++)
                        {
                            for (int j = 0; j < dictionary.Length; j++)
                            {
                                if (slova[i] != null)
                                    if (slova[i].ToLower() == dictionary[j].ToLower())
                                    {
                                        eq = true;
                                    }
                            }
                            if (eq)
                            {
                                sw.Write("<b><i>" + slova[i] + "</b></i>");
                            }
                            else
                            {
                                sw.Write(slova[i]);
                            }
                            eq = false;
                        }
                        sw.Write("<br>"); 
                        stroka++;
                        sw.WriteLine();
                        if (stroka >= N)  // Проверка условия "Если файл превышает размер N строк, то его необходимо разбить на несколько файлов, каждый не более N строк"
                        {
                            sw.WriteLine("</html>");
                            sw.Close();
                            n++;
                            stroka = 0;
                            sw = new StreamWriter("C:/HTMLFile" + n.ToString() + ".html", true, System.Text.Encoding.Default);
                            sw.WriteLine("<html>");
                        }
                    }
                    sw.WriteLine("</html>");
                    sw.Close();
                }
                MessageBox.Show("Done!");
            }
            else
                MessageBox.Show("Указан пустой путь");
        }
    }
}
