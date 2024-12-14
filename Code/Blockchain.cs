namespace blockchain_csharp.Code
{
    internal class Blockchain 
    {
        internal List<Block> Chain { get; set; } = [];
        internal int Difficulty { get; set; }

        public Blockchain(int difficulty)
        {
            Difficulty = difficulty;
            Chain = [];
            AddGenesisBlock();
        }

        internal void AddGenesisBlock()
        {
            Chain.Add(new Block(0, DateTime.Now, "Genesis Block", ""));
        }

        internal Block GetLatestBlock()
        {
            return Chain[^1];
        }

        internal void AddBlock(Block block)
        {
            block.PreviousHash = GetLatestBlock().Hash;
            block.MineBlock(Difficulty);
            Chain.Add(block);
        }

        internal bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }

            return true;
        }
    }
}