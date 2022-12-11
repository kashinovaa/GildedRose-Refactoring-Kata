using GildedRoseKata.Models;
using NUnit.Framework;
using System.Collections.Generic;

using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseKataTests
{
    public class GildedRoseTests
    {
        GildedRose _gildedRose;
        IList<Item> _items = new List<Item>();

        [TearDown]
        public void TearDown()
        {
            _items.Clear();
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 0)]
        [TestCase(0, 50, 48)]
        [TestCase(0, 100, 98)]
        [TestCase(1, 100, 99)]
        [TestCase(-1, 100, 98)]
        public void TestUpdateQuality_WhenAgingItem_ThenShouldUpdateQualityCorrectly(int sellIn, int quality, int expectedQuality)
        {
            _items.Add( new AgingItem { SellIn = sellIn, Quality = quality } );
            _gildedRose = new GildedRose(_items);
            
            _gildedRose.UpdateQuality();

            _items[0].Should().BeEquivalentTo(new Item { SellIn = sellIn - 1, Quality = expectedQuality });             
        }

        [TestCase(0, 0, 2)]
        [TestCase(0, 1, 3)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 50, 50)]
        [TestCase(1, 100, 100)]
        [TestCase(-1, 40, 42)]
        public void TestUpdateQuality_WhenGrowingItem_ThenShouldUpdateQualityCorrectly(int sellIn, int quality, int expectedQuality)
        {
            var name = "Aged Brie";
            _items.Add(new GrowingItem { Name = name, SellIn = sellIn, Quality = quality });
            _gildedRose = new GildedRose(_items);

            _gildedRose.UpdateQuality();

            _items[0].Should().BeEquivalentTo(new Item { Name = name, SellIn = sellIn - 1, Quality = expectedQuality });
        }

        [TestCase(-1, 80)]
        [TestCase(0, 80)]
        [TestCase(1, 80)]
        public void TestUpdateQuality_WhenLegendaryItem_ThenShouldUpdateNothing(int sellIn, int quality)
        {
            var name = "Sulfuras, Hand of Ragnaros";
            _items.Add(new LegendaryItem { Name = name, SellIn = sellIn, Quality = quality });
            _gildedRose = new GildedRose(_items);

            _gildedRose.UpdateQuality();

            _items[0].Should().BeEquivalentTo(new Item { Name = name, SellIn = sellIn, Quality = quality });
        }

        [TestCase(15, 20, 21)]
        [TestCase(10, 48, 50)]
        [TestCase(10, 49, 50)]
        [TestCase(10, 50, 50)]
        [TestCase(5, 40, 43)]
        [TestCase(0, 40, 0)]
        [TestCase(-1, 40, 0)]
        public void TestUpdateQuality_WhenUniqueItem_ThenShouldUpdateQualityCorrectly(int sellIn, int quality, int expectedQuality)
        {
            var name = "Backstage passes to a TAFKAL80ETC concert";
            _items.Add(new UniqueItem { Name = name, SellIn = sellIn, Quality = quality });
            _gildedRose = new GildedRose(_items);

            _gildedRose.UpdateQuality();

            _items[0].Should().BeEquivalentTo(new Item { Name = name, SellIn = sellIn - 1, Quality = expectedQuality });
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 0)]
        [TestCase(0, 50, 46)]
        [TestCase(0, 100, 96)]
        [TestCase(1, 100, 98)]
        [TestCase(-1, 100, 96)]
        public void TestUpdateQuality_WhenConjuredItem_ThenShouldUpdateQualityCorrectly(int sellIn, int quality, int expectedQuality)
        {
            var name = "Conjured Mana Cake";
            _items.Add(new ConjuredItem { Name = name, SellIn = sellIn, Quality = quality });
            _gildedRose = new GildedRose(_items);

            _gildedRose.UpdateQuality();

            _items[0].Should().BeEquivalentTo(new Item { Name = name, SellIn = sellIn - 1, Quality = expectedQuality });
        }

        [TestCase(5, 100, 95)]
        [TestCase(-5, 0, -4)]
        public void TestUpdateQuality_WhenConjuredItem_ThenShouldReturnInvalidItem(int sellIn, int quality, int expectedQuality)
        {
            var name = "Conjured Mana Cake";
            _items.Add(new ConjuredItem { Name = name, SellIn = sellIn, Quality = quality });
            _gildedRose = new GildedRose(_items);

            _gildedRose.UpdateQuality();

            _items[0].Should().NotBeEquivalentTo(new Item { Name = name, SellIn = sellIn - 1, Quality = expectedQuality });
        }

        //todo: add more failing tests
    }
}
