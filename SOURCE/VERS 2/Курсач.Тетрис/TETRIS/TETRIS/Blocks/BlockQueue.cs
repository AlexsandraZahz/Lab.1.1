using System;

namespace TETRIS
{
    // Класс, представляющий очередь блоков в игре TETRIS
    public class BlockQueue
    {
        // Массив всех возможных блоков в игре
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new OBlock(),
            new JBlock(),
            new LBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        // Экземпляр класса Random для генерации случайных чисел
        private readonly Random random = new Random();

        // Свойство, возвращающее следующий блок в очереди
        public Block NextBlock { get; private set; }

        // Конструктор, инициализирующий очередь блоков
        public BlockQueue()
        {
            // Устанавливаем начальный блок в очереди
            NextBlock = RandomBlock();
        }

        // Метод для получения случайного блока из массива блоков
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        // Метод для получения следующего блока из очереди и обновления очереди
        public Block GetAndUpdate()
        {
            // Получаем текущий блок из очереди
            Block block = NextBlock;

            // Генерируем новый блок, пока он не отличается от текущего по идентификатору
            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            // Возвращаем текущий блок из очереди
            return block;
        }
    }
}