namespace StarterM.Models
{
    [Serializable]
    public class Temp
    {
        public int TempId { get; set; }
        public string? TempName { get; set; }
        [NonSerialized()]
        public string? Content { get; set; }
    }
}
