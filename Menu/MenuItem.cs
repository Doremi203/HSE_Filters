namespace Menu;

/// <summary>
/// Пункт меню
/// </summary>
/// <param name="Input">Строка, по которой выбирается пункт меню</param>
/// <param name="Description">Строка обозначающая пункт меню в консоли</param>
/// <param name="Action">Действие, вызываемое для пункта меню</param>
public record MenuItem(string Input, string Description, Action Action);