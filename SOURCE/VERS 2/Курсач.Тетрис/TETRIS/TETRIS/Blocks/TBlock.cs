namespace TETRIS
{
    // Класс, представляющий блок "T" в игре TETRIS, наследующий от абстрактного класса Block
    public class TBlock : Block
    {
        // Массив позиций для каждого состояния блока "T"
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new Position(0,1), new Position(1,0), new Position(1,1), new Position(1,2) },
            new Position[] { new Position(0,1), new Position(1,1), new Position(1,2), new Position(2,1) },
            new Position[] { new Position(1,0), new Position(1,1), new Position(1,2), new Position(2,1) },
            new Position[] { new Position(0,1), new Position(1,0), new Position(1,1), new Position(2,1) }
        };

        // Идентификатор блока "T"
        public override int Id => 6;

        // Начальное смещение блока "T"
        protected override Position StartOffset => new Position(0, 3);

        // Свойство, возвращающее массив позиций для каждого состояния блока "T"
        protected override Position[][] Tiles => tiles;
    }
}