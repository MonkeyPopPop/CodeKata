﻿using System.Collections.Generic;

 namespace GildedRoseKata;

public class GildedRose
{
    private IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            UpdateItem(item);
        }
    }

    private static void UpdateItem(Item item)
    {
        var itemUpdater = UpdaterFactory.CreateUpdater(item);
        
        itemUpdater.Update(item);
    }
}