public class Order{
    private List<Product> _products;
    private Customer _customer;

    //constructor
    public Order(List<Product> products, Customer customer){
        _products = products;
        _customer = customer;
    }

    public double GetTotalPrice(){
        double total = 0;

        foreach (Product product in _products){
            total += product.GetTotalCost();
        }

        if (_customer.LivesInUSA()){
            total += 5;
        }else{
            total += 35;
        }
        return total;
    }

    public string GetPackingLabel(){
        string label = "Packing Label:\n";

        foreach (Product product in _products){
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel(){
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    } 
}