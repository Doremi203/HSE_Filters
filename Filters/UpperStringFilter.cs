namespace Filters;

/// <summary>
/// Класс отвечающий за фильтр к верхнему регистру
/// </summary>
public class UpperStringFilter : StringFilter
{
    
    /// <summary>
    /// Конструктор создающий фильтр, приводящий строку к верхнему регистру
    /// </summary>
    /// <param name="length">Максимальная длина фильтруемой строки</param>
    public UpperStringFilter(int length) : base(length) { }
    
    /// <summary>
    /// Фильтрация строки в верхний регистр
    /// </summary>
    /// <param name="line">Строка для обработки</param>
    /// <returns>Строка в верхнем регистре или пустая строка, если длина строки оказалась больше максимальной фильруемой длины</returns>
    public override string Filter(string line) => line.Length > Length ? "" : line.ToUpper();
}