namespace MobileFront.Models
{
    public class Asset
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string DepartmentMail { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int Lifespan { get; set; }

        private string State { get; set; }

        public RemainingLifespan RemainingLifespan { get; set; }
    }
}
