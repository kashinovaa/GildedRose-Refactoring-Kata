using GildedRoseKata.Contracts;

namespace GildedRoseKata.Models
{
    public class AgingItem : Item, IUpdatable
    {
        public AgingItem() { }

        public AgingItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        } 

        public void UpdateQuality()
        {
            if (Quality > 0)
                Quality--;

            SellIn--;

            if ((SellIn < 0) && (Quality > 0))
                Quality--;
        }
    }
}
