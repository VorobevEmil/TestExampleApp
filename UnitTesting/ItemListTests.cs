using TestExampleApp;

namespace UnitTesting
{
    public class ItemListTests
    {

        [Fact]
        public void Add_ItemToList()
        {
            // arrange
            var itemList = new ItemList<int>();

            // act
            itemList.Add(123);

            // assert
            var savedItem = Assert.Single(itemList.All);
            Assert.Equal(123, savedItem);
            Assert.Equal(itemList[1], savedItem);
        }

        [Fact]
        public void ItemListIncrementsItemsEverTimeWeAdd()
        {
            // arrange
            var itemList = new ItemList<string>();

            // act
            itemList.Add("Test 1");
            itemList.Add("Test 2");
            itemList.Add("Test 3");

            // assert
            Assert.Equal(3, itemList.Count);
        }

        [Fact]
        public void Remove_ItemFromList()
        {
            // arrange
            var itemList = new ItemList<string>();

            // act
            itemList.Add("Test 1");
            itemList.Add("Test 2");
            itemList.Add("Test 3");

            itemList.Remove("Test 1");
            itemList.Remove("Test 2");

            // assert
            var savedItem = Assert.Single(itemList.All);
            Assert.Equal("Test 3", savedItem);
        }

        [Fact]
        public void Throws_WhenRemoveItemNotFound()
        {
            // arrange
            var itemList = new ItemList<string>();

            // act
            itemList.Add("Test 1");
            itemList.Add("Test 2");

            // assert
            Assert.Throws<InvalidOperationException>(() => itemList.Remove("Test333"));
        }

        [Fact]
        public void Remove_ItemFromListById()
        {
            // arrange
            var itemList = new ItemList<string>();

            // act
            itemList.Add("Test 1");
            itemList.Add("Test 2");
            itemList.Add("Test 3");

            itemList.RemoveById(1);
            itemList.RemoveById(3);

            // assert
            var savedItem = Assert.Single(itemList.All);
            Assert.Equal("Test 2", savedItem);
        }

        [Fact]
        public void Throws_WhenRemoveItemNotFoundById()
        {
            // arrange
            var itemList = new ItemList<string>();

            // act
            itemList.Add("Test 1");
            itemList.Add("Test 2");

            // assert
            Assert.Throws<InvalidOperationException>(() => itemList.RemoveById(4));
        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(5, 6, 4)]
        [InlineData(15, 29, 20)]
        public void CheckWhetherSumAllItemsIsMultiple(int item1, int item2, int item3)
        {
            // arrange
            var itemList = new ItemList<int>();

            // act
            for (int i = 0; i < 30; i++)
            {
                itemList.Add(i);
            }
            // assert
            Assert.True(itemList.ContainValue(item1));
            Assert.True(itemList.ContainValue(item2));
            Assert.True(itemList.ContainValue(item3));
        }


        [Theory]
        [MemberData(nameof(Data))]
        public void CheckCountIndex<T>(List<T> values)
        {
            ItemList<T> itemList = new ItemList<T>();
            foreach (var value in values)
            {
                itemList.Add(value);
            }

            var allIndexes = itemList.GetAllIndex();
            Assert.Equal(allIndexes.Count, values.Count);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<int>() { 52, 35, 12, 3 } };
            yield return new object[] { new List<string>() { "Test", "Test", "Test", "Test", "Test", "Test"} };
            yield return new object[] { new List<double>() };
        }
    }
}
