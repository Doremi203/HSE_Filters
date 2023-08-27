namespace Filters;

/// <summary>
/// Базовый класс фильтр
/// </summary>
public class StringFilter
{
    protected int Length { get; }

    /// <summary>
    /// Конструктор, создающий обрезающий фильтр
    /// </summary>
    /// <param name="length">Длина обрезанной строки</param>
    /// <exception cref="ArgumentOutOfRangeException">Ошибка возникает, если длина меньше 0</exception>
    public StringFilter(int length)
    {
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "Длина должна быть больше или равна 0");
        }
        Length = length;
    }

    /// <summary>
    /// Применение фильтра
    /// </summary>
    /// <param name="line">Строка подлежащая фильтрации</param>
    /// <returns>Отфильтрованную строку</returns>
    public virtual string Filter(string line) => line.Length > Length ? line[..Length] : line;
}