namespace Common
{
    using System;
    using System.IO;

    public static class ConfigFileFinder
    {
        public static string GetConfigFilePath(string folder, string file)
        {
            string basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string configPath = Path.Combine(basePath, file);

            if (!File.Exists(configPath))
            {
                basePath = basePath + string.Format(@"__config\{0}", folder);
                configPath = Path.Combine(basePath, file);
            }

            return configPath;
        }
    }
}