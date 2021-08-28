namespace API_FlowersStore.DataAccess.MSSQL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }

        public string Type { get; set; }

        public Provider Provider { get; set; }
    }
}