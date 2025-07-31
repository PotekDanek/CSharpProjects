using System;
using System.IO;

partial class Program
{
    // s_startScreenOptions - список реализованных операций.
    private static readonly  string[] s_startScreenOptions = {"просмотр списка дисков компьютера и выбор диска",
            "переход в другую директорию (выбор папки)",
            "просмотр списка файлов в директории",
            "вывод содержимого текстового файла в консоль в выбранной пользователем кодировке",
            "копирование файла",
            "перемещение файла в выбранную пользователем директорию",
            "удаление файла",
            "создание простого текстового файла в выбранной пользователем кодировке",
            "конкатенация содержимого двух или более текстовых файлов и вывод результата в консоль в кодировке UTF - 8",
            "выполнить вывод всех файлов по заданной маске в текущей директории (и всех её поддиректориях)",
            "скопировать все файлы из директории и всех её поддиректорий по маске в другую директорию"};
    // s_encodings - список доступных кодировок.
    private static readonly string[] s_encodings = { "ASCII", "Unicode", "UTF-8", "UTF-32" };

    /// <summary>
    /// Выводит название программы.
    /// </summary>
    public static void ProgramName()
    {
        // Устанавливаем желтый цвет шрифта.
        Console.ForegroundColor = ConsoleColor.Yellow;
        // Выводим название.
        Console.WriteLine(@".----.______");
        Console.WriteLine(@"|           |     ______ _ _       ___  ___");
        Console.WriteLine(@"|    ___________  |  ___(_) |      |  \/  |                                   ");
        Console.WriteLine(@"|   /          /  | |_   _| | ___  | .  . | __ _ _ __   __ _  __ _  ___ _ __  ");
        Console.WriteLine(@"|  /          /   |  _| | | |/ _ \ | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__| ");
        Console.WriteLine(@"| /          /    | |   | | |  __/ | |  | | (_| | | | | (_| | (_| |  __/ |    ");
        Console.WriteLine(@"|/__________/     \_|   |_|_|\___| \_|  |_/\__,_|_| |_|\__,_|\__, |\___|_|    ");
        Console.WriteLine(@"                                                              __/ |           ");
        Console.WriteLine(@"                                                             |___/           ");
        // Возвращаем цвет шрифта к исходным параметрам.
        Console.ResetColor();
    }

