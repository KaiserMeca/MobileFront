namespace MobileFront.Models
{
    /// <summary>
    /// Represents information about the remaining lifespan of an object
    /// </summary>
    public class RemainingLifespan
    {
        /// <summary>
        /// Gets or sets the purchase date of the object
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the lifespan of the object in years
        /// </summary>
        public int Lifespan { get; set; }

        /// <summary>
        /// Gets or sets the remaining lifespan of the object as a string
        /// </summary>
        public string RemainingDuration { get; set; }
    }
}
