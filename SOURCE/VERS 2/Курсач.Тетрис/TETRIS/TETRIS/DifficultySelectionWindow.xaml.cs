using System.Windows;

namespace TETRIS
{
    public partial class DifficultySelectionWindow : Window
    {
        // Конструктор окна выбора уровня сложности
        public DifficultySelectionWindow()
        {
            // Инициализация компонентов XAML
            InitializeComponent();
        }

        // Свойство для получения выбранного уровня сложности
        public DifficultyLevel SelectedDifficulty { get; private set; }

        // Обработчик события нажатия кнопки "Выбрать"
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, что пользователь выбрал уровень сложности
            if (DifficultyComboBox.SelectedIndex == -1)
            {
                // Вывод сообщения об ошибке, если уровень сложности не выбран
                MessageBox.Show("Пожалуйста, выберите уровень сложности.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получение выбранного уровня сложности из индекса выбранного элемента комбобокса
            SelectedDifficulty = (DifficultyLevel)DifficultyComboBox.SelectedIndex;
            // Установка результата диалога на true, что означает подтверждение выбора сложности
            DialogResult = true;
            // Закрытие окна выбора сложности
            Close();
        }

        // Обработчик события нажатия кнопки "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Установка результата диалога на false, что означает отказ от выбора сложности
            DialogResult = false;
            // Закрытие окна выбора сложности
            Close();
        }
    }

    // Перечисление уровней сложности
    public enum DifficultyLevel
    {
        Easy, // Легко
        Medium, // Средне
        Hard // Сложно
    }
}