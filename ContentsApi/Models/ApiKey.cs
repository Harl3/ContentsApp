namespace ContentsApi.Models
{
    public class ApiKey
    {
        public ApiKey(int id, string owner, string key, DateTime created)
        {
            Id = id;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Created = created;
        }

        public int Id { get; }
        public string Owner { get; }
        public string Key { get; }
        public DateTime Created { get; }
    }
}