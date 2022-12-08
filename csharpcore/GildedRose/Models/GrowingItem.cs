using GildedRoseKata.Contracts;

namespace GildedRoseKata.Models
{
    public class GrowingItem : Item, IUpdatable
    {
        public GrowingItem() { }

        public GrowingItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            if (Quality < 50)
                Quality++;

            SellIn--;

            if ((SellIn < 0) && (Quality < 50))
                Quality++;
        }
    }
}
