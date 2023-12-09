using System;
using System.Threading.Channels;

namespace laboratornayaRabota5
{
    internal class Program
    {
        static void PrintGenerealMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Выберите пункт меню");
            Console.WriteLine("1 Работа с одномерными массивом");
            Console.WriteLine("2 Работа с двумерными массивом");
            Console.WriteLine("3 Работа с рваным массивов");
            Console.WriteLine("0 закончить работу");
        }//Вывод главного меню
        static void PrintOperationsMenu(int whichMenu)
        {
            Console.WriteLine("");
            Console.WriteLine("Выберите пункт меню");
            Console.WriteLine("1 создать массив");
            Console.WriteLine("2 распечатать массив");
            if (whichMenu == 1)
            {
                Console.WriteLine("3 добавить по К элементов в начало и конец массива");
            }
            if (whichMenu == 2)
            {
                Console.WriteLine("3 Удалить все столбцы, в которых есть хотя бы один нулевой элемент");
            }
            if (whichMenu == 3)
            {
                Console.WriteLine("3 Добавить строку с заданным номером");
            }

            Console.WriteLine("0 назад");
        }//печать пунктов для выбранного массива
        static void PrintArray(int[] array)
        {
            Console.WriteLine("");
            int[] localArr = array;

            if (localArr.Length == 0)
            {
                Console.WriteLine("массив не сформирован, нельзя его распечатать");
            }
            else
            {
                for (int i = 0; i < localArr.Length; i++)
                {
                    Console.Write(localArr[i] + " ");
                }

                Console.WriteLine();
                Console.WriteLine("Вы распечатали одномерный массив");
            }
        }//печать одномерного массива
        static void PrintArray(int[,] array)
        {
            Console.WriteLine("");
            if (array.Length == 0)
            {
                Console.WriteLine("Массив не сформирован, нельзя его распечатать");
            }
            else
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i, j],4}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Вы распечатали двумерный массив");
            }
        }//печать двумерного массива
        static void PrintArray(int[][] array)
        {
            Console.WriteLine("");
            if (array.Length == 0)
            {
                Console.WriteLine("Массив не сформирован, нельзя его распечатать");
            }
            else
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array[i].GetLength(0); j++)
                    {
                        Console.Write($"{array[i][j],4}");
                    }

                    Console.WriteLine("");
                }

                Console.WriteLine("Вы распечатали рваный массив");
            }
        }//печать рваного массива
        static void PrintMakeArrayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1 cформировать массив с помощью ДСЧ");
            Console.WriteLine("2 сформировать массив самостоятельно");
            Console.WriteLine("0 назад");
        }//печать меню для выбора создание массива
        static bool isEmpty(int[] array)
        {
            if (array.Length == 0 || array == null)
            {
                Console.WriteLine("Массив не сформирован, нельзя вывести его элементы");
                return true;
            }
            else
            {
                return false;
            }
        }//проверка длины одномерного массива
        static bool isEmpty(int[,] array)
        {
            if (array.Length == 0 || array == null)
            {
                Console.WriteLine("Массив не сформирован, нельзя вывести его элементы");
                return true;
            }
            else
            {
                return false;
            }
        }//проверка длины двумерного массива
        static bool isEmpty(int[][] array)
        {
            if (array.GetLength(0) == 0 || array == null)
            {
                Console.WriteLine("Массив не сформирован, нельзя вывести его элементы");
                return true;
            }
            else
            {
                return false;
            }
        }//проверка длины рваного массива
        static int GetNumber()
        {
            Console.WriteLine("");
            string userInput;
            int number;
            bool isCorrect;

            Console.WriteLine("Введите число");

            do
            {
                userInput = Console.ReadLine();
                isCorrect = int.TryParse(userInput, out number);

                if (!isCorrect)
                {
                    Console.WriteLine("Это не целое число, попробуйте снова");
                }

            } while (!isCorrect);

            return number;
        }//проверка на число
        static int GetDecimalNumber()
        {
            Console.WriteLine("");
            string userInput;
            int number;
            bool isCorrect, isRange;

            do
            {
                userInput = Console.ReadLine();
                isCorrect = int.TryParse(userInput, out number);
                isRange = (number > 0);

                if (!(isCorrect && isRange))
                {
                    Console.WriteLine("Этим число нельзя использовать, попробуйте снова");
                }

            } while (!(isCorrect && isRange));//проверка на правильность ввода длины массива

            return number;
        }//проверка, что число является натуральным
        static int GetNumberRow(int[][] array)
        {
            Console.WriteLine("");
            int number;
            bool isCorrect;
            Console.WriteLine("Введите номер строки, которую хотите добавить");
            do
            {
                number = GetDecimalNumber();
                isCorrect = (number <= array.GetLength(0)+1);
                if (!isCorrect)
                {
                    Console.WriteLine("Строку с таким номером нельзя добавить, попробуйте снова");
                }
            } while (!isCorrect);

            return number;
        }//выбор номера вставляемой строки
        static int PickPointMenu()
        {
            Console.WriteLine("");
            string userInput;
            int number;
            bool isCorrect, isRange;

            do
            {
                userInput = Console.ReadLine();
                isCorrect = int.TryParse(userInput, out number);
                isRange = (number >= 0 && number <= 3);

                if (!(isCorrect && isRange))
                {
                    Console.WriteLine("Вы выбрали не пункт меню, попробуйте снова");
                }

            } while (!(isCorrect && isRange));//проверка на правильность ввода задания

            return number;
        }//Выбираем пункты 
        static int PickPointMakeArray()
        {
            Console.WriteLine("");
            string userInput;
            int number;
            bool isCorrect, isRange;

            do
            {
                userInput = Console.ReadLine();
                isCorrect = int.TryParse(userInput, out number);
                isRange = (number >= 0 && number <= 2);

                if (!(isCorrect && isRange))
                {
                    Console.WriteLine("Вы выбрали не пункт меню, попробуйте снова");
                }

            } while (!(isCorrect && isRange));//проверка на правильность ввода задания

            return number;
        }//выбрать пункты для создания массива
        static int[] MakeOneDimensionArrayRandom(ref int[] array)
        {
            Console.WriteLine("");
            Console.WriteLine("Введите желаемую длину массива");

            int arrayLenght = GetDecimalNumber();

            int[]functioanlArray = new int[arrayLenght];

            Random random = new Random();

            for (int i = 0; i < functioanlArray.Length; i++)
            {
                functioanlArray[i] = random.Next(-100, 100);
            }

            Console.WriteLine("Вы сформировали одномерный массив через ДСЧ");

            array = functioanlArray;
            return array;

        }//создание одномерного массива через ДСЧ
        static int[] MakeOneDimensionArraySolo(ref int[] array)
        {
            Console.WriteLine("");
            Console.WriteLine("Введите желаемую длину массива");

            int arrayLenght = GetDecimalNumber();

            int[] functionalArray = new int[arrayLenght];

            for (int i = 0; i < arrayLenght; i++)
            {
                Console.WriteLine("Введите элемент массива");

                int elementArray = GetDecimalNumber();

                functionalArray[i] = elementArray;

                Console.WriteLine($"Вы добавили число {elementArray} в массив, номер числа в массиве {i + 1}");

            }

            Console.WriteLine("Вы добавили элементы в массив");
            Console.WriteLine("Вы сформировали одномерный массив");

            array = functionalArray;
            return array;

        }//создание одномерного массива самостоятельно
        static int[,] MakeTwoDimensionalArrayRandom(ref int[,] array)
        {
            int row, column;

            Console.WriteLine("Введите желаемое количество строк в массиве");

            row = GetDecimalNumber();

            Console.WriteLine("Введите желаемое количество столбцов в массиве");

            column = GetDecimalNumber();
            
            Console.WriteLine("Вы задали размеры для своего массива");

            int[,] functionArray = new int[row, column];
            Random random = new Random();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    functionArray[i, j] = random.Next(-10, 10);
                }
            }

            Console.WriteLine("Вы создали массив через ДСЧ");

            array = functionArray;
            return array;
        }//Создание двумерного массива через ДСЧ
        static int[,] MakeTwoDimensionalArraySolo(ref int[,] array)
        {
            
            int row, column, number;
            

            Console.WriteLine("Введите желаемое количество строк в массиве");

            row = GetDecimalNumber();

            Console.WriteLine("Введите желаемое количество столбцов в массиве");

            column= GetDecimalNumber();

            Console.WriteLine("Вы задали размеры для своего массива");

            int[,] functionArray = new int[row, column];


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.WriteLine($"Введите элемент, который будет стоять в {i + 1} строке и {j + 1} столбце");

                    number = GetNumber();

                    functionArray[i, j] = number;

                }
            }

            Console.WriteLine("Вы самостоятельно создали массив");

            array = functionArray;
            return functionArray;
        }//создание двумерного массива самостоятельно
        static int[][] MakeJaggedArrayRandom(ref int[][] array)
        {
            int row, column;
            int[][] localArray;

            Console.WriteLine("Введите количество строк в рваном массива");

            row = GetDecimalNumber();
            localArray = new int[row][];
            Random random = new Random();

            for (int i = 0; i < row; i++)
            {
                Console.WriteLine($"Введите количество элементов в строке {i+1}");
                column = GetDecimalNumber();
                localArray[i] = new int[column];

                for (int j = 0; j < column; j++)
                {
                    localArray[i][j] = random.Next(-10,10);
                }
            }

            Console.WriteLine("Вы создали рваный массив");

            array = localArray;
            return localArray;

        }//создание рваного массива через ДСЧ
        static int[][] MakeJaggedArraySolo(ref int[][] array)
        {
            int row, column, number;
            int[][] localArray;

            Console.WriteLine("Введите количество строк в рваном массива");

            row = GetDecimalNumber();
            localArray = new int[row][];
            Random random = new Random();

            for (int i = 0; i < row; i++)
            {
                Console.WriteLine($"Введите количество элементов в строке {i + 1}");
                column = GetDecimalNumber();
                localArray[i] = new int[column];

                for (int j = 0; j < column; j++)
                {
                    Console.WriteLine($"Введите {j+1} элемент строки {i+1}");
                    number = GetNumber();
                    localArray[i][j] = number;
                }
            }

            Console.WriteLine("Вы создали рваный массив");

            array = localArray;
            return localArray;
        }//создание рваного массива самостоятельно
        static int[] AddKElementsOneDimensionRandom(ref int[] array)
        {
            Console.WriteLine("Введите число К, сколько хотите добавить");
            int quantity = GetDecimalNumber();
            Random random = new Random();

            int[] functionalArray = new int[array.Length + quantity * 2];

            for (int i = 0; i < array.Length; i++)
            {
                functionalArray[quantity+i] = array[i];
            }//возвращаем старые значение

            for (int i = 0; i < quantity; i++)
            {
                functionalArray[i] = random.Next(-10, 10);
                functionalArray[array.Length + quantity + i] = random.Next(-10, 10);
            }

            array = functionalArray;
            return array;
        }//добавление К элементов через ДСЧ
        static int[] AddKElementsOneDimensionSolo(ref int[] array)
        {
            Console.WriteLine("Введите число К, сколько хотите добавить");
            int quantity = GetDecimalNumber();
            int[] functionalArray = new int[array.Length + quantity * 2];

            for (int i = 0; i < array.Length; i++)
            {
                functionalArray[quantity + i] = array[i];
            }//возвращаем старые значение

            for (int i = 0; i < quantity; i++)
            {
                int numberBegin = GetNumber();
                functionalArray[i] = numberBegin;

                Console.WriteLine($"Вы добавили число {numberBegin} в массив под номером {i+1}");

                int numberEnd = GetNumber(); 
                functionalArray[array.Length + quantity + i] = numberEnd;
                Console.WriteLine($"Вы добавили число {numberEnd} в массив под номером {array.Length+quantity+i+1}");
            }

            array = functionalArray;
            return array;
        }//добавление К элементов самостоятельно
        static int[,] DeleteZeroColumns(int[,] array)
        {
            int row = array.GetLength(0);
            int column = array.GetLength(1);
            int countZeroColumn = 0;
            int newrow = 0;
            int newcolumn = 0;

            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    if (array[i, j] == 0)
                    {
                        countZeroColumn++;
                        break;
                    }
                }
            }//находим количество нулевых столбцов
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0)
                    {
                        for (int z = 0; z < array.GetLength(0); z++)
                        {
                            array[z, j] = 0;
                        }
                    }
                }
            }//заменяем все элементы в столбце с нулём на нули

            int[,] local = new int[row, column - countZeroColumn];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != 0)
                    {
                        local[newrow, newcolumn] = array[i, j];
                        newcolumn++;
                    }

                }
                newcolumn = 0;
                newrow++;
            }//заполняем новым массив без нулевых столбцов

            Console.WriteLine("Вы выполнили удаление столбцов");

            return local;
        }//удалить столбцы в двумерном массиве, где есть хотя бы один 0
        static int[][] AddRow(int[][] array)
        {
            return array;
        }//добавление в рваный массив строки с заданным номером
        static void Main(string[] args)
        {

            int enterWhile, enterSubMenu;
            int[] globalOneDimension = new int[0];
            int[,] globalTwoDimension = new int[0, 0];
            int[][] globalJaggedArray = new int[0][];

            do
            {
                PrintGenerealMenu();

                enterWhile = PickPointMenu();

                switch (enterWhile) 
                {
                    case 1:

                        do
                        {
                            PrintOperationsMenu(enterWhile);

                            enterSubMenu = PickPointMenu();

                            switch (enterSubMenu)
                            {
                                case 1:

                                    PrintMakeArrayMenu();

                                    enterSubMenu = PickPointMakeArray();

                                    int[] localOneDimension = new int[0];

                                    switch (enterSubMenu)
                                    {
                                        case 1:

                                            MakeOneDimensionArrayRandom(ref localOneDimension);
                                            globalOneDimension = localOneDimension;

                                            break;//создание массива с помощью ДСЧ

                                        case 2:

                                            MakeOneDimensionArraySolo(ref localOneDimension);
                                            globalOneDimension = localOneDimension;

                                            break;//создание массива самостоятельно

                                    }//пункты выбора создания массива

                                    break;//создание массива

                                case 2:

                                    PrintArray(globalOneDimension);

                                    break;//печать массива

                                case 3:

                                    if (!isEmpty(globalOneDimension))
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Выберите пункт меню");
                                        Console.WriteLine("1 добавить К элементов с помощью ДСЧ");
                                        Console.WriteLine("2 добавить К элементов самостоятельно");
                                        Console.WriteLine("0 назад");

                                        enterSubMenu = PickPointMakeArray();

                                        switch (enterSubMenu)
                                        {
                                            case 1:

                                                AddKElementsOneDimensionRandom(ref globalOneDimension);

                                                break;

                                            case 2:

                                                Console.WriteLine("Вы будете сначала вводить элемент первый, который будет стоять в начала, а потом в конце ");
                                                AddKElementsOneDimensionSolo(ref globalOneDimension);

                                                break;
                                        }
                                    }

                                    break;//добавление по К элементов в начало и в конец массива 
                            }

                        } while (enterSubMenu != 0);

                        break;//работа с одномерным массивом

                    case 2:

                        do
                        {
                            PrintOperationsMenu(enterWhile);

                            enterSubMenu = PickPointMenu();

                            int[,] localTwoDimension = new int[0, 0];

                            switch (enterSubMenu)
                            {
                                case 1:

                                    PrintMakeArrayMenu();

                                    enterSubMenu = PickPointMenu();

                                    switch (enterSubMenu)
                                    {
                                        case 1:

                                            MakeTwoDimensionalArrayRandom(ref localTwoDimension);
                                            globalTwoDimension = localTwoDimension;

                                            break;//создание двумерного массива с помощью дсч

                                        case 2:

                                            MakeTwoDimensionalArraySolo(ref localTwoDimension);
                                            globalTwoDimension = localTwoDimension;

                                            break;//создание двумерного массива самостоятельно
                                    }

                                    break;//создание двумерного массива

                                case 2:

                                    PrintArray(globalTwoDimension);

                                    break;//печать двумерного массива

                                case 3:

                                    if (!isEmpty(globalTwoDimension))
                                    {
                                        localTwoDimension = DeleteZeroColumns(globalTwoDimension);
                                        globalTwoDimension = localTwoDimension;   
                                    }

                                    break;//Удалить все столбцы, в которых есть хотя бы один нулевой элемент
                            }
                        } while (enterSubMenu != 0);

                        break;//работа с двумерным массивом

                    case 3:

                        do
                        {
                            PrintOperationsMenu(enterWhile);

                            enterSubMenu = PickPointMenu();

                            int[][] localJaggedArray = new int[0][];

                            switch (enterSubMenu)
                            {
                                case 1:

                                    PrintMakeArrayMenu();
                                    enterSubMenu = PickPointMakeArray();

                                    switch (enterSubMenu)
                                    {
                                        case 1:

                                            MakeJaggedArrayRandom(ref localJaggedArray);
                                            globalJaggedArray = localJaggedArray;

                                            break;//создание рваного массива через ДСЧ

                                        case 2:

                                            MakeJaggedArraySolo(ref localJaggedArray);
                                            globalJaggedArray = localJaggedArray;

                                            break;//создание рваного массива самостоятельно
                                    }

                                    break;//создание рваного массива

                                case 2:

                                    PrintArray(globalJaggedArray);

                                    break;//печать рваного массива

                                case 3:

                                    if (!isEmpty(globalJaggedArray))
                                    {
                                        int numberRow = GetNumberRow(globalJaggedArray);
                                        Console.WriteLine("Введите количество элементов в строке");
                                        int amountNumber = GetDecimalNumber();

                                        localJaggedArray = new int[globalJaggedArray.GetLength(0) + 1][];

                                        for (int i = 0; i < globalJaggedArray.GetLength(0); i++)
                                        {
                                            localJaggedArray[i] = new int[globalJaggedArray[i].GetLength(0)];
                                        }

                                        localJaggedArray[localJaggedArray.GetLength(0) - 1] = new int[amountNumber];

                                        for (int i = 0; i < globalJaggedArray.GetLength(0); i++)
                                        {
                                            for (int j = 0; j < globalJaggedArray[i].GetLength(0); j++)
                                            {
                                                localJaggedArray[i][j] = globalJaggedArray[i][j];
                                            }
                                        }

                                        for (int i = localJaggedArray.GetLength(0)-1; i > numberRow-1; i--)
                                        {
                                            int[] temp = localJaggedArray[i];
                                            localJaggedArray[i] = localJaggedArray[i - 1];
                                            localJaggedArray[i - 1] = temp;
                                        }

                                        globalJaggedArray = localJaggedArray;
                                        
                                    }

                                    break;//добавить строку с заданным номером
                            }

                        } while (enterSubMenu != 0);

                        break;//работа с рваным массивом, НЕДОДЕЛАН 3 пункт
                }

            } while (enterWhile != 0);
        }
    }
}
    
