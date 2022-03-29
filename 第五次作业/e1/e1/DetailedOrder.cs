namespace work
{
    public class OrderDetails
    {
        public OrderDetails(int id, string pname, string client, int money)
        {
            this.id = id;
            this.pname = pname;
            this.client = client;
            this.money = money;
        }

        public OrderDetails()
        {

        }

        public int id { get; set; }
        public string pname { get; set; }

        public string client { get; set; }

        public int money { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is OrderDetails details &&
                   id == details.id &&
                   pname == details.pname &&
                   client == details.client &&
                   money == details.money;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, pname, client, money);
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}