namespace TETRIS
{
    // Класс, представляющий блок "L" в игре TETRIS, наследующий от абстрактного класса Block
    public class LBlock : Block
    {
        // Массив позиций для каждого состояния блока "L"
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new Position(0,2), new Position(1,0), new Position(1,1), new Position(1,2) },
            new Position[] { new Position(0,1), new Position(1,1), new Position(2,1), new Position(2,2) },
            new Position[] { new Position(1,0), new Position(1,1), new Position(1,2), new Position(2,0) },
            new Position[] { new Position(0,0), new Position(0,1), new Position(1,1), new Position(2,1) }
        };

        // Идентификатор блока "L"
        public override int Id => 3;

        // Начальное смещение блока "L"
        protected override Position StartOffset => new Position(0, 3);

        // Свойство, возвращающее массив позиций для каждого состояния блока "L"
        protected override Position[][] Tiles => tiles;
    }
}