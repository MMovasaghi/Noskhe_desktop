
namespace noskhe_drugstore_app.Models
{
    class LoginToken
    {
        public string token { get; set; }
        public long expiration { get; set; }
    }
}
