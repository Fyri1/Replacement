using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace txt_read.Tools
{
    public static class ExtetsionsTools
    {
        public static bool ContainsOnlyLetters(this string addElem)
        {
            bool containsOnlyLetters = true;

            for (int i = 0; i < addElem.Length; i++)
            {
                if (!char.IsLetter(addElem[i]))
                {
                    containsOnlyLetters = false;
                    break;
                }
            }

            if (containsOnlyLetters)
            {
                Console.WriteLine("Все символы являются буквами.");
                return containsOnlyLetters;
            }
            else
            {
                Console.WriteLine("Не все символы являются буквами.");
                return containsOnlyLetters;
            }
        }


        public static string GetNumbers(this string readfile)
        {
            string allwords = ""; // тут все символы
            string allnum = "";// тут все цифры 
            for (int i = 0; i < readfile.Length; i++)
            {
                char c = readfile[i];
                if (Char.IsDigit(c))
                {
                    allnum += c;
                }
                else
                {
                    allwords += c;
                }
            }
            return allnum;
        }
        public static string GetLetters(this string readfile)
        {
            string allwords = ""; // тут все символы
            string allnum = "";// тут все цифры 
            for (int i = 0; i < readfile.Length; i++)
            {
                char c = readfile[i];
                if (Char.IsDigit(c))
                {
                    allnum += c;
                }
                else
                {
                    allwords += c;
                }
            }
            return allwords;
        }



        public static int CountInString(this string text, char target)
        {
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == target)
                {
                    count++;
                }
            }

            return count;
        }
        public static bool ContainsOnlyNumbers(this string addElem)
        {
            bool containsOnlyNumbers = Regex.IsMatch(addElem, @"^[0-9\W]+$");


            if (containsOnlyNumbers)
            {
                Console.WriteLine("True:Тут только символы и числа ");
                return containsOnlyNumbers;
            }
            else
            {
                Console.WriteLine("False: Тут есть буквы.");
                return containsOnlyNumbers;
            }
        }

        public static bool CheckNumbersAtEnd(string input) // проверяет есть ли в конце слова числа Hello12 или 12Hello
        {
            // Удаляем все пробелы справа от строки
            input = input.TrimEnd();
            // Удаляем все пробелы слева от строки
            string input2 = input.TrimStart();

            // Проверяем, что строка не пустая
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++) // проверка чисел в конце 
            {
                if (Char.IsDigit(input[i]) && i == input.Length - 1)
                {
                    return true;
                }
            }
            for (int i = input.Length - 1; i != -1; i--)// проверка чисел вначале 
            {
                if (Char.IsDigit(input[i]) && i == 0)
                {
                    return true;
                }
            }

            // Если все символы справа были числами, значит числа в конце есть
            return false;
        }


        /*        public static IEnumerable СhangeTowElemMethod(string readfile, string firstElem, string firstElemСhange, string secondElem, string secondElemСhange)
                {
                    List<string> result = new List<string>();

                    for (int i = 0; i < readfile.Length; i++)
                    {
                        if (readfile[i] == 'i')
                        {
                            string variant1 = readfile.Substring(0, i) + '1' + readfile.Substring(i + 1);
                            result.Add(variant1);
                            for (int j = i + 1; j < readfile.Length; j++)
                            {
                                if (readfile[j] == 'e')
                                {
                                    string variant2 = variant1.Substring(0, j) + '3' + variant1.Substring(j + 1);
                                    result.Add(variant2);
                                }
                            }
                        }
                        else if (readfile[i] == 'e')
                        {
                            string variant3 = readfile.Substring(0, i) + '3' + readfile.Substring(i + 1);
                            result.Add(variant3);
                            for (int j = i + 1; j < readfile.Length; j++)
                            {
                                if (readfile[j] == 'i')
                                {
                                    string variant4 = variant3.Substring(0, j) + '1' + variant3.Substring(j + 1);
                                    result.Add(variant4);
                                }
                            }
                        }

                    }
                    return result;

                }*/
    }
}