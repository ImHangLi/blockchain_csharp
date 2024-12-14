using System.Security.Cryptography;
using System.Text;

namespace blockchain_csharp.Code
{
    internal class Block
    {
        internal int Index { get; set; }
        internal DateTime Timestamp { get; set; }
        internal string Hash { get; set; } = string.Empty;
        internal string PreviousHash { get; set; } = string.Empty;
        internal string Data { get; set; } = string.Empty;
        internal int Nonce { get; set; }

        internal Block(int index, DateTime timestamp, string data, string previousHash)
        {
            Index = index;
            Timestamp = timestamp;
            Data = data;
            PreviousHash = previousHash;
            Hash = CalculateHash();
        }

        internal string CalculateHash()
        {   
            // Covert the block data to a byte array suitable for cryptographic operations
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{Index}-{Timestamp}-{PreviousHash}-{Data}-{Nonce}");

            // Use the SHA256 algorithm to compute the hash
            byte[] outputBytes = SHA256.HashData(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        internal void MineBlock(int difficulty)
        {
            // Create a string with difficulty leading zeros
            string leadingZeros = new string('0', difficulty);

            // While the hash does not start with the required number of zeros
            while (Hash[..difficulty] != leadingZeros)
            {
                // Increment the nonce and recalculate the hash
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }   
}