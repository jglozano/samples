namespace Common
{
    public interface IComponentFileProvider
    {
        string FileName { get; }
        string GetComponentFilePath();
    }
}