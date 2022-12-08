using GildedRoseKata.Contracts;

namespace GildedRoseKata.Models
{
    public class ConjuredItem : Item, IUpdatable
    {
        public ConjuredItem() { }

        public ConjuredItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            
        }
    }
}
