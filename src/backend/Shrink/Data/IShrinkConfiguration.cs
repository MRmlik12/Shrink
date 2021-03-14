namespace Shrink.Models
{
    public interface IShrinkConfiguration
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }
    }
}