namespace MobileFront.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object class for an asset
    /// </summary>
    public class AssetDTO
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public string DepartmentMail { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int Lifespan { get; set; }

        public RemainingLifespanDTO RemainingLifespan { get; set; }
    }
}
