using Newtonsoft.Json;

namespace MobileFront.Models
{
    /// <summary>
    /// Class representing an asset
    /// </summary>
    public class Asset
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public int Department { get; set; }

        public string DepartmentMail { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int Lifespan { get; set; }

        public string? State { get; set; }

        /// <summary>
        /// Gets or sets the remaining lifespan information of the asset
        /// </summary>
        public RemainingLifespan RemainingLifespan { get; set; }
    }
}
