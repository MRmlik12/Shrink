namespace Shrink.Models
{
    public class ShrinkConfiguration : IShrinkConfiguration
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }
    }
}