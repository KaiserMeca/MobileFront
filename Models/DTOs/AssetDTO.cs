namespace MobileFront.Models.DTOs
{
    public class AssetDTO
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public string DepartmentMail { get; set; }

        public DateTime PurchaseDate { get; set; }

        public RemainingLifespanDTO RemainingLifespan { get; set; }
    }
}
