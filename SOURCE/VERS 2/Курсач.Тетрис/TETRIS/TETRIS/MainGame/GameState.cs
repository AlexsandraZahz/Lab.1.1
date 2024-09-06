namespace TETRIS
{
    public class GameState
    {
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock; // Геттер для получения текущего блока
            private set // Сеттер для установки нового текущего блока
            {
                currentBlock = value; // Установка нового блока
                currentBlock.Reset(); // Сброс позиции и ориентации блока

                // Перемещение блока вниз на 2 позиции, если он не помещается в начальное положение
                for (int i = 0; i < 2; i++)
                {
                    CurrentBlock.Move(1, 0); // Попытка перемещения блока на одну позицию вниз

                    // Если блок не помещается, возвращаем его на одну позицию вверх
                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        // Свойство для доступа к игровому полю
        public GameGrid GameGrid { get; }

        // Свойство для доступа к очереди блоков
        public BlockQueue BlockQueue { get; }

        // Свойство, указывающее, закончена ли игра
        public bool GameOver { get; private set; }

        // Свойство для доступа к текущему счету
        public int Score { get; private set; }

        // Свойство для доступа к удерживаемому блоку
        public Block HeldBlock { get; private set; }

        // Свойство, указывающее, может ли быть удержан блок
        public bool CanHold { get; private set; }

        // Свойство для доступа к текущей задержке
        public int CurrentDelay { get; set; }

        // Свойство для доступа к уровню сложности
        public DifficultyLevel DifficultyLevel { get; set; }

        // Свойство для доступа к имени пользователя
        public string Username { get; set; }

        // Конструктор для создания нового экземпляра состояния игры
        public GameState()
        {
            // Инициализация игрового поля и очереди блоков
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();

            // Получение и установка текущего блока из очереди
            CurrentBlock = BlockQueue.GetAndUpdate();

            // Разрешение удерживания блока
            CanHold = true;
        }

        // Метод для проверки, помещается ли текущий блок в игровое поле
        private bool BlockFits()
        {
            if (CurrentBlock == null)
            {
                return false;
            }

            // Проверка, что все позиции блока пусты в игровом поле
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        // Метод для удержания текущего блока
        public void HoldBlock()
        {
            // Проверка, разрешено ли удерживать блок
            if (!CanHold)
            {
                return;
            }

            // Если удерживаемый блок не установлен, устанавливаем его и получаем новый блок из очереди
            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            // Если удерживаемый блок уже установлен, меняем местами текущий и удерживаемый блоки
            else
            {
                Block tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }

            // Запрещаем удерживать блок после первого удержания
            CanHold = false;
        }

        public void RotateBlockCW()
        {
            // Поворачиваем блок по часовой стрелке
            CurrentBlock.RotateCW();
            // Если блок не помещается в игровое поле после поворота, возвращаем его в исходное положение
            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        public void RotateBlockCCW()
        {
            // Поворачиваем блок против часовой стрелки
            CurrentBlock.RotateCCW();
            // Если блок не помещается в игровое поле после поворота, возвращаем его в исходное положение
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        public void MoveBlockLeft()
        {
            // Перемещаем блок влево
            CurrentBlock.Move(0, -1);
            // Если блок не помещается в игровое поле после перемещения, возвращаем его в исходное положение
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            // Перемещаем блок вправо
            CurrentBlock.Move(0, 1);
            // Если блок не помещается в игровое поле после перемещения, возвращаем его в исходное положение
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            // Проверяем, не заполнены ли верхние две строки игрового поля
            // Если заполнены, значит игра окончена
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            // Если текущий блок не установлен, выходим из метода
            if (CurrentBlock == null)
            {
                return;
            }

            // Проверяем, можно ли разместить блок в игровом поле
            bool canPlace = true;
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    canPlace = false;
                    break;
                }
            }

            // Если можно разместить блок, размещаем его, увеличиваем счет, очищаем заполненные строки и проверяем, не закончена ли игра
            if (canPlace)
            {
                foreach (Position p in CurrentBlock.TilePositions())
                {
                    Score += GameGrid[p.Row, p.Column] = CurrentBlock.Id;
                }

                GameGrid.ClearFullRows();

                if (IsGameOver())
                {
                    GameOver = true;
                }
                else
                {
                    CurrentBlock = BlockQueue.GetAndUpdate();
                    CanHold = true;
                }
            }
        }

        public void MoveBlockDown()
        {
            // Перемещаем текущий блок вниз
            CurrentBlock.Move(1, 0);

            // Если блок не помещается в игровое поле после перемещения вниз, возвращаем его на место и размещаем блок
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        private int TileDropDistance(Position p)
        {
            int drop = 0;

            // Проверяем, может ли каждая плитка падать еще на одну позицию вниз
            while (GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }

            // Возвращаем максимальное расстояние, на которое может падать плитка
            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows; // Начальное расстояние падения устанавливается на максимальное количество строк

            // Проходим по всем позициям текущего блока и находим минимальное расстояние падения
            foreach (Position p in CurrentBlock.TilePositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }

            // Возвращаем минимальное расстояние падения для всех плиток блока
            return drop;
        }

        public void DropBlock()
        {
            // Перемещаем текущий блок на расстояние, найденное методом BlockDropDistance
            CurrentBlock.Move(BlockDropDistance(), 0);
            // Размещаем блок в игровом поле
            PlaceBlock();
        }
    }
}
