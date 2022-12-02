namespace Application.ApiBE
{
    public class SymbolConfig
    {

        //This Info would never go this way, it should go on the secrets. But as the secrets it`s not meant to share
        //I will leave it on the appsettings.json here for the sake of the test.
        public string BaseAddress { get; set; } = default!;
        public string Key { get; set; } = default!;
        public string Host { get; set; } = default!;
    }
}
