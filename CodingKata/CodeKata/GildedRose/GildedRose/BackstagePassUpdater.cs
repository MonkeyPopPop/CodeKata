namespace GildedRoseKata;

internal class BackstagePassUpdater: BaseItemUpdater, IItemUpdater
{
    public void Update(Item item)
    {
        IncreaseQuality(item);

        if (item.SellIn < 11)
        {
            IncreaseQuality(item);
        }

        if (item.SellIn < 6)
        {
            IncreaseQuality(item);
        }
        
        DecreaseSellIn(item);
        
        if (IsExpired(item))
        {
            ZeroOutQuality(item);
        }
    }
}