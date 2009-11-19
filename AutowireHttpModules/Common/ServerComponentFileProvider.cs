namespace Common
{
    using System;

    [Serializable]
    public class ServerComponentFileProvider : IComponentFileProvider
    {
        private const string WindsorConfigFilename = @"windsor.config";

        private ServerComponentFileProvider(string file)
        {
            FileName = file;
        }

        #region IComponentFileProvider Members

        public string FileName { get; private set; }

        public string GetComponentFilePath()
        {
            return ConfigFileFinder.GetConfigFilePath("windsor", FileName);
        }

        #endregion

        public static IComponentFileProvider GetDefaultComponentFileProvider()
        {
            return new ServerComponentFileProvider(WindsorConfigFilename);
        }
    }
}