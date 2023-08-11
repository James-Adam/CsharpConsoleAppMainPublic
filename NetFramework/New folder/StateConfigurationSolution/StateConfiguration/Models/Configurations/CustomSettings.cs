namespace StateConfiguration.Models.Configurations
{
    public class CustomSettings
    {
        public string StringSetting { get; set; } = "Default Setting";
        public int IntSetting { get; set; } = 12345;
        public List<string> Countries { get;set; } = new List<string> {"USA","India","China" };
    }
}
