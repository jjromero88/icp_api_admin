using Microsoft.Extensions.Configuration;

namespace PCM.SIP.ICP.Transversal.Common
{
    public static class ApplicationKeys
    {

        private static IConfigurationRoot _config;
        static ApplicationKeys()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            _config = builder.Build();
        }

        public static string estructuraPath => _config["DocumentStorage:EstructuraPath"];
        public static string modalidadIntegridadPath => _config["DocumentStorage:ModalidadIntegridadPath"];
        public static string documentoIntegridad => _config["DocumentStorage:DocumentoIntegridad"];
    }
}
