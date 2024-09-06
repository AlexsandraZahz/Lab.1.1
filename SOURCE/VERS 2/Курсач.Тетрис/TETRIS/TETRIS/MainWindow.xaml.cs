using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using TETRIS.MainGame;
namespace TETRIS
{
    /// Логика взаимодействия для MainWindow.xaml
    public partial class MainWindow : Window
    {
        // Инициализация массива изображений для плиток и блоков
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assests/image/TileEmpty.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/TileCyan.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/TileBlue.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/TileOrange.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/TileYellow.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/TileGreen.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/TilePurple.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/TileRed.png",UriKind.Relative))
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assests/image/Block-Empty.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/Block-I.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/Block-J.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/Block-L.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/Block-O.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/Block-S.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/Block-T.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assests/image/Block-Z.png",UriKind.Relative))
        };
        // Инициализация двумерного массива для хранения контролов изображений
        private readonly Image[,] imageControls;
        // Константы для управления скоростью падения блоков
        private readonly int maxDelay = 1000;
        private readonly int minDelay = 100;
        private readonly int delayDecrease = 90;
        // Инициализация состояния игры
        private GameState gameState = new GameState();
        // Конструктор главного окна
        public MainWindow()
        {
            InitializeComponent();
            // Отображение панели меню
            MenuPanel.Visibility = Visibility.Visible;
            // Скрытие холста игры
            GameCanvas.Visibility = Visibility.Hidden;

            // Подписка на события MediaOpened, MediaEnded и MediaFailed для фоновой музыки
            // MediaOpened - событие, которое происходит после того, как музыка была успешно загружена
            backgroundMusic.MediaOpened += backgroundMusic_MediaOpened;
            // MediaEnded - событие, которое происходит после того, как музыка закончила воспроизведение
            backgroundMusic.MediaEnded += backgroundMusic_MediaEnded;
            // MediaFailed - событие, которое происходит при ошибке при загрузке музыки
            backgroundMusic.MediaFailed += BackgroundMusic_MediaFailed;

            // Инициализация контролов изображений на холсте игры
            imageControls = SetupGameCanvas(gameState.GameGrid);

            // Проверка наличия файла сохранения
            FileManager.EnsureFileExists();

            // Установка источника музыки
            backgroundMusic.Source = new Uri("music.mp3", UriKind.Relative);

            // Установка громкости музыки
            backgroundMusic.Volume = 0.1; // Установка громкости на 10%

            // Запуск воспроизведения музыки
            backgroundMusic.Play();
        }
        // Метод для настройки игрового поля
        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            // Создание двумерного массива для хранения контролов изображений
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            // Размер ячейки в пикселях
            int cellSize = 25;

