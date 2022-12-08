using GildedRoseKata.Contracts;

namespace GildedRoseKata.Models
{
    public class UniqueItem : Item, IUpdatable
    {
        public UniqueItem() { }

        public UniqueItem(string name, int sellIn, int quality) 
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            if (Quality < 50)
                Quality++;

            if ((SellIn < 11) && (Quality < 50))
                Quality++;

            if ((SellIn < 6) && (Quality < 50))
                Quality++;

            SellIn--;

            if (SellIn < 0)
                Quality = 0;
        }
    }
}
