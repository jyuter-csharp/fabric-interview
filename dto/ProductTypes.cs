namespace FabricAPI.dto
{
    public class ProductTypes
    {
        private static readonly Dictionary<string, string[]> ProductTypesDictionary = new Dictionary<string, string[]>();
        public static readonly string[] INVALID = new[] { Strings.INVALID };

        public ProductTypes() {
            ProductTypesDictionary[Strings.MILK] = new[] { Strings.CHILLED };
            ProductTypesDictionary[Strings.YOGURT] = new[] { Strings.CHILLED };
            ProductTypesDictionary[Strings.CHEESE] = new[] { Strings.CHILLED };
            ProductTypesDictionary[Strings.INSULIN] = new[] { Strings.CHILLED, Strings.HAZARD };
            ProductTypesDictionary[Strings.BLEACH] = new[] { Strings.HAZARD };
            ProductTypesDictionary[Strings.STAIN_REMOVAL] = new[] { Strings.HAZARD };
            ProductTypesDictionary[Strings.BREAD] = Array.Empty<string>();
            ProductTypesDictionary[Strings.PASTA] = Array.Empty<string>();
            ProductTypesDictionary[Strings.SALT] = Array.Empty<string>();
            ProductTypesDictionary[Strings.BAMBA] = Array.Empty<string>();
            ProductTypesDictionary[Strings.APPLE] = Array.Empty<string>();
        }

        public string[] GetProductType(string product)
        {
            if (ProductTypesDictionary.ContainsKey(product))
            {
                return ProductTypesDictionary[product];
            }
            return INVALID;
        }
    }
}
