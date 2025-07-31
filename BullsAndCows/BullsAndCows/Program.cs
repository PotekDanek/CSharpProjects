using System;

class Program
{
    // Спрашивает у пользователя количество цифр, в загадываемом числе.
    public static void Digit(out int count)
    {
        Console.Write("Введите количество цифр (1-10), в загадываемом числе: ");

        // Проверяем соответствие формата введенных данных.
        while (!int.TryParse(Console.ReadLine(), out count) || (count < 1) || (count > 10))
        {
            Console.WriteLine("!!! Ошибка ввода, попробуйте еще раз !!!");
            Console.Write("Введите количество цифр (1-10), в загадываемом числе: ");
        }
        Console.WriteLine($"Компьютор загадал {count}-значное число\n");
    }

    // Генерирует число.
    public static void Randomizer(ref bool[] exist, ref int[] secretNum, int count)
    {
        Random rand = new Random();
        for (int i = 0; i < count; i++)
        {
            // Генерируем цифру загадываемого числа, проверяя на отсутствие повторов.
            do
            {
                secretNum[i] = rand.Next((i == 0) ? 1 : 0, 10);
            } while (exist[secretNum[i]]);
            exist[secretNum[i]] = true;
        }
    }

    // Считывает введенное пользователем число.
    public static void ReadGuess(out ulong guess, int count)
    {
        Console.Write("Введите ваше предположение: ");

        //Проверяем соответствие формата введенных данных.
        while (!ulong.TryParse(Console.ReadLine(), out guess) || !(guess >= Math.Pow(10, count - 1)) || !(guess < Math.Pow(10, count)))
        {
            Console.WriteLine("!!! Ошибка ввода, попробуйте еще раз !!!\n(Обратите внимание, число не может начинаться с 0 и должно содержать столько же цифр, сколько и загаданное)");
            Console.Write("Введите ваше предположение: ");
        }
    }

    //Находит количество быков и коров.
    public static void BullsCows(bool[] exist, int[] secretNum, ulong guess, out int cow, out int bull, int count)
    {
        cow = 0;
        bull = 0;
        // Сравниваем числа начиная с последней цифры.
        for (int i = count - 1; i >= 0; i--)
        {
            // num - цифра, введенного пользователем числа.
            ulong num = guess % 10;
            // Проверяем наличие цифры num в загаданном числе.
            if (exist[num])
            {
                // Проверяем находится ли цифра num на своем месте.
                if (secretNum[i] == (int)num)
                    bull++;
                else
                    cow++;
            }
            guess /= 10;
        }
    }

    // Для правильного вывода окончания в слове "корова".
    public static string StrCow(int cow)
    {
        if ((cow < 5) && (cow != 0))
            if (cow == 1)
                // 1 корова.
                return " корова";
            else
                // 2-4 коровы.
                return " коровы";
        else
            // 5-10 коров, 0 коров.
            return " коров";
    }

    // Для правильного вывода окончания в слове "бык".
    public static string StrBull(int bull)
    {
        if ((bull < 5) && (bull != 0))
            if (bull == 1)
                // 1 бык.
                return " бык";
            else
                // 2-4 быка.
                return " быка";
        else
            // 5-10 быков, 0 быков.
            return " быков";
    }

    // Предлагает сыграть еще раз.
    public static bool PlayAgain()
    {
        string again;
        Console.WriteLine("Хотите сыграть еще раз? (да/нет)");
        again = Console.ReadLine();
        // Проверка соответствия формата введенных данных.
        while ((again != "да") && (again != "нет"))
        {
            Console.WriteLine("!!! Ошибка ввода, попробуйте еще раз !!!\n(Введите \"да\" или \"нет\", обратите внимание на регистр)");
            Console.WriteLine("Хотите сыграть еще раз ? (да / нет)");
            again = Console.ReadLine();
        }
        if (again == "да")
            return true;
        else
            return false;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("\t\tБЫКИ И КОРОВЫ\n\n");
        Console.WriteLine("Правила:\nКомпьютер загадывает число, состоящее из неповторяющихся цифр. " +
            "Задача игрока - угадать данное число, вводя свои предположения." +
            "В ответ компьютер показывает число отгаданных цифр, стоящих на своих местах (число быков) " +
            "и число отгаданных цифр, стоящих не на своих местах (число коров).\n");

        // count - количество цифр в числе. (
        int count;
        // guess - догадка пользователя.
        ulong guess;
        // cow - количество коров.
        int cow;
        // bull - количество быков.
        int bull;

        do
        {
            // Спрашиваем количество цифр в загадываемом числе.
            Digit(out count);

            // Используем массивы для хранения иформации о загаданном числе.
            // Массив exist отражает наличие(true)/отсутствие(false) цифры в загаданном числе
            bool[] exist = { false, false, false, false, false, false, false, false, false, false };
            // Массив secretNum - загаданное число "поцифренно".
            int[] secretNum = new int[count];

            // Генерация числа.
            Randomizer(ref exist, ref secretNum, count);

            // Обработка хода игрока
            do
            {
                // Счтываем догадку пользователя.
                ReadGuess(out guess, count);
                // Подсчитываем быков и коров.
                BullsCows(exist, secretNum, guess, out cow, out bull, count);

                Console.WriteLine("В числе " + guess + " находятся " + cow + StrCow(cow) + " и " + bull + StrBull(bull) + "\n");
                // Проверяем на полное соотвествие загадонное и введенное игроком число.
            } while (bull != count);

            Console.WriteLine("\t***ПОБЕДА***\n");
            // Предлагаем сыграть еще раз.
        } while (PlayAgain());
    }
}

