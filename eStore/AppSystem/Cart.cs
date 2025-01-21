namespace eStore.AppSystem
{
    public class Cart
    {
        public Dictionary<Product, int> Products { get; set; }

        public Cart()
        {
            Products = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int quantity)
        {
            if (Products.ContainsKey(product))
            {
                Products[product] += quantity;
            }
            else
            {
                Products.Add(product, quantity);
            }
        }

        public void ClearCart()
        {
            Products.Clear();
        }

        public decimal TotalPrice()
        {
            return Products.Sum(p => p.Key.Price * p.Value);
        }
    }
}