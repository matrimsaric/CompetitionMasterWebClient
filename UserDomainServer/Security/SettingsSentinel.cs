namespace UserDomainServer.Security
{
    public class SettingsSentinel
    {
        public const string APP_CONFIGURATION_COMMON_SECTION = "Common";
        public const string APP_CONFIGURATION_SETTING_SENTINEL = "Sentinel";

        public int Sentinel { get; set; }

        public TenantsMap TenantsMap { get; set; } = new TenantsMap();
    }
}
