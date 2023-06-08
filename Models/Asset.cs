namespace MobileFront.Models
{
    public class Asset
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public int Department { get; set; }

        public string DepartmentMail { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int Lifespan { get; set; }

        public string? State { get; set; }

        public RemainingLifespan RemainingLifespan { get; set; }
    }
}
