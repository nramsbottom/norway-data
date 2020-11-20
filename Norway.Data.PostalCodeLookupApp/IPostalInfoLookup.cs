namespace Norway.Data.PostalCodeLookupApp
{
    public interface IPostalInfoLookup
    {
        PostalInfo Lookup(string postalCode);
    }
}
