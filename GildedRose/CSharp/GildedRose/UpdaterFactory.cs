namespace GildedRoseKata;

public static class UpdaterFactory
{
    private const string AgedBrieName = "Aged Brie";
    private const string SulfurasName = "Sulfuras, Hand of Ragnaros";
    private const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
    
    public static IItemUpdater CreateUpdater(Item item)
    {
        IItemUpdater itemUpdater = item.Name switch
        {
            SulfurasName => new SulfurasUpdater(),
            AgedBrieName => new AgedBrieUpdater(),
            BackstagePassName => new BackstagePassUpdater(),
            _ => new NormalItemUpdater()
        };

        return itemUpdater;
    }
}