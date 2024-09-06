using System.Collections.Generic;
using System.Windows;
using TETRIS.MainGame;

namespace TETRIS
{
    public partial class StatisticsWindow : Window
    {
        // Конструктор окна статистики
        public StatisticsWindow()
        {
            // Инициализация компонентов XAML
            InitializeComponent();
            // Загрузка статистики при открытии окна
            LoadStatistics();
        }

        // Класс для хранения статистики пользователя
        public class UserStatistics
        {
            // Имя пользователя
            public string Username { get; set; }
            // Очки пользователя
            public int Score { get; set; }
        }

        // Метод для загрузки статистики пользователей
        private void LoadStatistics()
        {
            // Получение списка игроков из репозитория
            List<Player> players = PlayerRepository.GetPlayers();
            // Создание списка для хранения статистики
            List<UserStatistics> statistics = new List<UserStatistics>();

            // Перебор игроков и добавление их статистики в список
            foreach (Player player in players)
            {
                statistics.Add(new UserStatistics { Username = player.Username, Score = player.HighScore });
            }

            // Установка источника данных для DataGrid на основе полученной статистики
            StatisticsDataGrid.ItemsSource = statistics;
        }

        // Обработчик события нажатия кнопки "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Установка результата диалога на false и закрытие окна
            DialogResult = false;
            Close();
        }
    }
}