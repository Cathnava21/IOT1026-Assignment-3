using Assignment;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

            Assert.AreEqual(pack.GetMaxCount(), PackMaxItems);
        }
        [TestMethod]
        public void VolumeOverflowTest()
        {
            const int PackMaxItems = 1000;
            const float PackMaxVolume = 5;
            const float PackMaxWeight = 3000;

            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            Assert.AreEqual(pack.Add(new Bow()), true);
            Assert.AreEqual(pack.Add(new Bow()), false);
        }
        [TestMethod]
        public void Add_SingleItemToEmptyPack_ReturnsTrue()
        {
            Pack pack = new Pack();
            Arrow arrow = new Arrow();
            bool result = pack.Add(arrow);

            Assert.IsTrue(result);
            Assert.AreEqual(1, pack.GetCurrentCount());
        }
        [TestMethod]
        public void Add_MultipleItemsWithinConstraints_ReturnsTrue()
        {
            Pack pack = new Pack();
            Bow bow = new Bow();
            Rope rope = new Rope();
            bool result1 = pack.Add(bow);
            bool result2 = pack.Add(rope);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.AreEqual(2, pack.GetCurrentCount());
        }
        [TestMethod]
        public void Add_ItemsExceedingConstraints_ReturnsFalse()
        {
            Pack pack = new Pack(2, 2f, 2f);
            Arrow arrow1 = new Arrow();
            Arrow arrow2 = new Arrow();
            Arrow arrow3 = new Arrow();
            bool result1 = pack.Add(arrow1);
            bool result2 = pack.Add(arrow2);
            bool result3 = pack.Add(arrow3);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }
        [TestMethod]
        public void Add_ItemsAtConstraints_ReturnsTrue()
        {
            Pack pack = new Pack(2, 2f, 2f);
            Arrow arrow1 = new Arrow();
            Arrow arrow2 = new Arrow();
            bool result1 = pack.Add(arrow1);
            bool result2 = pack.Add(arrow2);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.AreEqual(2, pack.GetCurrentCount());
        }
        [TestMethod]
        public void Add_NegativeValuesForMaxCount()
        {
            Assert.ThrowsException<OverflowException>(() => new Pack(-10, 20f, 30f));
        }
        public void Add_NegativeValuesForVolume()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Pack(10, -20f, 30f));
        }
        public void Add_NegativeValuesForWeight()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Pack(10, 20f, -30f));
        }
    }
}
