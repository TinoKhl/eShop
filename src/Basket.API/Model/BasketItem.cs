namespace eShop.Basket.API.Model;

public class BasketItem : IValidatableObject
{
    public string Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal OldUnitPrice { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; } // PictureUrl renamed to ImageUrl for consistency
    public int DiscountPrice { get; set; } // New property for discount price   

    public BasketItem(string id, int productId, string productName, decimal unitPrice, decimal oldUnitPrice, int quantity, string imageUrl, int discountPrice)
    {
        Id = id;
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        OldUnitPrice = oldUnitPrice;
        Quantity = quantity;
        ImageUrl = imageUrl;
        DiscountPrice = discountPrice;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Quantity < 1)
        {
            results.Add(new ValidationResult("Invalid number of units", new[] { "Quantity" }));
        }

        if (isValidUrl(ImageUrl) == false)
        {
            results.Add(new ValidationResult("Invalid image URL", new[] { "ImageUrl" }));
        }

        //validate the unit price
        if (UnitPrice <= 0)
        {
            results.Add(new ValidationResult("Invalid unit price", new[] { "UnitPrice" }));
        }

        if (DiscountPrice < 0)
        {
            results.Add(new ValidationResult("Invalid discount price", new[] { "DiscountPrice" }));
        }

        return results;
    }
    
    /// <summary>
    /// Determines whether the specified string is a valid absolute HTTP or HTTPS URL.
    /// </summary>
    /// <param name="url">The URL string to validate.</param>
    /// <returns>
    /// <c>true</c> if the URL is a valid absolute HTTP or HTTPS URL; otherwise, <c>false</c>.
    /// </returns>
    private bool isValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}
