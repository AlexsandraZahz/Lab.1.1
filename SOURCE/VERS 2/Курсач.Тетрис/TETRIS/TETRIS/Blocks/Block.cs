using System.Collections.Generic;

namespace TETRIS
{
    // Абстрактный класс, представляющий блок в игре TETRIS
    public abstract class Block
    {
        // Абстрактное свойство, возвращающее массив позиций для каждого состояния блока
        protected abstract Position[][] Tiles { get; }

        // Абстрактное свойство, возвращающее начальное смещение блока
        protected abstract Position StartOffset { get; }

        // Абстрактное свойство, возвращающее идентификатор блока
        public abstract int Id { get; }

        // Текущее состояние поворота блока
        private int rotationState;

        // Текущее смещение блока
        private Position offset;

        // Конструктор, инициализирующий начальное смещение блока
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        // Метод, возвращающий позиции всех плиток блока с учетом смещения и поворота
        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        // Метод для поворота блока по часовой стрелке
        public void RotateCW()
        {
            // Увеличиваем состояние поворота на 1 и обнуляем при достижении максимального значения,
            // чтобы вернуться к начальному состоянию поворота после полного оборота
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        // Метод для поворота блока против часовой стрелки
        public void RotateCCW()
        {
            // Если состояние поворота равно 0, то устанавливаем его на максимальное значение,
            // чтобы завершить полный оборот и вернуться к предыдущему состоянию
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            // Иначе уменьшаем состояние поворота на 1, чтобы выполнить поворот на 90 градусов против часовой стрелки
            else
            {
                rotationState--;
            }
        }

        // Метод для перемещения блока на заданное количество строк и столбцов
        public void Move(int rows, int columns)
        {
            // Изменяем смещение блока на заданное количество строк и столбцов
            offset.Row += rows;
            offset.Column += columns;
        }

        // Метод для сброса состояния блока до начального
        public void Reset()
        {
            // Возвращаем состояние поворота к начальному
            rotationState = 0;
            // Возвращаем смещение блока к начальному
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}