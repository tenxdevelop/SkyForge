
namespace SkyForgeEditor.Infrastructure.Extentions.Serializator
{
    public interface ISerializer
    {
        void SaveToFile<T>(T instance, string path);

        T? LoadFromFile<T>(string path);
    }
}
