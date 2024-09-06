namespace TETRIS
{
    // Класс, представляющий блок "Z" в игре TETRIS, наследующий от абстрактного класса Block
    public class ZBlock : Block
    {
        // Массив позиций для каждого состояния блока "Z"
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new Position(0,0), new Position(0,1), new Position(1,1), new Position(1,2) },
            new Position[] { new Position(0,2), new Position(1,1), new Position(1,2), new Position(2,1) },
            new Position[] { new Position(1,0), new Position(1,1), new Position(2,1), new Position(2,2) },
            new Position[] { new Position(0,1), new Position(1,0), new Position(1,1), new Position(2,0) }
        };

        // Идентификатор блока "Z"
        public override int Id => 7;

        // Начальное смещение блока "Z"
        protected override Position StartOffset => new Position(0, 3);

        // Свойство, возвращающее массив позиций для каждого состояния блока "Z"
        protected override Position[][] Tiles => tiles;
    }
}