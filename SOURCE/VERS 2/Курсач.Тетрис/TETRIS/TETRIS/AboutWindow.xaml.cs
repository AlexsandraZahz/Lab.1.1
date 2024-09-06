using System.Windows;

namespace TETRIS 
{
    public partial class AboutWindow : Window // Объявление класса AboutWindow, который является наследником класса Window
    {
        public AboutWindow() // Конструктор класса AboutWindow
        {
            InitializeComponent(); // Инициализация компонентов XAML, определенных в XAML-разметке
        }

        // Обработчик события нажатия кнопки "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Установка результата диалога на false, что означает отказ от выбора сложности
            DialogResult = false;
            // Закрытие окна "О программе"
            Close();
        }
    }
}