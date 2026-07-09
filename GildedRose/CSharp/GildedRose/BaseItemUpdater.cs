namespace GildedRoseKata;

public abstract class BaseItemUpdater
{
    private const int QualityUpperBounds = 50;
    private const int QualityLowerBounds = 0;
    protected static bool IsExpired(Item item) => item.SellIn < 0;
    
    protected static void IncreaseQuality(Item item)
    {
        if (item.Quality < QualityUpperBounds)
        {
            item.Quality++;
        }
    }
    protected static void DecreaseQuality(Item item)
    {
        if (item.Quality > QualityLowerBounds)
        {
            item.Quality--;
        }
    }
    
    protected static void ZeroOutQuality(Item item)
    {
        item.Quality = 0;
    }
    
    protected static void DecreaseSellIn(Item item)
    {
        item.SellIn--;
    }
}