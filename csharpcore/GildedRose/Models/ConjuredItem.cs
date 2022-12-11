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
            if (Quality > 0)
                DecreaseQuality();
                
            SellIn--;

            if ((SellIn < 0) && (Quality > 0))
                DecreaseQuality();
        }

        private void DecreaseQuality()
        {
            if (Quality > 1)
                Quality -= 2;
            else
                Quality--;
        }
    }
}
