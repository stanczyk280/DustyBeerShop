namespace DustyBeerShop.Domain
{
    public class Beer : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PictureUri { get; set; }
        public string BeerType { get; set; }
        public string BeerBrand { get; set; }
    }
}