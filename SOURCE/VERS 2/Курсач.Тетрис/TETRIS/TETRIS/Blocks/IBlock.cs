namespace TETRIS
{
    // Класс, представляющий блок "I" в игре TETRIS, наследующий от абстрактного класса Block
    public class IBlock : Block
    {
        // Массив позиций для каждого состояния блока "I"
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new Position(1,0), new Position(1,1), new Position(1,2), new Position(1,3) },
            new Position[] { new Position(0,2), new Position(1,2), new Position(2,2), new Position(3,2) },
            new Position[] { new Position(2,0), new Position(2,1), new Position(2,2), new Position(2,3) },
            new Position[] { new Position(0,1), new Position(1,1), new Position(2,1), new Position(3,1) }
        };

        // Идентификатор блока "I"
        public override int Id => 1;

        // Начальное смещение блока "I"
        protected override Position StartOffset => new Position(-1, 3);

        // Свойство, возвращающее массив позиций для каждого состояния блока "I"
        protected override Position[][] Tiles => tiles;
    }
}