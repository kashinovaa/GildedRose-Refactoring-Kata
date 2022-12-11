using GildedRoseKata.Contracts;
using GildedRoseKata.Models;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item is IUpdatable updatableItem)
                    updatableItem.UpdateQuality();
            }
        }
    }
}