            // Цикл по строкам и столбцам игрового поля
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    // Создание нового контрола изображения для каждой ячейки
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    // Установка позиции контрола на холсте
                    Canvas.SetTop(imageControl, (r - 2) * cellSize);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    // Добавление контрола на холст
                    GameCanvas.Children.Add(imageControl);
                    // Сохранение контрола в массиве
                    imageControls[r, c] = imageControl;
                }
            }
            // Возвращение массива контролов изображений
            return imageControls;
        }

        // Метод для отрисовки игрового поля
        private void DrawGrid(GameGrid grid)
        {
            // Цикл по строкам и столбцам игрового поля
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    // Получение идентификатора ячейки из игрового поля
                    int id = grid[r, c];
                    // Установка непрозрачности контрола изображения
                    imageControls[r, c].Opacity = 1;
                    // Установка изображения контрола из массива tileImages
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }

        // Метод для отрисовки текущего блока
        private void DrawBlock(Block block)
        {
            // Цикл по позициям блока
            foreach (Position p in block.TilePositions())
            {
                // Установка непрозрачности контрола изображения
                imageControls[p.Row, p.Column].Opacity = 1;
                // Установка изображения контрола из массива tileImages для блока
                imageControls[p.Row, p.Column].Source = tileImages[block.Id];
            }
        }

        // Метод для отрисовки следующего блока
        private void DrawNextBlock(BlockQueue blockQueue)
        {
            // Получение следующего блока из очереди блоков
            Block next = blockQueue.NextBlock;
            // Установка изображения следующего блока в контроле NextImage
            NextImage.Source = blockImages[next.Id];
        }

        // Метод для отрисовки удерживаемого блока
        private void DrawHeldBlock(Block heldBlock)
        {
            // Проверка, есть ли удерживаемый блок
            if (heldBlock == null)
            {
                // Если удерживаемый блок отсутствует, устанавливаем изображение для контрола HoldImage
                HoldImage.Source = blockImages[0];
            }
            else
            {
                // Если удерживаемый блок есть, устанавливаем его изображение в контроле HoldImage
                HoldImage.Source = blockImages[heldBlock.Id];
            }
        }

        // Метод для отрисовки "призрака" блока
        private void DrawGhostBlock(Block block)
        {
            // Вычисление расстояния падения блока
            int dropDistance = gameState.BlockDropDistance();

            // Цикл по позициям блока
            foreach (Position p in block.TilePositions())
            {
                // Установка полупрозрачности контрола изображения
                imageControls[p.Row + dropDistance, p.Column].Opacity = 0.25;
                // Установка изображения контрола из массива tileImages для блока
                imageControls[p.Row + dropDistance, p.Column].Source = tileImages[block.Id];
            }
        }

        // Метод для отрисовки всех элементов игры
        private void Draw(GameState gameState)
        {
            // Отрисовка игрового поля
            DrawGrid(gameState.GameGrid);
            // Отрисовка "призрака" текущего блока
            DrawGhostBlock(gameState.CurrentBlock);
            // Отрисовка текущего блока
            DrawBlock(gameState.CurrentBlock);
            // Отрисовка следующего блока
            DrawNextBlock(gameState.BlockQueue);
            // Отрисовка удерживаемого блока
            DrawHeldBlock(gameState.HeldBlock);
            // Обновление текста счета
            ScoreText.Text = $"Счет: {gameState.Score}";
        }

        // Метод для игрового цикла
        private async Task GameLoop()
        {
            // Отрисовка игрового состояния
            Draw(gameState);

            // Инициализация начальной задержки в зависимости от уровня сложности
            int initialDelay = gameState.DifficultyLevel == DifficultyLevel.Easy ? 800 :
                               gameState.DifficultyLevel == DifficultyLevel.Medium ? 400 :
                               gameState.DifficultyLevel == DifficultyLevel.Hard ? 200 :
                               1000;
            // Инициализация задержки
            int delay = gameState.CurrentDelay > 0 ? gameState.CurrentDelay : initialDelay;

            // Основной цикл игры
            while (!gameState.GameOver)
            {
                // Задержка перед следующим шагом
                await Task.Delay(delay);
                // Перемещение блока вниз
                gameState.MoveBlockDown();
                // Отрисовка игрового состояния после перемещения блока
                Draw(gameState);

                // Увеличение скорости падения блоков по мере накопления очков
                int scoreThreshold = gameState.DifficultyLevel == DifficultyLevel.Easy ? 1000 :
                                      gameState.DifficultyLevel == DifficultyLevel.Medium ? 2000 :
                                      gameState.DifficultyLevel == DifficultyLevel.Hard ? 3000 :
                                      1000;
                int speedIncrease = gameState.Score / scoreThreshold;
                // Вычисление новой задержки с учетом увеличения скорости
                delay = Math.Max(minDelay, Math.Min(maxDelay, initialDelay - (speedIncrease * delayDecrease)));
            }

            // Отображение меню окончания игры
            GameOverMenu.Visibility = Visibility.Visible;
            // Обновление текста с финальным счетом
            FinalScoreText.Text = $"Счет: {gameState.Score}";
        }

        // Обработчик события нажатия клавиши
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверка, не закончена ли игра
            if (gameState.GameOver)
            {
                return;
            }
            // Обработка нажатий клавиш для управления блоком
            switch (e.Key)
            {
                case Key.Left:
                    // Перемещение блока влево
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    // Перемещение блока вправо
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    // Перемещение блока вниз
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    // Поворот блока по часовой стрелке
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    // Поворот блока против часовой стрелки
                    gameState.RotateBlockCCW();
                    break;
                case Key.C:
                    // Удержание блока
                    gameState.HoldBlock();
                    break;
                case Key.Space:
                    // Быстрое падение блока
                    gameState.DropBlock();
                    break;
                default:
                    // Если нажата неизвестная клавиша, выход из метода
                    return;
            }
            // Отрисовка игрового состояния после изменения блока
            Draw(gameState);
        }

        // Обработчик события загрузки GameCanvas
        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            // Проверка наличия файла "players.txt"
            FileManager.EnsureFileExists();

            // Запуск игрового цикла
            await GameLoop();
        }

        // Обработчик события нажатия кнопки Start Game
        private async void StartGame_Click(object sender, RoutedEventArgs e)
        {
            // Создание и отображение окна входа
            LoginWindow loginWindow = new LoginWindow();
            bool? result = loginWindow.ShowDialog();

            // Проверка результата входа пользователя
            if (result == true)
            {
                // Пользователь успешно вошел в систему
                string loggedInUsername = loginWindow.LoggedInUsername;

                // Создание и отображение окна выбора уровня сложности
                DifficultySelectionWindow difficultyWindow = new DifficultySelectionWindow();
                bool? difficultyResult = difficultyWindow.ShowDialog();

                // Проверка результата выбора уровня сложности
                if (difficultyResult == true)
                {
                    // Пользователь выбрал уровень сложности
                    DifficultyLevel selectedDifficulty = difficultyWindow.SelectedDifficulty;

                    // Инициализация игрового состояния с выбранным уровнем сложности и именем пользователя
                    gameState = new GameState();
                    gameState.DifficultyLevel = selectedDifficulty;
                    gameState.Username = loggedInUsername;

                    // Скрытие панели меню и отображение холста игры
                    MenuPanel.Visibility = Visibility.Hidden;
                    GameCanvas.Visibility = Visibility.Visible;

                    // Запуск игрового цикла
                    await GameLoop();
                }
            }
        }

        // Обработчик события нажатия кнопки "Справка"
        private void About_Click(object sender, RoutedEventArgs e)
        {
            // Создание и отображение окна "О программе"
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        // Обработчик события нажатия кнопки "Статистика"
        private void HighScores_Click(object sender, RoutedEventArgs e)
        {
            // Создание и отображение окна "Таблица рекордов"
            StatisticsWindow statisticsWindow = new StatisticsWindow();
            statisticsWindow.ShowDialog();
        }

        // Переменная для отслеживания состояния звука (включен/выключен)
        private bool isSoundOn = true;

        // Обработчик события нажатия кнопки переключения звука
        private void ToggleSound_Click(object sender, RoutedEventArgs e)
        {
            // Переключение состояния звука
            isSoundOn = !isSoundOn;
            if (isSoundOn)
            {
                // Установка шаблона кнопки звука в состояние "Включен"
                btnSound.Template = FindResource("SoundOnTemplate") as ControlTemplate;
                // Установка громкости музыки
                backgroundMusic.Volume = 0.1; // Установите нужный уровень громкости
                                              // Запуск воспроизведения музыки
                backgroundMusic.Play(); // Начать воспроизведение музыки
            }
            else
            {
                // Установка шаблона кнопки звука в состояние "Выключен"
                btnSound.Template = FindResource("SoundOffTemplate") as ControlTemplate;
                // Выключение музыки
                backgroundMusic.Volume = 0; // Выключите музыку
            }
        }
        // Переменная для отслеживания состояния звука (включен/выключен)
        // Переменная для отслеживания состояния звука (включен/выключен)
        private bool isSoundOnn = true;

        // Обработчик события нажатия кнопки переключения звука
        private void ToggleSoundm_Click(object sender, RoutedEventArgs e)
        {
            // Переключение состояния звука
            isSoundOnn = !isSoundOnn;
            if (isSoundOnn)
            {
                // Установка шаблона кнопки звука в состояние "Включен"
                btnSoundm.Template = FindResource("SoundOnTemplate") as ControlTemplate;
                // Установка громкости музыки
                backgroundMusic.Volume = 0.1; // Установите нужный уровень громкости
                                              // Запуск воспроизведения музыки
                backgroundMusic.Play(); // Начать воспроизведение музыки
            }
            else
            {
                // Установка шаблона кнопки звука в состояние "Выключен"
                btnSoundm.Template = FindResource("SoundOffTemplate") as ControlTemplate;
                // Выключение музыки
                backgroundMusic.Volume = 0; // Выключите музыку
            }
        }

       // Обработчик события нажатия кнопки "Закончить игру"
        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
        // Отображение диалогового окна с предупреждением
        MessageBoxResult result = MessageBox.Show("Данные будут сохранены. Продолжить?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

        // Проверка результата диалога
        if (result == MessageBoxResult.OK)
        {
            // Если пользователь нажал OK, то сохраняем данные игрока
            PlayerRepository.SavePlayer(new Player(gameState.Username, gameState.Score));
            // Закрываем текущее окно
            this.Close();
        }
        else
        {
            // Если пользователь нажал Cancel, то не сохраняем данные
            // Можно добавить дополнительный код, если нужно выполнить какие-то действия при отмене
        }
        }

        // Обработчик события, когда музыка загружена
        private void backgroundMusic_MediaOpened(object sender, RoutedEventArgs e)
        {
            // Запуск воспроизведения музыки
            backgroundMusic.Play(); // Начать воспроизведение музыки
        }

        // Обработчик события, когда музыка закончила воспроизведение
        private void backgroundMusic_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Остановка воспроизведения музыки
            backgroundMusic.Stop(); // Остановка музыки
                                    // Очистка источника музыки
            backgroundMusic.Source = null; // Очистка источника
                                           // Установка нового источника музыки
            backgroundMusic.Source = new Uri("music.mp3", UriKind.Relative);
            // Запуск воспроизведения музыки заново
            backgroundMusic.Play(); // Запуск музыки заново
        }

        // Обработчик ошибки загрузки музыки
        private void BackgroundMusic_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            // Отображение сообщения об ошибке при загрузке музыки
            MessageBox.Show("Ошибка при загрузке музыки: " + e.ErrorException.Message);
        }

        private async void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение данных игрока
            PlayerRepository.SavePlayer(new Player(gameState.Username, gameState.Score));

            // Закрытие меню завершения игры, если оно открыто
            if (GameOverMenu.Visibility == Visibility.Visible)
            {
                GameOverMenu.Visibility = Visibility.Hidden;
            }

            // Отображение окна входа
            LoginWindow loginWindow = new LoginWindow();
            bool? loginResult = loginWindow.ShowDialog();

            // Проверка результата входа пользователя
            if (loginResult == true)
            {
                // Пользователь успешно вошел в систему
                string loggedInUsername = loginWindow.LoggedInUsername;

                // Отображение окна выбора уровня сложности
                DifficultySelectionWindow difficultyWindow = new DifficultySelectionWindow();
                bool? difficultyResult = difficultyWindow.ShowDialog();

                // Проверка результата выбора уровня сложности
                if (difficultyResult == true)
                {
                    // Пользователь выбрал уровень сложности
                    DifficultyLevel selectedDifficulty = difficultyWindow.SelectedDifficulty;

                    // Инициализация игрового состояния с выбранным уровнем сложности и именем пользователя
                    gameState = new GameState();
                    gameState.DifficultyLevel = selectedDifficulty;
                    gameState.Username = loggedInUsername;

                    // Скрытие панели меню и отображение холста игры
                    MenuPanel.Visibility = Visibility.Hidden;
                    GameCanvas.Visibility = Visibility.Visible;

                    // Запуск игрового цикла
                    await GameLoop();
                }
            }
        }

        // Переменная для отслеживания состояния музыки (включена/выключена)
        private bool isMusicOn = true;

        // Обработчик события нажатия кнопки переключения музыки
        private void ToggleMusic_Click(object sender, RoutedEventArgs e)
        {
            // Переключение состояния музыки
            isMusicOn = !isMusicOn;
            if (isMusicOn)
            {
                // Запуск воспроизведения музыки
                backgroundMusic.Play();
            }
            else
            {
                // Остановка воспроизведения музыки
                backgroundMusic.Stop();
            }
        }

        // Переопределение метода OnClosing для обработки события закрытия окна
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            // Проверка состояния игры и видимости меню
            if (gameState != null && !gameState.GameOver && !MenuPanel.IsVisible)
            {
                // Показ диалогового окна с предупреждением о несохранении данных
                MessageBoxResult result = MessageBox.Show("Учтите, данные не сохраняться!", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    // Пользователь подтвердил закрытие без сохранения
                    // Разрешаем закрытие окна
                }
                else
                {
                    // Пользователь отменил закрытие, предотвращаем закрытие окна
                    e.Cancel = true;
                }
            }
            // Если игра завершена, меню видимо или gameState не инициализирован, сохранять данные не нужно
            // Разрешаем закрытие окна без предупреждения
        }
    }
}
