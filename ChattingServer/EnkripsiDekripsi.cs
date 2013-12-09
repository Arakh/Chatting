using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChattingServer
{
    class EnkripsiDekripsi
    {
        public string Enkripsi(string text)
        {
            string[] temp = Regex.Split(text, string.Empty);
            //determine sum of row
            int rows = ((temp.Count()) / 3) + ((temp.Count()) % 3);
            int index = 1;
            string[,] encrypt = new string[rows, 3];
            string result = "";

            //convert array to matriks encrypted
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (index >= temp.Count() || temp[index].Equals(""))
                        encrypt[i, j] = " ";
                    else if (!temp[index].Equals(""))
                        encrypt[i, j] = temp[index];
                    index++;
                }
            }
            //result of encrypted
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result += encrypt[j, i];
                }
            }
            return result;
        }

        public string Dekripsi(string text)
        {
            string[] temp = Regex.Split(text, string.Empty);
            //determine sum of row
            int rows = ((temp.Count()) / 3) + ((temp.Count()) % 3)-2;
            int index = 1;
            string[,] decrypted = new string[3, rows];
            string result = "";

            //convert array to matriks
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (index >= temp.Count() || temp[index].Equals(""))
                        decrypted[i, j] = " ";
                    else if (!temp[index].Equals(""))
                        decrypted[i, j] = temp[index];
                    index++;
                }
            }
            //result of decrypted
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result += decrypted[j, i];
                }
            }
            return result;
        }

    }
}
