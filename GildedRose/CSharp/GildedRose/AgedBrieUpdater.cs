namespace GildedRoseKata;

internal class AgedBrieUpdater: BaseItemUpdater, IItemUpdater
{
    public void Update(Item item)
    {
        IncreaseQuality(item);
        DecreaseSellIn(item);
        
        if (IsExpired(item))
        {
            IncreaseQuality(item);
        }
    }
    
}