﻿using System.IO;
using System.Runtime.Serialization;

namespace SkyForgeEditor.Extentions
{
    internal static class Serializer
    {
        public static void ToFile<T>(T instance, string path)
        {
            try
            {
                using var filesystem = new FileStream(path, FileMode.Create);
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(filesystem, instance);
            }
            catch
            {
                //TODO: get the log error
            }
        }
    }
}