using Microsoft.VisualStudio.TestTools.UnitTesting;
using work;

namespace e2.单元测试
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            OrderService or = new OrderService();
            or.addOrUpdate(new Order(new OrderDetails(001,"zhangsan","com",1)));
            Assert.AreEqual(new Order(new OrderDetails(001, "zhangsan", "com", 1)), or.selectByid(001));
        }

        [TestMethod]
        public void TestMethod2()
        {
            OrderService or = new OrderService();
            or.addOrUpdate(new Order(new OrderDetails(001, "zhangsan", "com", 1)));
            or.removeById(new Order(new OrderDetails(001,null, null, 0)));
            Assert.AreEqual(null, or.selectByid(001));
        }
        [TestMethod]
        public void TestMethod3()
        {
            OrderService or = new OrderService();
            or.addOrUpdate(new Order(new OrderDetails(001, "zhangsan", "com", 1)));
            or.export();
        }
        [TestMethod]
        public void TestMethod4()
        {
            OrderService or = new OrderService();
            or.import();
        }
        [TestMethod]
        public void TestMethod5()
        {
            OrderService or = new OrderService();
            or.addOrUpdate(new Order(new OrderDetails(001, "zhangsan", "com", 1)));
            or.selectByid(001);
            Assert.AreEqual(new Order(new OrderDetails(001, "zhangsan", "com", 1)), or.selectByid(001));
        }

    }
}