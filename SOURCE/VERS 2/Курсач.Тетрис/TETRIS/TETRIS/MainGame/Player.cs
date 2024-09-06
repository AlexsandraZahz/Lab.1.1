using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TETRIS.MainGame
{
    public class Player
    {
        // Свойство для имени пользователя
        public string Username { get; set; }
        // Свойство для максимального количества очков
        public int HighScore { get; set; }

        // Конструктор для создания нового игрока
        public Player(string username, int highScore)
        {
            Username = username;
            HighScore = highScore;
        }

        // Переопределение метода ToString для представления игрока в виде строки
        public override string ToString()
        {
            return $"{Username},{HighScore}";
        }

        // Статический метод для создания игрока из строки
        public static Player FromString(string playerString)
        {
            string[] parts = playerString.Split(',');
            if (parts.Length == 2 && int.TryParse(parts[1], out int highScore))
            {
                return new Player(parts[0], highScore);
            }
            return null;
        }
    }

    public static class PlayerRepository
    {
        // Путь к файлу, в котором хранятся данные о игроках в bin -> Debug
        private const string FilePath = "players.txt";

        // Статический метод для получения списка игроков из файла
        public static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    Player player = Player.FromString(line);
                    if (player != null)
                    {
                        players.Add(player);
                    }
                }
            }
            // Сортировка списка игроков по очкам в порядке убывания
            return players.OrderByDescending(p => p.HighScore).ToList();
        }

        // Статический метод для сохранения игрока в файл
        public static void SavePlayer(Player player)
        {
            // Получение списка игроков из файла
            List<Player> players = GetPlayers();

            // Проверка, существует ли уже игрок с таким же логином
            Player existingPlayer = players.FirstOrDefault(p => p.Username == player.Username);
            if (existingPlayer != null)
            {
                // Обновление существующего игрока, добавление очков к текущим очкам
                existingPlayer.HighScore += player.HighScore;
            }
            else
            {
                // Добавление нового игрока в список
                players.Add(player);
            }

            // Сохранение обновленного списка игроков в файл
            File.WriteAllLines(FilePath, players.Select(p => p.ToString()));
        }
    }
}