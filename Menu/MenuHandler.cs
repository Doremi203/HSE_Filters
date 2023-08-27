namespace Menu;

/// <summary>
/// Класс обработчик меню
/// </summary>
public static class MenuHandler
{
    /// <summary>
    /// Вывод меню приложения
    /// </summary>
    public static void ShowMenu(IEnumerable<MenuItem> menu)
    {
        foreach (var item in menu)
        {
            Console.WriteLine($"Введите \"{item.Input}\", чтобы {item.Description}");
        }
    }
    
    /// <summary>
    /// Обработка меню приложения
    /// </summary>
    /// <param name="menu">Меню для обработки</param>
    /// <exception cref="ArgumentException">Исключение выбрасывается, если выбранного пункта меню не существует</exception>
    public static void ProcessMenu(IEnumerable<MenuItem> menu)
    {
        try
        {
            var input = Console.ReadLine();
            var menuItem = menu.FirstOrDefault(i => i.Input == input);
            if (menuItem is null)
                throw new ArgumentException("Несуществующая команда, повторите ввод");
            menuItem.Action();
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FileLoadException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException)
        {
            Console.WriteLine("Закройте файл, над которым проводится операция");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Кодировка windows-1251 не поддерживается на данной платформе");
        }
    }
    
}