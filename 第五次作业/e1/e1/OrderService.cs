using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work
{
    public class OrderService
    {
        Dictionary<int,Order> ordermap { get; set; }



        public static void WriteXML(OrderService ds)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(OrderService));

            var path = System.IO.Directory.GetCurrentDirectory() + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, ds);
            file.Close();
        }
        public void export()
        {
            WriteXML(this);
        }

        public void import()
        {
            // First write something so that there is something to read ...  
            var reader = new System.Xml.Serialization.XmlSerializer(typeof(OrderDetails));
            var path = System.IO.Directory.GetCurrentDirectory() + "//SerializationOverview.xml";

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            OrderService os = (OrderService)reader.Deserialize(file);
            file.Close();
            foreach(var item in os.ordermap)
            {
                this.ordermap.Add(item.Key,item.Value);
            }
            

        }

        public OrderService()
        {
            ordermap = new Dictionary<int,Order>();
        }

        public void addOrUpdate(Order o)
        {
            ordermap.Add(o.ods.id,o);
        }

        public bool removeById(Order o)
        {
            return ordermap.Remove(o.ods.id);
        }

        public List<Order> selectAll()
        {
            return(from order
             in ordermap.Values
             orderby order.ods.id
             select order
              ).ToList();
        }

        public Order selectByid(int ID)
        {
            return (Order)(from order
              in ordermap.Values
              where order.ods.id == ID
                    select order
              );
        }

        public Order selectBypname(string pname)
        {
            return (Order)(from order
              in ordermap.Values
                           where order.ods.pname == pname
                           select order
              );
        }

        public List<Order> selectByclient(string client)
        {
            return (from order
              in ordermap.Values
                           where order.ods.client == client
                           orderby order.ods.id
                           select order
              ).ToList();
        }

        public List<Order> selectBymoney(int money)
        {
            return (from order
              in ordermap.Values
                    where order.ods.money == money
                    orderby order.ods.id
                    select order
              ).ToList();
        }

    }
}
