namespace DonationAPI.Middleware
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class AuthAttribute : Attribute
    {
        public AuthAttribute() { }
    }
}
