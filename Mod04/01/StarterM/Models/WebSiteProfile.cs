namespace StarterM.Models
{
    public class WebSiteProfile
    {
        public string Email { get; set; } = "default@uuu.com.tw";
        public string ThemeColor { get; set; } = "yellow";

        [ConfigurationKeyName("My.Name")]
        public string MyName { get; set; } = "default";


    }
}
