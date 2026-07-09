namespace GildedRoseKata;

internal class NormalItemUpdater : BaseItemUpdater, IItemUpdater
{
    public void Update(Item item)
    {
        DecreaseQuality(item);
        DecreaseSellIn(item);
                
        if (IsExpired(item))
        {
            DecreaseQuality(item);
        }
    }
}