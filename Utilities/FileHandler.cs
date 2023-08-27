using System.Text;

namespace Utilities;

/// <summary>
/// Класс обработчик файлов
/// </summary>
public static class FileHandler
{
    
    /// <summary>
    /// Чтение файла
    /// </summary>
    /// <param name="filePath">Путь по которому считывается файл</param>
    /// <returns>Файл в виде списка строк</returns>
    /// <exception cref="FileNotFoundException">Ошибка возникает, если файл не найден в папке с исполняемым файлом</exception>
    /// <exception cref="FileLoadException">Ошибка возникает, если загружаемый файл пуст</exception>
    public static List<string> ReadFile(string filePath)
    {
        if (filePath is null || !filePath.EndsWith(".txt")) 
            throw new ArgumentException("Некорректное имя файла");
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Файл с указанным именем не существует");

        var file = new List<string>();

        using var reader = new StreamReader(filePath);
        while (reader.ReadLine() is { } line)
        {
            if (!string.IsNullOrEmpty(line))
            {
                file.Add(line);
            }
        }
        reader.Close();
        
        if (file.Count == 0)
            throw new FileLoadException("Ошибка загрузки файла, файл не содержит информации");

        return file;
    }
    
    /// <summary>
    /// Запись в файл
    /// </summary>
    /// <param name="filePath">Путь по которому записывается файл</param>
    /// <param name="file">Файл в виде списка, который записывается</param>
    /// <exception cref="ArgumentException">Ошибка возникает, если путь для записи отсутствует или расширение не txt</exception>
    public static void Write(string? filePath, List<string> file)
    {
        if (filePath is null || !filePath.EndsWith(".txt")) 
            throw new ArgumentException("Некорректное имя файла");
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        using var sw = new StreamWriter(filePath, false, Encoding.GetEncoding(1251));
        file.Where(s => !string.IsNullOrEmpty(s)).ToList().ForEach(str => sw.WriteLine(str));
    }

}