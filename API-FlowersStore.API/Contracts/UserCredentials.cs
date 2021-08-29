namespace API_FlowersStore.API.Contracts
{
    /// <summary>
    /// Учетные данные пользователя системы (поставщик, админ и т.д. ).
    /// </summary>
    public class UserCredentials

    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
