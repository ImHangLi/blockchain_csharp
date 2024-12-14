namespace blockchain_csharp.Code
{
    internal class Transaction
    {
        internal Guid Id { get; set; }
        internal Guid AccountId { get; set; }
        internal DateTime TransactionDate { get; set; }
        internal decimal TransactionAmount { get; set; }
        internal string Memo { get; set; } = string.Empty;
    }
}