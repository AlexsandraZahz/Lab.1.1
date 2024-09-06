using System.Windows;

namespace TETRIS
{
    public partial class LoginWindow : Window
    {
        // Свойство для получения логина пользователя после успешной аутентификации
        public string LoggedInUsername { get; private set; }

        // Конструктор окна входа
        public LoginWindow()
        {
            // Инициализация компонентов XAML
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки "Играть"
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, что пользователь ввел логин
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                // Вывод сообщения об ошибке, если логин не введен
                MessageBox.Show("Пожалуйста, введите логин.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получение введенного логина
            LoggedInUsername = txtUsername.Text;
            // Установка результата диалога на true, что означает успешную аутентификацию
            DialogResult = true;
            // Закрытие окна входа
            Close();
        }

        // Обработчик события нажатия кнопки "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Установка результата диалога на false, что означает отмену аутентификации
            DialogResult = false;
            // Закрытие окна входа
            Close();
        }
    }
}