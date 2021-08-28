using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API_FlowersStore.API
{

    /// <summary>
    /// Класс для генерации токена.
    /// </summary>
    public class AuthOptions
    {
        /// <summary>
        /// Издатель токена.
        /// </summary>
        public const string ISSUER = "API-FlowersStore.API";

        /// <summary>
        /// Потребитель токена
        /// </summary>
        public const string AUDIENCE = "API-FlowersStore.API.Client";

        /// <summary>
        /// Ключ для шифрования.
        /// </summary>
        const string KEY = "secretKey1234089!!!!";

        /// <summary>
        /// Время жизни токена в минутах
        /// </summary>
        public const int LIFETIME = 100;

        /// <summary>
        /// Returns a new instance of Microsoft.IdentityModel.Tokens.SymmetricSecurityKey
        /// </summary>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
