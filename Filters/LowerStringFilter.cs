namespace Filters;

/// <summary>
/// Класс отвечающий за фильтр к нижнему регистру
/// </summary>
public class LowerStringFilter : StringFilter
{
    
    /// <summary>
    /// Конструктор создающий фильтр, приводящий строку к нижнему регистру
    /// </summary>
    /// <param name="length">Максимальная длина фильтруемой строки</param>
    public LowerStringFilter(int length) : base(length) { }

    /// <summary>
    /// Фильтрация строки в нижний регистр
    /// </summary>
    /// <param name="line">Строка для обработки</param>
    /// <returns>Строка в нижнем регистре или пустая строка, если длина строки оказалась больше максимальной фильруемой длины</returns>
    public override string Filter(string line) => line.Length > Length ? "" : line.ToLower();
}