using System;
using System.IO;

partial class Program
{
    // drive - выбранный диск.
    private static DriveInfo s_drive = null;
    // directory - выбранная папка.
    private static DirectoryInfo s_directory = null;

    /// <summary>
    /// Основной метод программы.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // Вызываем методы в соответствии с выбранной пользователем операцией.
        do
        {
            Console.Clear();
            ProgramName();
            // operation - номер операции.
            int operation = ReadOption("операцию", s_startScreenOptions);
            FileInfo file;
            DirectoryInfo auxiliaryDirectory;
            string text;
            FileInfo[] files;
            // error - текст сообщения об ошибке
            string error;
            switch (operation)
            {
                case 1:
                    s_drive = ChooseDrive();
                    break;
                case 2:
                    s_directory = ChooseDirectory();
                    break;
                case 3:
                    CheckDirectoryIsInitialized();
                    (files, error) = GetDirectoryFiles();
                    PrintFileNames(files, error);
                    break;
                case 4:
                    file = ChooseFile("для чтения");
                    if (file == null)
                        break;
                    int codeNum = ReadOption("кодировку", s_encodings);
                    (text, error) = ReadFile(codeNum, file);
                    if (error == "")
                        Console.WriteLine(text);
                    else
                        PrintErrorMessage(error);
                    break;
                case 5:
                    file = ChooseFile("для копирования");
                    if (file == null)
                        break;
                    auxiliaryDirectory = ChooseAuxiliaryDirectory("в которую надо скопировать файл", false);
                    error = CopyFile(file, auxiliaryDirectory, true, true);
                    if (error == "")
                        PrintGreenMessage("Файл скопирован");
                    else
                        PrintErrorMessage(error);
                    break;
                case 6:
                    file = ChooseFile("для перемещения");
                    if (file == null)
                        break;
                    auxiliaryDirectory = ChooseAuxiliaryDirectory("в которую надо перенести файл", false);
                    // Случай перемещения в исходную директорию
                    if (auxiliaryDirectory.FullName == s_directory.FullName)
                    {
                        PrintGreenMessage("Файл перемещен");
                        break;
                    }
                    error = CopyFile(file, auxiliaryDirectory, false, true);
                    if (error != "")
                    {
                        PrintErrorMessage(error);
                        break;
                    }
                    error = DeleteFile(file);
                    if (error == "")
                        PrintGreenMessage("Файл перемещен");
                    else
                        PrintErrorMessage(error);
                    break;
                case 7:
                    file = ChooseFile("для удаления");
                    if (file == null)
                        break;
                    error = DeleteFile(file);
                    if (error == "")
                        PrintGreenMessage("Файл удален");
                    else
                        PrintErrorMessage(error);
                    break;
                case 8:
                    CheckDirectoryIsInitialized();
                    codeNum = ReadOption("кодировку", s_encodings);
                    string name;
                    (name, text) = GetInformationAboutNewFile();
                    error = CreateFile(codeNum, name, text);
                    if (error == "")
                        PrintGreenMessage("Файл создан");
                    else
                        PrintErrorMessage(error);
                    break;
                case 9:
                    files = ChooseFileInfos("содержимое которых вы хотите сконкатенировать", 2, 5);
                    (text, error) = ConcatinateFiles(files);
                    if (error == "")
                        Console.WriteLine(text);
                    else
                        PrintErrorMessage(error);
                    break;
                case 10:
                    CheckDirectoryIsInitialized();
                    (files, error) = GetDirectoryFiles(GetMask(), AskYesNo("Нужно ли искать в подкатегориях?"));
                    PrintFileNames(files, error);
                    break;
                case 11:
                    CheckDirectoryIsInitialized();
                    (files, error) = GetDirectoryFiles(GetMask(), true);
                    if (error != "")
                    {
                        PrintErrorMessage(error);
                        break;
                    }
                    auxiliaryDirectory = ChooseAuxiliaryDirectory("в которую надо скопировать файлы", true);
                    bool overwrite = AskYesNo("При наличии файла с таким же названием в директории, в которую копируются файлы, стоит ли заменять его на новый ?");
                    foreach (var f in files)
                    {
                        error = CopyFile(f, auxiliaryDirectory, true, overwrite);
                        if (error != "")
                        {
                            PrintErrorMessage(error);
                            break;
                        }
                    }
                    PrintGreenMessage("Файлы скопированы");
                    break;
            }
            // Реализуем повтор решения.
            Console.WriteLine("Нажмите ESC для выхода из программы, для продолжения работы нажмите любую другую клавишу\n\t(выбранные диск и папка будут сохранены, чтобы сменить их выберите соответствующую операцию (1 или 2)).");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
