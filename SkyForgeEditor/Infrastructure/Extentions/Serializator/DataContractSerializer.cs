using System.IO;

namespace SkyForgeEditor.Infrastructure.Extentions.Serializator
{
    internal class DataContractSerializer : ISerializer
    {
        public void SaveToFile<T>(T instance, string path)
        {
            try
            {
                using var filesystem = new FileStream(path, FileMode.Create);
                var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(T));
                serializer.WriteObject(filesystem, instance);
            }
            catch
            {
                //TODO: get the log error
            }
        }

        public T? LoadFromFile<T>(string path)
        {
            try
            {
                using var filesystem = new FileStream(path, FileMode.Open);
                var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(T));
                return (T?)serializer.ReadObject(filesystem);
            }
            catch
            {
                //TODO: get the log error
                return default;
            }
        }
    }
}
