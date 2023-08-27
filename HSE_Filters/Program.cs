using Filters;
using Menu;
using Utilities;

namespace HSE_Filters;

internal static class Program
{
    private static List<string>? _file;
    private static List<string>? _filteredFile;
    private static bool _isCanceled;
    private static int _n;
    private static string? _filePath;
    
    /// <summary>
    /// Меню приложения
    /// </summary>
    private static readonly MenuItem[] Menu =
    {
        new("0", "выйти из программы", () =>
        {
            _isCanceled = true;
            Console.WriteLine("Вы вышли из программы");
        }),
        new("1", "загрузить файл", LoadFile),
        new("2", "применить фильтры", ApplyFilters),
        new("3", "вывести текущий отфильтрованный файл в консоль", ShowFilteredFile),
        new("4", "записать текущий отфильтрованный файл", SaveToFile),
    };

    private static void Main()
    {
        while (!_isCanceled)
        {
            MenuHandler.ShowMenu(Menu);
            MenuHandler.ProcessMenu(Menu);
        }
    }

    /// <summary>
    /// Загрузка файла
    /// </summary>
    private static void LoadFile()
    {
        Console.WriteLine("Введите имя файла(не путь)");
        _filePath = Console.ReadLine();
        _file = FileHandler.ReadFile(_filePath!);
        Console.WriteLine($"Файл {_filePath} успешно загружен и готов к обработке");
    }
    
    /// <summary>
    /// Применение фильтров
    /// </summary>
    private static void ApplyFilters()
    {
        CheckIfFileIsLoaded();
        
        Console.WriteLine("Введите число N, до которого нужно урезать строку");
        var input = Console.ReadLine();
        if (!int.TryParse(input, out _n) || _n <= 1)
            throw new ArgumentException("Ошибка, введите целое число N > 1");
        
        _filteredFile = new List<string>();
        var filter = new StringFilter(_n);
        var lowerFilter = new LowerStringFilter(_n);
        var upperFilter = new UpperStringFilter(_n);
        
        /*
         * За счёт экземплярности фильтров можно было бы добавить возможность создавать несколько фильтров
         * с разными параметрами и использовать их по выбору пользователя
         */
        
        foreach (var filteredStr in _file!.Select(str => filter.Filter(str)))
        {
            if (filteredStr.ToUpper() == filteredStr.ToLower())
            {
                _filteredFile.Add(filteredStr);
            }
            else
            {
                _filteredFile.Add(upperFilter.Filter(filteredStr));
                _filteredFile.Add(lowerFilter.Filter(filteredStr));   
            }
        }
    }
    
    /// <summary>
    /// Вывод отфильтрованного файла в консоль
    /// </summary>
    private static void ShowFilteredFile()
    {
        CheckIfFileIsLoaded();
        CheckIfFileIsFiltered();
        Console.WriteLine("Текущее состояние фильтруемого файла:");
        Console.WriteLine("*************************************");
        _filteredFile!.ForEach(Console.WriteLine);
        Console.WriteLine("*************************************");
    }
    
    /// <summary>
    /// Сохранение отфильтрованного файла
    /// </summary>
    private static void SaveToFile()
    {
        CheckIfFileIsLoaded();
        CheckIfFileIsFiltered();
        FileHandler.Write($"Result{_filePath}", _filteredFile!);
        Console.WriteLine($"Файл Result{_filePath} записан");
    }
    
    /// <summary>
    /// Проверка на то, что файл загружен
    /// </summary>
    /// <exception cref="NullReferenceException">Ошибка выбрасывается, если файл не был загружен</exception>
    private static void CheckIfFileIsLoaded()
    {
        if (_file is null) 
            throw new NullReferenceException("Сначала необходимо загрузить файл");
    }
    
    /// <summary>
    /// Проверка на то, что файл был отфильтрован
    /// </summary>
    /// <exception cref="NullReferenceException">Ошибка выбрасывается, если файл не был отфильтрован ни разу</exception>
    private static void CheckIfFileIsFiltered()
    {
        if (_filteredFile is null) 
            throw new NullReferenceException("Сначала необходимо отфильтровать файл");
    }

}