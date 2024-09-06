namespace TETRIS
{
    // Класс, представляющий блок "O" в игре TETRIS, наследующий от абстрактного класса Block
    public class OBlock : Block
    {
        // Массив позиций для состояния блока "O"
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new Position(0,0), new Position(0,1), new Position(1,0), new Position(1,1) }
        };

        // Идентификатор блока "O"
        public override int Id => 4;

        // Начальное смещение блока "O"
        protected override Position StartOffset => new Position(0, 4);

        // Свойство, возвращающее массив позиций для состояния блока "O"
        protected override Position[][] Tiles => tiles;
    }
}