using System.IO;

public static class FileManager // Объявление статического класса FileManager
{
    private const string FilePath = "players.txt"; // Константа, определяющая путь к файлу "players.txt"

    // Метод для проверки существования файла и его создания, если он не существует
    public static void EnsureFileExists()
    {
        // Проверка наличия файла по указанному пути
        if (!File.Exists(FilePath))
        {
            // Создание файла и закрытие потока
            File.Create(FilePath).Close();
        }
    }
}