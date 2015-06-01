using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testovoe
{
    class OpenFile
    {
        private string fpath="";
        /// <summary>
        /// Путь к последнему открытому файлу
        /// </summary>
        public string Fpath {
            get { return fpath; }
        }
        /// <summary>
        /// Предоставляет файл, открываемый пользователем, для дальнейшей работы
        /// </summary>
        public OpenFileDialog getFile()
        {
              OpenFileDialog openfiledialog = new OpenFileDialog();
              openfiledialog.InitialDirectory = "C://";
              openfiledialog.Filter = "text files (*.txt,*.fb2,*.doc,*.docx,*.rtf,*.odt)|*.txt;*.fb2;*.doc;*.docx;*.rtf;*.odt";
              openfiledialog.FilterIndex = 1;
              openfiledialog.RestoreDirectory = true;
              if (openfiledialog.ShowDialog() == DialogResult.OK)
              {
                  try
                  {
                      this.fpath = openfiledialog.FileName;
                  }
                  catch (Exception ex)
                  {
                      
                      MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                  }
              }
              return openfiledialog;
        }

        /// <summary>
        /// Предоставляет файл словаря, открываемый пользователем
        /// </summary>
        public string[] getDictionary() {
            string[] dictionary;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C://";
            ofd.Filter = "text files (*.txt,*.fb2,*.doc,*.docx,*.rtf,*.odt)|*.txt;*.fb2;*.doc;*.docx;*.rtf;*.odt";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader file = File.OpenText(ofd.FileName);
                    dictionary = file.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    this.fpath = ofd.FileName;
                    // Проверка условия "Файл словаря содержит произвольное количество строк, каждая из которых содержит ровно одно слово":
                    for (int i = 0; i < dictionary.Length; i++)
                    {
                        string[] temp;
                        temp = dictionary[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length != 1)
                        {
                            MessageBox.Show("Неверная структура файла словаря");
                            this.fpath = "";
                            break;
                        }
                    }
                    return dictionary;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
            return null;
        }
    }
}
