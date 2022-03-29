namespace work
{
    public class Order
    {
        public Order(OrderDetails ods)
        {
            this.ods = ods;
        }

        public Order()
        {
        }

        public OrderDetails ods { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Order order &&
                   EqualityComparer<OrderDetails>.Default.Equals(ods, order.ods);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ods);
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}