namespace GildedRoseKata.Models
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; } //the number of days we have to sell the item

        public int Quality { get; set; } //how valuable the item is
    }
}