    /// <summary>
    /// Спрашивает у пользователя, какую операцию он хочет выполнить.
    /// </summary>
    /// <param name="operation"></param>
    /// <returns>Номер операции</returns>
    public static int ReadOption(string optionName, params string[] options)
    {
        Console.WriteLine();
        Console.WriteLine($"Выберите {optionName}, введя соответствующую ей цифру (1-{options.Length}):");
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"\t{i + 1} - {options[i]}");
        }
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > options.Length)
        {
            PrintErrorMessage("!!! Ошибка ввода, повторите попытку !!!");
        }
        return number;
    }
    
    /// <summary>
    /// Выводит сообщение об ошибке.
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    static void PrintErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    /// <summary>
    /// Выводит сообщение об успешном выполнении операции.
    /// </summary>
    /// <param name="message">Текст сообщения</param>
    static void PrintGreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    /// <summary>
    /// Предоставляет возможность выбора диска.
    /// </summary>
    /// <returns>Выбранный диск</returns>
    public static DriveInfo ChooseDrive()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        Console.WriteLine("Выберите один диск из списка, введя соответствующий ему номер (1-{0})", allDrives.Length);
        // Выодим список дисков
        for (int i = 0; i < allDrives.Length; i++)
            Console.WriteLine($"{i + 1} - {allDrives[i].Name}");
        int driveNum;
        // Обработка ошибок
        do
        {
            while (!int.TryParse(Console.ReadLine(), out driveNum) || driveNum > allDrives.Length || driveNum < 1)
            {
                PrintErrorMessage("!!! Ошибка ввода, повторите попытку !!!");
            }
            if (!allDrives[driveNum - 1].IsReady)
            {
                PrintErrorMessage("!!! Невозможно использовать этот диск, повторите попытку !!!");
            }
        } while (!allDrives[driveNum - 1].IsReady);
        return allDrives[driveNum - 1];
    }

    /// <summary>
    /// Предоставляет возможность выбора директории.
    /// </summary>
    /// <returns>Выбранная директория</returns>
    public static DirectoryInfo ChooseDirectory()
    {
        bool inputFlag;
        string path = "";
        // Проверяем выбран ли диск.
        if (s_drive == null)
        {
            Console.WriteLine("Перед выбором директории необходимо выбрать диск");
            s_drive = ChooseDrive();
        }
        do
        {
            inputFlag = true;
            Console.WriteLine("Введите абсолютный путь до директории: ");
            Console.Write(s_drive.Name);
            try
            {
                path = Path.Combine(s_drive.Name, Console.ReadLine());
            }
            // Обработка ошибок.
            catch (ArgumentException ex)
            {
                PrintErrorMessage("!!! Путь содержит один или несколько недопустимых символов : " + ex.Message);
                inputFlag = false;
            }
            catch (Exception ex)
            {
                PrintErrorMessage("!!! Ошибка ввода :" + ex.Message);
                inputFlag = false;
            }
            if (!Directory.Exists(path))
            {
                PrintErrorMessage("!!! Неверный ввод директории !!!");
                inputFlag = false;
            }
        } while (!inputFlag);
        return new DirectoryInfo(path);
    }

    /// <summary>
    /// Предоставляет возможность выбора файла.
    /// </summary>
    /// <param name="forWhat">Пояснение, для чего выбирается файл</param>
    /// <returns>Выбранный файл</returns>
    public static FileInfo ChooseFile(string forWhat)
    {
        CheckDirectoryIsInitialized();
        Console.WriteLine($"\nВыберите файл {forWhat} из директории {s_directory.Name}");
        // Предлагаем вывести список файлов.
        if (AskYesNo("Хотите вывести список файлов?"))
        {
            FileInfo[] files;
            string error;
            (files, error) = GetDirectoryFiles();
            if (files.Length == 0 && error == "")
            {
                PrintErrorMessage("!!! В данной директории нет файлов !!!");
                return null;
            }
            PrintFileNames(files, error);
        }
        Console.Write($"Файл {forWhat}: ");
        string path = "";
        try
        {
            path = Path.Combine(s_directory.FullName, Console.ReadLine());
        }
        catch (ArgumentException ex)
        {
            PrintErrorMessage("!!! Путь содержит один или несколько недопустимых символов : " + ex.Message);
            return null;
        }
        catch (Exception ex)
        {
            PrintErrorMessage("!!! Ошибка ввода :" + ex.Message);
            return null;
        }
        if (!File.Exists(path))
        {
            PrintErrorMessage("!!! Невверный ввод файла !!!");
            return null;
        }
        return new FileInfo(path);
    }

    /// <summary>
    /// Печатает список файлов.
    /// </summary>
    /// <param name="files">Файлы</param>
    /// <param name="error">Сообщение об ошибке</param>
    public static void PrintFileNames(FileInfo[] files, string error)
    {
        if (files.Length != 0)
        {
            Console.WriteLine($"Список файлов в директории {s_directory.Name}:");
            foreach (var file in files)
            {
                Console.WriteLine("\t" + file.Name);
            }
        }
        else
        {
            if (error == "")
                Console.WriteLine("Файлов не найденно");
            else
                PrintErrorMessage(error);
        }
    }

    /// <summary>
    /// Проверяет выбрана ли директория.
    /// </summary>
    public static void CheckDirectoryIsInitialized()
    {
        if (s_directory == null)
        {
            Console.WriteLine("\nПеред выполнением данной операции необходимо выбрать директорию");
            s_directory = ChooseDirectory();
        }
    }

    /// <summary>
    /// Задает вопрос с возможным ответом (да/нет).
    /// </summary>
    /// <param name="question">Текст Вопроса</param>
    /// <returns>да - true, нет - false</returns>
    static bool AskYesNo(string question)
    {
        Console.WriteLine(question);
        Console.Write("Введите Yes/No: ");
        while (true)
        {
            string input = Console.ReadLine();
            if (input != null) 
                input = input.ToLower();
            if (!(input == "yes" || input == "no"))
            {
                PrintErrorMessage("!!! Невверный ввод, повторите попытку !!!");
            }
            else
            {
                return input == "yes";
            }
        }
    }

    /// <summary>
    /// Предоставляет возможность выбора дополнительной директории.
    /// </summary>
    /// <param name="ForWhat">Пояснение для чего выберается</param>
    /// <param name="createNew">Стоит ли создавать новую, если выбранной директории не существует</param>
    /// <returns>Выбранная директория</returns>
    public static DirectoryInfo ChooseAuxiliaryDirectory(string ForWhat, bool createNew)
    {
        string path;
        bool InputFlag;
        Console.WriteLine("\nВведите абсолютный путь до директории, " + ForWhat +
            "\n\t(нажмите Enter, если хотите выбрать исходную папку):");
        do
        {
            InputFlag = true;
            path = Console.ReadLine();
            // Если нажат Enter.
            if (path == "")
            {
                path = s_directory.FullName;
            }
            if (!Directory.Exists(path))
                if (!createNew)
                {
                    InputFlag = false;
                    PrintErrorMessage("!!! Неверный ввод директории !!!");
                }
                else
                {
                    string error = CreateDirectory(path);
                    if (error != "")
                    {
                        PrintErrorMessage(error);
                        InputFlag = false;
                    }
                }
        } while (!InputFlag);
        return new DirectoryInfo(path);
    }

    /// <summary>
    /// Предоставляет возможность выбора нескольких файлов.
    /// </summary>
    /// <param name="ForWhat">Пояснение для чего выберается</param>
    /// <param name="min">Минимальное количество</param>
    /// <param name="max">Максимальное количество</param>
    /// <returns>Массив файлов</returns>
    public static FileInfo[] ChooseFileInfos(string ForWhat, int min, int max)
    {
        int n;
        string path;
        Console.Write($"Введите количество файлов, {ForWhat} ({min}-{max}): ");
        while (!int.TryParse(Console.ReadLine(), out n) || n < min || n > max)
            PrintErrorMessage("!!! Ошибка ввода, повторите попытку !!!");
        FileInfo[] files = new FileInfo[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите абсолютный путь {i + 1}-ого файла:");
            path = Console.ReadLine();
            while (!File.Exists(path))
            {
                PrintErrorMessage("!!! Данного файла не существует !!!");
                Console.Write($"Введите абсолютный путь {i + 1}-ого файла:");
                path = Console.ReadLine();
            }
            files[i] = new FileInfo(path);
        }
        return files;
    }

    /// <summary>
    /// Запрашивает маску.
    /// </summary>
    /// <returns>Маска</returns>
    public static string GetMask()
    {
        Console.WriteLine("Введите маску, по которой хотите выполнить поиск");
        Console.WriteLine("Вы можете использовать следующие подстановочные символы:" +
            "\n\t* - Ноль или более символов в этой позиции" +
            "\n\t? - Ноль или один символ в этой позиции" +
            "\nСимволы, отличные от подстановочных знаков, являются литеральными символами.");
        return Console.ReadLine();
    }

    /// <summary>
    /// Запрашивает информацию о создаваемом файле.
    /// </summary>
    /// <returns>имя и текст, который следует поместить в файл</returns>
    public static (string,string) GetInformationAboutNewFile()
    {
        Console.Write("Введите имя создаваемого файла (с кодировкой): ");
        string name = Console.ReadLine();
        Console.Write("Введите текст, который необходимо поместить в созданный файл: ");
        string text = Console.ReadLine();
        return (name, text);
    }
}