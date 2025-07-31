using System;
using System.IO;
using System.Text;

partial class Program
{
    /// <summary>
    /// Возвращает файлы в данной директории.
    /// </summary>
    /// <returns></returns>
    public static (FileInfo[], string) GetDirectoryFiles()
    {
        try
        {
            return (s_directory.GetFiles(), "");
        }
        catch (UnauthorizedAccessException ex)
        {
            return (new FileInfo[0], "!!! Нет доступа к данной директории: " + ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {
            return (new FileInfo[0], "!!! Данной директории не существует: " + ex.Message);
        }
        catch (Exception ex)
        {
            return (new FileInfo[0], "!!! Произошла ошибка: " + ex.Message);
        }
    }

    /// <summary>
    /// Перегрузка метода GetDirectoryFiles, возвращает файлы из данной директории по маске.
    /// </summary>
    /// <param name="mask">Маска</param>
    /// <param name="subdirectory">Следует ли смотреть в поддиректориях</param>
    /// <returns></returns>
    public static (FileInfo[], string) GetDirectoryFiles(string mask, bool subdirectory)
    {
        try
        {
            return (s_directory.GetFiles(mask, subdirectory ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly), "");
        }
        catch (ArgumentException ex)
        {
            return (new FileInfo[0], "Неправильно заданна маска: " + ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return (new FileInfo[0], "!!! Нет доступа к данной директории: " + ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {
            return (new FileInfo[0], "!!! Данной директории не существует: " + ex.Message);
        }
        catch (Exception ex)
        {
            return (new FileInfo[0], "!!! Произошла ошибка: " + ex.Message);
        }
    }

    /// <summary>
    /// Считывает текст из файла, в данной кодировке.
    /// </summary>
    /// <param name="codeNum">Номер кодировки в массиве s_encodings</param>
    /// <param name="file">Файл, который необходимо прочитать</param>
    /// <returns>Считанный текст, сообщение об ошибке</returns>
    public static (string, string) ReadFile(int codeNum, FileInfo file)
    {
        Encoding code = Encoding.GetEncoding(s_encodings[codeNum - 1].ToLower());
        try
        {
            return (File.ReadAllText(file.FullName, code), "");
        }
        catch (DirectoryNotFoundException ex)
        {
            return ("", "!!! Данной директории не существует: " + ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return ("", "!!! Нет доступа к данной директории: " + ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            return ("", "!!! Данного файла не существует: " + ex.Message);
        }
        catch (IOException ex)
        {
            return ("", "!!! При открытии файла произошла ошибка ввода-вывода: " + ex.Message);
        }
        catch (Exception ex)
        {
            return ("", "!!! Произошла ошибка: " + ex.Message);
        }
    }

    /// <summary>
    /// Копирует файл.
    /// </summary>
    /// <param name="sourceFile">Исходный файл</param>
    /// <param name="forCopying">Директория, в которую необходимо скопировать файл</param>
    /// <param name="WordCopy">Стоит ли добавлять слово Copy в название созданной копии</param>
    /// <param name="overwrite">Стоит ли перезаписывать файл, если файл с названием создаваемой копии уже существует</param>
    /// <returns>Сообщение об ошибке</returns>
    public static string CopyFile(FileInfo sourceFile, DirectoryInfo forCopying, bool WordCopy, bool overwrite)
    {
        try
        {
            string path2 = Path.Combine(forCopying.FullName, (WordCopy ? "Copy" : "") + sourceFile.Name);
            File.Copy(sourceFile.FullName, path2, overwrite);
            return "";
        }
        catch (IOException ex)
        {
            return ("Ошибка ввода-вывода при копировании файла:" + ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return ("Ошибка доступа:" + ex.Message);
        }
        catch (Exception ex)
        {
            return ("Ошибка при копировании файла:" + ex.Message);
        }
    }
    /// <summary>
    /// Удаляет файл.
    /// </summary>
    /// <param name="file">Файл, который необходимо удалить</param>
    /// <returns>Сообщение об ошибке</returns>
    public static string DeleteFile(FileInfo file)
    {
        try
        {
            file.Delete();
            return "";
        }
        catch (Exception ex)
        {
            return "!!! Ошибка при удалении файла: " + ex.Message;
        }
    }
    /// <summary>
    /// Создает файл в данной кодировке.
    /// </summary>
    /// <param name="codeNum">Номер кодироки в массиве s_encodings</param>
    /// <param name="name">Имя создаваемого файла</param>
    /// <param name="text">Текст, который необходимо поместить в созданный файл</param>
    /// <returns></returns>
    public static string CreateFile(int codeNum, string name, string text)
    {
        Encoding code = Encoding.GetEncoding(s_encodings[codeNum - 1].ToLower());
        try
        {
            File.WriteAllText(Path.Combine(s_directory.FullName, name), text, code);
            return "";
        }
        catch (ArgumentException ex)
        {
            return "!!! Путь содержит недопустимые символы: " + ex.Message;
        }
        catch (DirectoryNotFoundException ex)
        {
            return "!!! Данной директории не существует: " + ex.Message;
        }
        catch (UnauthorizedAccessException ex)
        {
            return "!!! Ошибка доступа: " + ex.Message;
        }
        catch (IOException ex)
        {
            return "!!! При открытии файла произошла ошибка: " + ex.Message;
        }
        catch (Exception ex)
        {
            return "!!! Произошла ошибка: " + ex.Message;
        }
    }

    /// <summary>
    /// Конкатенирует содержание нескольких файлов.
    /// </summary>
    /// <param name="files">Массив файлов</param>
    /// <returns>Сконкатенированный текст</returns>
    public static (string, string) ConcatinateFiles(FileInfo[] files)
    {
        StringBuilder text = new StringBuilder("");
        for (int i = 0; i < files.Length; i++)
        {
            string currentFileText;
            string error;
            (currentFileText, error) = ReadFile(3, files[i]);
            if (error == "")
                text.Append(currentFileText);
            else
                return ("", error);
        }
        return (text.ToString(), "");
    }

    /// <summary>
    /// Создает новую директорию.
    /// </summary>
    /// <param name="path">Путь</param>
    /// <returns>Сообщение об ошибке</returns>
    public static string CreateDirectory(string path)
    {
        try
        {
            Directory.CreateDirectory(path);
            return "";
        }
        catch (UnauthorizedAccessException ex)
        {
            return "Ошибка доступа: " + ex.Message;
        }
        catch (IOException ex)
        {
            return "Неправильно задан путь: " + ex.Message;
        }
        catch (Exception ex)
        {
            return "Произошла ошибка: " + ex.Message;
        }
    }
}