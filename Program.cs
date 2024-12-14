using System;
using blockchain_csharp.Code;

namespace blockchain_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int difficulty;
            do
            {
                Console.Write("Enter a difficulty level (must greater than 0): ");
                string? input = Console.ReadLine();

                // Check for null or invalid input
                if (!int.TryParse(input, out difficulty) || difficulty <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a number greater than 0.");
                    continue;
                }

                break; // Exit the loop if input is valid
            } while (true);

            Console.WriteLine($"You selected difficulty: {difficulty}");

            Blockchain blockchain = new(difficulty);

            while (true)
            {
                Console.WriteLine("Enter a command (add/view/validate/exit):");
                string? command = Console.ReadLine();

                switch (command)
                {
                    case "add":
                        Console.WriteLine("Enter the data for the new block:");
                        string data;
                        do
                        {
                            string? input = Console.ReadLine();
                            if (string.IsNullOrEmpty(input))
                            {
                                Console.WriteLine("Data cannot be empty. Please try again.");
                                continue;
                            }

                            data = input;
                            break;
                        } while (true);

                        Block newBlock = new(blockchain.Chain.Count, DateTime.Now, data, blockchain.GetLatestBlock().Hash);
                        blockchain.AddBlock(newBlock);
                        Console.WriteLine("Block added successfully!");
                        break;

                    case "view":
                        foreach (var block in blockchain.Chain)
                        {
                            Console.WriteLine($"Index: {block.Index}, Timestamp: {block.Timestamp}, Data: {block.Data}, Hash: {block.Hash}, PreviousHash: {block.PreviousHash}, Nonce: {block.Nonce}");
                        }
                        break;

                    case "validate":
                        bool isValid = blockchain.IsChainValid();
                        Console.WriteLine($"Blockchain is {(isValid ? "valid" : "invalid")}");
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }
    }
}