using Microsoft.Extensions.Configuration;

namespace Module25_Zadanie.DB
{
    class DBConnection
    {
        private static readonly string _connectionString;

        /// <summary>
        /// Инициализация строки подключения к БД из файла настроек appsettings.json
        /// </summary>
        static DBConnection()
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Получение строки подключения к БД
        /// </summary>
        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
