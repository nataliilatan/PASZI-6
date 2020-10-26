using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp8
{
    class Program
    {
        static string Encrypting (char[] message, char[] key)
        {
            int numb; // Номер в алфавите
            int d; // Смещение
            string s; //Результат
            int j, f; // Переменная для циклов
            int t = 0; // Преременная для нумерации символов ключа.
            char[] alphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            for (int i = 0; i < message.Length; i++)
            {

                for (j = 0; j < alphabet.Length; j++)
                {
                    if (message[i] == alphabet[j])
                    {
                        break;
                    }
                }

                if (j != 33)
                {
                    numb = j;
                    if (t > key.Length - 1) { t = 0; }

                    for (f = 0; f < alphabet.Length; f++)
                    {
                        if (key[t] == alphabet[f])
                        {
                            break;
                        }
                    }

                    t++;

                    if (f != 33)
                    {
                        d = numb + f;
                    }
                    else
                    {
                        d = numb;
                    }

                    if (d > 32)
                    {
                        d = d - 33;
                    }

                    message[i] = alphabet[d];
                }
            }
            s = new string(message);
            return s;
        }
        static string Decrypting(char[]message, char[] key)
        {
            int numb; // Номер в алфавите
            int d; // Смещение
            string s; //Результат
            int j, f; // Переменная для циклов
            int t = 0; // Преременная для нумерации символов ключа.
            char[] alphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            for (int i = 0; i < message.Length; i++)
            {

                for (j = 0; j < alphabet.Length; j++)
                {
                    if (message[i] == alphabet[j])
                    {
                        break;
                    }
                }

                if (j != 33)
                {
                    numb = j;
                    if (t > key.Length - 1) { t = 0; }


                    for (f = 0; f < alphabet.Length; f++)
                    {
                        if (key[t] == alphabet[f])
                        {
                            break;
                        }
                    }

                    t++;

                    if (f != 33)
                    {
                        if ((numb + f) > 32)
                        {
                            if (numb>f)
                            {
                                d = numb - f;
                            }
                            else
                            {
                                d = 33 - (f - numb);
                            }
                            

                        }
                        else
                        {
                            d = 33 - f + numb;
                        }
                    }
                    else
                    {
                        d = numb;
                    }

                    if (d > 32)
                    {
                        d = d - 33;
                    }

                    message[i] = alphabet[d];
                }

            }
            s = new string(message);
            return s;
        }
        static void Main(string[] args)

        {

            string s; //Результат
            char[] message;
            char[] key;
            string m;
            string k;
            string file;
 Operation: 
            Console.WriteLine("1 - зашифровать; 2 - расшифровать, 3- выйти");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("1 - данные с файла, 2 - ввести данные вручную");
                    switch(Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Введите название файла");
                            file = Console.ReadLine();
                            m = File.ReadAllText(file, Encoding.UTF8);
                            message = m.ToCharArray();
                            Console.WriteLine("Введите ключевое слово");
                            k = Console.ReadLine();
                            key = k.ToCharArray();
                            s = Encrypting(message, key);
                            Console.WriteLine("Результат шифрования");
                            Console.WriteLine(s);
                            File.WriteAllText("3.txt", s); // Записываем результат в файл.
                            break;
                        case "2":
                            Console.WriteLine("Введите строку для шифрования");
                            m = Console.ReadLine();
                            message = m.ToCharArray();
                            Console.WriteLine("Введите ключевое слово");
                            k = Console.ReadLine();
                            key = k.ToCharArray();
                            s = Encrypting(message, key);
                            Console.WriteLine("Результат шифрования");
                            Console.WriteLine(s);
                            File.WriteAllText("3.txt", s); // Записываем результат в файл.
                            break;
                    }
                    goto Operation;
                case "2":
                    Console.WriteLine("1 - данные с файла, 2 - ввести данные вручную");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Введите название файла");
                            file = Console.ReadLine();
                            m = File.ReadAllText(file, Encoding.UTF8);
                            message = m.ToCharArray();
                            Console.WriteLine("Введите ключевое слово");
                            k = Console.ReadLine();
                            key = k.ToCharArray();
                            s = Decrypting(message, key);
                            Console.WriteLine("Результат расшифровки");
                            Console.WriteLine(s);
                            File.WriteAllText("3.txt", s); // Записываем результат в файл.
                            break;
                        case "2":
                            Console.WriteLine("Введите строку для расшифровки");
                            m = Console.ReadLine();
                            message = m.ToCharArray();
                            Console.WriteLine("Введите ключевое слово");
                            k = Console.ReadLine();
                            key = k.ToCharArray();
                            s = Decrypting(message, key);
                            Console.WriteLine("Результат расшифровки");
                            Console.WriteLine(s);
                            File.WriteAllText("3.txt", s); // Записываем результат в файл.
                            break;
                    }
                    goto Operation;
                case "3":
                    break;
            }
            Console.WriteLine("До встечи!");
        }

    }
}
