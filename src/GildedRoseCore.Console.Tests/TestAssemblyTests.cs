using System;
using Xunit;
using System.Collections.Generic;
using ConsoleApplication;
using FluentAssertions;

namespace Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);

        }

        [Theory]
        [InlineData("Sulfuras, Hand of Ragnaros", 10, 10)]
        [InlineData("Random item name", 10, 9)]
        public void Given_item_When_Call_To_UpdateQuality_Then_Prop_SellIn_Equal(string item, int sellin, int expected)
        {
            var dummy_item = new Item
            {
                Name = item,
                SellIn = sellin,
                Quality = 10
            };

            var program = new Program();
            program.Items = new List<Item> { dummy_item };

            program.UpdateQuality();

            dummy_item.SellIn.Should().Be(expected);
        }


        [Fact]
        public void Given_item_When_Quality_Is_Greatest_Than_0_And_Is_A_Degradabled_Item_Then_Quality_Is_Degraded()
        {
            var dummyItem = new Item
            {
                Name = "Random item name",
                SellIn = 10,
                Quality = 10
            };
            var expectedQuality = 9;

            var program = new Program();
            program.Items = new List<Item> { dummyItem };

            program.UpdateQuality();

            dummyItem.Quality.Should().Be(expectedQuality);
        }



        [Theory]
        [InlineData("Aged Brie")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert")]
        [InlineData("Sulfuras, Hand of Ragnaros")]
        public void Given_item_When_Quality_Is_Greatest_Than_0_And_Is_A_Not_Degradabled_Item_Then_Quality_Is_Degraded(string itemName)
        {
            var dummyItem = new Item
            {
                Name = itemName,
                SellIn = 20,
                Quality = 50
            };
            var expectedQuality = 50;

            var program = new Program();
            program.Items = new List<Item> { dummyItem };

            program.UpdateQuality();

            dummyItem.Quality.Should().Be(expectedQuality);
        }



        [Fact]
        public void Given_An_AgedBrie_Item_When_SellIn_Is_Negative_And_Quality_Is_Less_Than_50_Then_Quality_Is_Increased_Twice()
        {
            var dummyItem = new Item
            {
                Name = "Aged Brie",
                SellIn = -1,
                Quality = 0
            };
            var expectedQuality = 2;

            var program = new Program();
            program.Items = new List<Item> { dummyItem };

            program.UpdateQuality();

            dummyItem.Quality.Should().Be(expectedQuality);
        }



        [Fact]
        public void Given_An_AgedBrie_Item_When_SellIn_Is_Not_Negative_And_Quality_Is_Less_Than_50_Then_Quality_Is_Increased()
        {
            var dummyItem = new Item
            {
                Name = "Aged Brie",
                SellIn = 10,
                Quality = 0
            };
            var expectedQuality = 1;

            var program = new Program();
            program.Items = new List<Item> { dummyItem };

            program.UpdateQuality();

            dummyItem.Quality.Should().Be(expectedQuality);
        }


        [Fact]
        public void Given_An_Backstage_Item_When_SellIn_Is_Negative_Then_Quality_Is_Reduced_To_0()
        {
            var dummyItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 0
            };
            var expectedQuality = 0;

            var program = new Program();
            program.Items = new List<Item> { dummyItem };

            program.UpdateQuality();

            dummyItem.Quality.Should().Be(expectedQuality);
        }



        [Fact]
        public void Given_An_Backstage_Item_When_Quality_Is_Less_Than_50_And_SellIn_Is_Less_Than_11_And_Positive_Then_Quality_Is_Increased()
        {
            var dummyItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 30
            };
            var expectedQuality = 32;

            var program = new Program();
            program.Items = new List<Item> { dummyItem };

            program.UpdateQuality();

            dummyItem.Quality.Should().Be(expectedQuality);
        }


        [Fact]
        public void Given_An_Backstage_Item_When_Quality_Is_Less_Than_50_And_SellIn_Is_Less_Than_6_And_Positive_Then_Quality_Is_Increased()
        {
            var dummyItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 30
            };
            var expectedQuality = 33;

            var program = new Program();
            program.Items = new List<Item> { dummyItem };

            program.UpdateQuality();

            dummyItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void Given_An_Item_When_Quality_Is_More_Than_0_And_SellIn_Is_Less_Than_0_Then_Quality_Is_Decreased_Twice()
        {
            var dummyItem = new Item
            {
                Name = "Random Item name",
                SellIn = -1,
                Quality = 30
            };
            var expectedQuality = 28;

            var program = new Program();
            program.Items = new List<Item> { dummyItem };

            program.UpdateQuality();

            dummyItem.Quality.Should().Be(expectedQuality);
        }
    }
}
