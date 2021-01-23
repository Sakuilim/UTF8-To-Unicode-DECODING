using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UNICODE_TO_UTF8_Csharp
{
    public static class FileReader
    {

        public static void Lines(string b, int laik)
        {
            int baitas = 0;
            List<int> result = new List<int>();
            {

                int h = int.Parse(b);
                string unicode = h.ToString("X4");
                unicode = string.Format("U+{0}", unicode);
                char c = (char)h;
                if (laik != 2)
                {
                    Console.WriteLine(unicode);
                    Byte(result, h, baitas);
                    Console.WriteLine(c);
                    Console.ReadLine();
                }

            }
        }
        public static int Byte(List<int> result, int b, int baitas)
        {
            if (b <= 127 && b > 0)
            {
                baitas = 1;
            }
            else if (b > 127 && b <= 2047)
            {
                baitas = 2;
            }
            else if (b > 2047 && b <= 65535)
            {
                baitas = 3;
            }
            else if (b > 65535 && b <= 1114111)
            {
                baitas = 4;
            }
            else
            {
                baitas = -1;
            }
            result = Binary(result, b);
            while (result.Count < 8 * baitas)
            {
                result.Add(0);
            }
            result.Reverse();
            UTF8(result, baitas, b);
            return baitas;
        }
        public static List<int> Binary(List<int> result, int b)
        {
            while (b > 1)
            {
                int likutis = b % 2;
                result.Add(likutis);
                b = b / 2;
            }
            result.Add(b);
            return result;
        }
        public static List<int> UTF8(List<int> result, int baitas, int b)
        {
            List<int> ats;
            if (baitas == 1)
            {
                ats = result;
                ats[0] = 0;
                char[] atc = new char[100];
                string temp;
                string comb = string.Join("", ats.ToArray());
                temp = BinaryStringToHexString(comb);
                if (b < 100)
                {
                    atc[0] = temp[0];
                }
                else
                {
                    atc[0] = temp[0];
                    atc[1] = temp[1];
                }
                string gg = new string(atc);
                for (int i = 0; i < atc.Length; i++)
                {
                    Console.Write(atc[i]);
                }
                Console.Write(gg);
                Console.WriteLine();
            }
            else if (baitas == 2)
            {
                ats = result;
                ats[0] = 1;
                ats[1] = 1;
                ats[2] = 0;
                ats[3] = ats[5];
                ats[4] = ats[6];
                ats[5] = ats[7];
                ats[6] = ats[8];
                ats[7] = ats[9];
                ats[8] = 1;
                ats[9] = 0;
                string temp;
                string comb = string.Join("", ats.ToArray());
                temp = BinaryStringToHexString(comb);
                char[] atc = new char[24];
                atc[0] = temp[0];
                atc[1] = temp[1];
                atc[3] = temp[2];
                atc[4] = temp[3];
                string gg = new string(atc);
                Console.Write(gg);
                Console.WriteLine();

            }
            else if (baitas == 3)
            {
                ats = result;
                ats[0] = 1;
                ats[1] = 1;
                ats[2] = 1;
                ats[3] = 0;
                ats[4] = result[8];
                ats[5] = result[9];
                ats[6] = result[10];
                ats[7] = result[11];
                ats[8] = 1;
                ats[9] = 0;
                ats[10] = result[12];
                ats[11] = result[13];
                ats[12] = result[14];
                ats[13] = result[15];
                ats[14] = result[16];
                ats[15] = result[17];
                ats[16] = 1;
                ats[17] = 0;
                string temp;
                string comb = string.Join("", ats.ToArray());
                temp = BinaryStringToHexString(comb);
                char[] atc = new char[24];
                atc[0] = temp[0];
                atc[1] = temp[1];
                atc[2] = temp[2];
                atc[3] = temp[3];
                atc[4] = temp[4];
                atc[5] = temp[5];
                string gg = new string(atc);
                Console.Write(gg);
                Console.WriteLine();
            }
            else if (baitas == 4)
            {
                ats = result;
                ats[0] = 1;
                ats[1] = 1;
                ats[2] = 1;
                ats[3] = 1;
                ats[4] = 0;
                ats[5] = result[11];
                ats[6] = result[12];
                ats[7] = result[13];
                ats[8] = 1;
                ats[9] = 0;
                ats[10] = result[14];
                ats[11] = result[15];
                ats[12] = result[16];
                ats[13] = result[17];
                ats[14] = result[18];
                ats[15] = result[19];
                ats[16] = 1;
                ats[17] = 0;
                ats[18] = result[20];
                ats[19] = result[21];
                ats[20] = result[22];
                ats[21] = result[23];
                ats[22] = result[24];
                ats[23] = result[25];
                ats[24] = 1;
                ats[25] = 0;
                string temp;
                string comb = string.Join("", ats.ToArray());
                temp = BinaryStringToHexString(comb);
                char[] atc = new char[24];
                atc[0] = temp[0];
                atc[1] = temp[1];
                atc[2] = ' ';
                atc[3] = temp[2];
                atc[4] = temp[3];
                atc[5] = ' ';
                atc[6] = temp[4];
                atc[7] = temp[5];
                atc[8] = ' ';
                atc[9] = temp[6];
                atc[10] = temp[7];
                string gg = new string(atc);
                File.WriteAllText("String.txt", ToHexString(gg));
                Console.Write(gg);
                Console.WriteLine();
            }
            return result;
        }
        public static string BinaryStringToHexString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
            {
                return binary;
            }

            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            // TODO: check all 1's or 0's... throw otherwise

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X}", Convert.ToByte(eightBits, 2));
            }
            return result.ToString();
        }
        public static List<char> AntraP(string file, List<char> txt)
        {
            List<string> uni = new List<string>();
            List<string> dec = new List<string>();
            char x = '\t';
            string[] lines = File.ReadAllLines(@"CP437.txt");
            foreach (string line in lines)
            {
                string[] pair = line.Split(new[] { ' ' });
                uni.Add(pair[0].Trim());
                dec.Add(pair[1].Trim());
            }
            string c;
            StreamReader reader = new StreamReader(file);
            do
            {
                int b = reader.Read();
                c = b.ToString();
                x = Text(x, c, b, uni, dec);
                txt.Add(x);
            } while (!reader.EndOfStream);
            return txt;
        }
        public static char Text(char x, string c, int b, List<string> uni, List<string> dec)
        {
            int laik = 2;
            int tmp = 0;
            foreach (string cod in dec)
            {
                if (c == cod)
                {
                    int decValue = int.Parse(uni[tmp], System.Globalization.NumberStyles.HexNumber);
                    string sk = decValue.ToString();
                    x = (char)decValue;
                    Lines(sk, laik);

                    return x;
                }
                else
                {
                    x = (char)b;
                }
                tmp++;
            }
            return x;
        }
        public static string ToHexString(string hexString)
        {
            var sb = new StringBuilder();
            var bytes = Encoding.Unicode.GetBytes(hexString);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));

            }
            return sb.ToString();

        }
    }
}
