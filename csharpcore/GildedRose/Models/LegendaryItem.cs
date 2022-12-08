namespace GildedRoseKata.Models
{
    public class LegendaryItem : Item
    {
        public LegendaryItem() { }

        public LegendaryItem(string name)
        {
            Name = name;
            Quality = 80;
        }
    }
}
