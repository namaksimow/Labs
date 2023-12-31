using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace laboratornayaRabota6
{
    internal class Program
    {
        /// <summary>
        /// вывод главного меню
        /// </summary>
        static void PrintGeneralMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите пункт меню");
            Console.WriteLine(@"1 Сформировать строку самостоятельно
2 Выбрать строку из готового массива
0 Закончить");//Пункты меню
            Console.WriteLine();
        }
        /// <summary>
        /// выполнение задания для строки
        /// </summary>
        /// <param name="stringFunction"></param>
        /// <returns></returns>
        static void CompleteTask(string stringFunction)
        {
            int indexLetter = 0, beginSentence = 0, lenghtSentence = 0, countSentence = 0, numberSentence = 0;
            string finalSentence = "";

            stringFunction = ReplaceEmpty(stringFunction);
            stringFunction = stringFunction.Replace("%", "");
            
            foreach (char letter in stringFunction)
            {
                if (letter == '.' || letter == '!' || letter == '?')
                {
                    countSentence++;
                }
            }//считаем сколько предложений, чтобы выделить память под массив

            string[] sentenceArray = new string[countSentence];

            foreach (char letter in stringFunction)
            {

                indexLetter++;

                if (letter == '.' || letter == '!' || letter == '?')
                {
                    sentenceArray[numberSentence] = stringFunction.Substring(beginSentence, indexLetter - lenghtSentence);

                    beginSentence = indexLetter;
                    lenghtSentence = indexLetter;
                    numberSentence++;
                }

            }//находим все предложения

            for (int i = 0; i < sentenceArray.Length; i++)
            {
                string localOperations = sentenceArray[i];

                if (localOperations.EndsWith('!'))
                {
                    int indexMark = localOperations.IndexOf('!');
                    localOperations = localOperations.Substring(0, indexMark);
                    localOperations = localOperations.Replace(",", " ,").Replace(":", " :").Replace(";", " ;");
                    string reverseString = "";
                    string[] words = localOperations.Split(" ");

                    for (int j = words.Length - 1; j >= 0; j--)
                    {
                        reverseString += $"{words[j]} ";
                    }//если предложение содержит !, то в строку записываем предложение в обратном порядке

                    reverseString += "!";//добавляем в конце предложения удалённый !

                    sentenceArray[i] = reverseString;//заменяем в массиве i предложение на изменённое
                }//если предложение содержит !, то будем его обрабатывать

            }//перезаписываем массив предложений с изменёнными предложениями с !

            for (int i = 0; i < sentenceArray.Length; i++)
            {
                finalSentence += sentenceArray[i] + " ";
            }

            finalSentence = finalSentence.Replace(" !", "!").Replace("  ", " ");
            Console.WriteLine();
            Console.WriteLine("Вы выполнили задание");
            Console.WriteLine(finalSentence); ;
        }
        /// <summary>
        /// создание строки самостоятельно
        /// </summary>
        /// <returns></returns>
        static string MakeString()
        {
            string userInput;
            bool isSentence;

            Console.WriteLine("Введите вашу строку");

            do
            {
                userInput = Console.ReadLine();

                isSentence = IsAllCondition(userInput);

                if (!isSentence)
                {
                    Console.WriteLine("Введённое предложение является некорректным, попробуйте снова");
                }


            } while (!isSentence);

            return userInput;
        }
        /// <summary>
        /// замена пустот
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        static string ReplaceEmpty(string checkString)
        {
            string functionString = checkString;

            while (functionString.Contains("  "))
            { 
                functionString = functionString.Replace("  ", " ");
            }
            return functionString;
        }
        /// <summary>
        /// Выбор пункта главного меню
        /// </summary>
        /// <param name="menuPoint"></param>
        /// <returns></returns>
        static int PickGeneralMenu(ref int menuPoint)
        {
            bool isRange;

            Console.WriteLine("Введите пункт меню");

            do
            {
                menuPoint = InputIntegerNumber();
                isRange = (menuPoint >= 0 && menuPoint <= 2);

                if (!isRange)
                {
                    Console.WriteLine("Вы выбрали не пункт меню");
                }

            } while (!isRange);

            return menuPoint;
        }
        /// <summary>
        /// Ввод целого числа
        /// </summary>
        /// <returns></returns>
        static int InputIntegerNumber()
        {
            string userInput;
            int number;
            bool isNumber;

            do
            {
                userInput = Console.ReadLine();
                isNumber = int.TryParse(userInput, out number);

                if (!isNumber)
                {
                    Console.WriteLine("Это не число, попробуйте снова");
                }

            } while (!isNumber);

            return number;
        }
        /// <summary>
        /// Проверка всех условий
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        static bool IsAllCondition(string checkString)    
        {
            bool regexOk = IsRegex(checkString), notEmpty = IsEmpty(checkString), isPuncMark = IsPuncMarkRepeat(checkString);

            if (regexOk && notEmpty && isPuncMark)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Проверка основных условий существования предложения
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        static bool IsRegex(string checkString)
        {
            string test = checkString.Replace(".", ".%").Replace("!", "!%").Replace("?", "?%");
            bool overall = true;
            string[] array = test.Split("%");

            Regex rgx = new Regex(@"^[А-Я][^.!?]*[.!?]$");

            if (array.Length > 1)
            {
                Array.Resize(ref array, array.Length - 1);
            }

            foreach (string s in array)
            {
                string a = s.Trim();
                if (!rgx.IsMatch(a))
                {
                    overall = false;
                }
            }

            if (overall)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// проверка, есть ли только пробелы или знаки табуляции
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        static bool IsEmpty(string checkString)
        {
            bool empty = true;
            int countEmpty = 0;
            string test = checkString.Replace(" ", "%");
            foreach (char ch in test)
            {
                if (ch == '%')
                    countEmpty++;
            }
            if (checkString.Length == 0 || checkString == null || checkString.Contains("\t") || (countEmpty == checkString.Length))
            {
                empty = false;
            }
            return empty;
        }
        /// <summary>
        /// проверка на повтор знаков пунктуации два и более раз подряд
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        static bool IsPuncMarkRepeat(string checkString)
        {
            bool isPuncMark = true;

            for (int i = 0; i < checkString.Length - 1; i++)
            {
                char firstSymbol = checkString[i];
                char secondSymbol = checkString[i + 1];
                if (Char.IsPunctuation(firstSymbol) && Char.IsPunctuation(secondSymbol) && (firstSymbol == secondSymbol))
                {
                    isPuncMark = false;
                }
            }

            return isPuncMark;
        }


        static void Main(string[] args)
        {
            int startProject = 1;

            do
            { 
                PrintGeneralMenu();
                PickGeneralMenu(ref startProject);

                switch (startProject)
                {
                    case 1:

                        string inputUser = MakeString();
                        CompleteTask(inputUser);

                        break;//Сфомировать строку самостоятельно и выполнить задание

                    case 2:

                        Console.WriteLine("Список предложений для тестирования");
                        Console.WriteLine();

                        string[] sentencesArray = File.ReadAllLines("C:\\not system\\HSE\\программироование\\1 курс\\лабораторная работа 6\\test.txt");
                        bool isRange;
                        int getSentence;

                        for (int i = 0; i < sentencesArray.Length; i++)
                        {
                            Console.WriteLine($"{i+1} - {sentencesArray[i]}");
                        }

                        Console.WriteLine("Выберите номер предложения среди следующих предложенных:");
                        Console.WriteLine();

                        do
                        {
                            getSentence = InputIntegerNumber();
                            isRange = (getSentence >= 1 && getSentence <= sentencesArray.Length);
                            if (!isRange)
                            {
                                Console.WriteLine("Вы выбрали числе не из списка, попробуйте ещё раз");
                            }
                        } while (!isRange);

                        if (IsAllCondition(sentencesArray[getSentence-1]))
                        {
                            CompleteTask(sentencesArray[getSentence - 1]);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"Строка '{sentencesArray[getSentence - 1]}' не удовлетворяет условиям");
                        }

                        break;//Выбрать строку из готового массива и выполнить задание
                }

            } while (startProject != 0);
        }
    }
}
