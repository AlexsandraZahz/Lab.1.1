namespace TETRIS
{
    // Класс, представляющий позицию на игровом поле
    public class Position
    {
        // Свойство для доступа к строке позиции
        public int Row { get; set; }

        // Свойство для доступа к столбцу позиции
        public int Column { get; set; }

        // Конструктор, который принимает строку и столбец и инициализирует свойства Row и Column
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}