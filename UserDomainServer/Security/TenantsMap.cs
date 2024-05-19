namespace UserDomainServer.Security
{
    public class TenantsMap
    {
        public Dt[] Dts { get; set; } = new Dt[0];

    }

    public class Dt
    {
        public string D { get; set; }

        public string T { get; set; }
    }
}
