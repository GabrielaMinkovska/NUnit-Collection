

using Collections;

namespace Collection.UnitTests
{
    public class CollectionTests
    {

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            //Arrange and Act
            var coll = new Collection<int>();

            //Assert
            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var coll = new Collection<int>(5);

            //Assert
            Assert.AreEqual(coll.ToString(), "[5]");
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var coll = new Collection<int>(5, 6);

            //Assert
            Assert.AreEqual(coll.ToString(), "[5, 6]");

        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var coll = new Collection<int>(5, 6);

            //Assert
            Assert.AreEqual(coll.Count, 2);
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }

        [Test]
        public void Test_Collection_Add()
        {
            //Arrange
            var coll = new Collection<int>(5, 6);

            //Act
            coll.Add(7);

            //Assert
            Assert.AreEqual(coll.ToString(), "[5, 6, 7]");
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            //Arrange
            var coll = new Collection<int>(5, 6);

            //Act
            coll.AddRange(7, 8);

            //Assert
            Assert.AreEqual(coll.ToString(), "[5, 6, 7, 8]");
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var coll = new Collection<int>(5, 6, 7, 8);
            var item = coll[3];

            Assert.That(item.ToString(), Is.EqualTo("8"));
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var coll = new Collection<int>(5, 6, 7, 8);
            coll[2] = 4;

            Assert.That(coll.ToString(), Is.EqualTo("[5, 6, 4, 8]"));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var coll = new Collection<int>(5, 6, 7, 8);

            Assert.That(() => { var item = coll[4]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);

            int initialCapacity = coll.Capacity;
            int newItem = 6;
            coll.Add(newItem);

            Assert.AreEqual(coll.Count, 6);
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(initialCapacity));
            Assert.AreEqual(coll[coll.Count - 1], newItem);
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }


        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var coll = new Collection<int>(5, 6, 7, 8);

            Assert.Throws<ArgumentOutOfRangeException>(() => coll[4] = 9);
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);
            int newItem = 0;

            coll.InsertAt(0, newItem);

            Assert.AreEqual(coll.Count, 6);
            Assert.AreEqual(coll[0], newItem);
            Assert.AreEqual(coll[1], 1);

            Assert.AreEqual(coll.ToString(), "[0, 1, 2, 3, 4, 5]");
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);
            int newItem = 6;

            coll.InsertAt(coll.Count, newItem);

            Assert.AreEqual(coll.Count, 6);
            Assert.AreEqual(coll[coll.Count - 1], newItem);

            Assert.AreEqual(coll.ToString(), "[1, 2, 3, 4, 5, 6]");
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            var coll = new Collection<int>(1, 2, 4, 5);
            int newItem = 3;

            coll.InsertAt(2, newItem);

            Assert.AreEqual(coll.Count, 5);
            Assert.AreEqual(coll[2], newItem);

            Assert.AreEqual(coll.ToString(), "[1, 2, 3, 4, 5]");
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            var coll = new Collection<int>(1, 2, 4, 5);
            int initialCapacity = coll.Capacity;
            int newItem = 3;

            coll.InsertAt(2, newItem);

            Assert.AreEqual(coll.Count, 5);
            Assert.AreEqual(coll[2], newItem);

            Assert.AreEqual(coll.ToString(), "[1, 2, 3, 4, 5]");

            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(initialCapacity));
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);
            int newItem = 6;

            Assert.Throws<ArgumentOutOfRangeException>(() => coll.InsertAt(10, newItem));
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);

            coll.Exchange(2, 3);

            Assert.AreEqual(coll.ToString(), "[1, 2, 4, 3, 5]");
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);

            coll.Exchange(0, 4);

            Assert.AreEqual(coll.ToString(), "[5, 2, 3, 4, 1]");
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);

            coll.RemoveAt(0);

            Assert.AreEqual(coll.ToString(), "[2, 3, 4, 5]");
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);

            coll.RemoveAt(coll.Count - 1);

            Assert.AreEqual(coll.ToString(), "[1, 2, 3, 4]");
        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);

            coll.RemoveAt((coll.Count - 1) / 2);

            Assert.AreEqual(coll.ToString(), "[1, 2, 4, 5]");
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5);

            coll.Clear();

            Assert.AreEqual(coll.ToString(), "[]");

        }
    }
}