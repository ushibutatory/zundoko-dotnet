namespace Zundoko.Core.Models.Abstracts
{
    public interface IConsole
    {
        IConsole Write(string text);

        IConsole WriteLine();

        IConsole WriteLine(string text);
    }
}
