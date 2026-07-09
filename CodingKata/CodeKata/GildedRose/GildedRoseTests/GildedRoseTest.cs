using Xunit;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private const string NonspecialItemName = "foo";
    private const string AgedBrieItemName = "Aged Brie";
    private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
    private const string BackstagePassItemName = "Backstage passes to a TAFKAL80ETC concert";
    
    [Fact]
    public void UpdateQuality_NonSpecialItemBeforeSellDate_ShouldDecreaseQuality()
    {
        // Given a non-special item that has not expired
        var actualItem = CreateItem (NonspecialItemName, 20, 10);
        var app = CreateGildedRose(actualItem);
        
        // When the quality are updated
        app.UpdateQuality();
        
        // Then the quality should decrease by 1.
        Assert.Equal(19, actualItem.Quality);
    }
    
    [Fact]
    public void UpdateQuality_NonSpecialItemBeforeSellDate_ShouldDecreaseSellIn()
    {
        // Given a non-special item that has not expired
        var actualItem = CreateItem (NonspecialItemName, 20, 10);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality should decrease by 1.
        Assert.Equal(9, actualItem.SellIn);
    }

    [Fact]
    public void UpdateQuality_ExpiredNonSpecialItem_ShouldDecreaseQualityByTwo()
    {
        // Given a non-special item that has expired
        var actualItem = CreateItem(NonspecialItemName, 20, -1);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality will decrease by 2.
        Assert.Equal(18, actualItem.Quality);
    }
  
    [Fact]
    public void UpdateQuality_NonSpecialItemWithZeroQuality_ShouldNotDropBelowZero()
    {
        // Given a non-special item with zero quality
        var actualItem = CreateItem(NonspecialItemName, 0, 10);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality does not drop below zero
        Assert.Equal(0, actualItem.Quality);
    }
    
    [Fact]
    public void UpdateQuality_AgedBrieItemBeforeSellDate_ShouldIncreaseQualityByOne()
    {
        // Given aged brie that has not expired
        var actualItem = CreateItem(AgedBrieItemName, 20, 10);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality increase by 1.
        Assert.Equal(21, actualItem.Quality);
    }
    
    [Fact]
    public void UpdateQuality_ExpiredAgedBrieItem_ShouldIncreaseQualityByTwo()
    {
        // Given aged brie that has expired
        var actualItem = CreateItem(AgedBrieItemName, 20, -1);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality increases by 2.
        Assert.Equal(22, actualItem.Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrieItemWithMaxQuality_ShouldNotIncreaseQuality()
    {
        // Given aged brie with the maximum quality
        var actualItem = CreateItem(AgedBrieItemName, 50, 10);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality does not increase beyond the maximum.
        Assert.Equal(50, actualItem.Quality);
    }
    
    [Fact]
    public void UpdateQuality_SulfurasItem_ShouldNotChangeQuality()
    {
        // Given Sulfuras
        var actualItem = CreateItem(SulfurasItemName, 20, 10);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality does not change.
        Assert.Equal(20, actualItem.Quality);
    }
        
    [Fact]
    public void UpdateQuality_SulfurasItem_ShouldNotChangeSellIn()
    {
        // Given Sulfuras
        var actualItem = CreateItem(SulfurasItemName, 20, 10);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the sell-in does not change.
        Assert.Equal(10, actualItem.SellIn);
    }
    
    [Fact]
    public void UpdateQuality_BackstagePassesItemMoreThanTenDays_ShouldIncreaseQualityByOne()
    {
        // Given Backstage Passes with more than 10 days before the event
        var actualItem = CreateItem(BackstagePassItemName, 20, 12);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality increases by 1.
        Assert.Equal(21, actualItem.Quality);
    }
    
    [Fact]
    public void UpdateQuality_BackstagePassesTenDaysOrLess_ShouldIncreaseQualityBy2()
    {
        // Given Backstage Passes between 6-10 days before the event
        var actualItem = CreateItem(BackstagePassItemName, 20, 10);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality increases by 2.
        Assert.Equal(22, actualItem.Quality);
    }
    
    [Fact]
    public void UpdateQuality_BackstagePassesFiveDaysOrLess_ShouldIncreaseQualityBy3()
    {
        // Given Backstage Passes has less than 5 days before the event
        var actualItem = CreateItem(BackstagePassItemName, 20, 5);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality increases by 3.
        Assert.Equal(23, actualItem.Quality);
    }
    
    [Fact]
    public void UpdateQuality_BackstagePassesAfterEvent_ShouldZeroOutQuality()
    {
        // Given Backstage Passes that have expired (the event has passed)
        var actualItem = CreateItem(BackstagePassItemName, 20, 0);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality reduces to 0.
        Assert.Equal(0, actualItem.Quality);
    }
    
    [Fact]
    public void UpdateQuality_BackstagePassWithMaxQuality_ShouldNotIncreaseQuality()
    {
        // Given Backstage Passes with maximum quality
        var actualItem = CreateItem(BackstagePassItemName, 50, 10);
        var app = CreateGildedRose(actualItem);
        
        // When the quality is updated
        app.UpdateQuality();
        
        // Then the quality should not increase past the maximum.
        Assert.Equal(50, actualItem.Quality);
    }

    private static Item CreateItem(string name, int quality, int sellIn)
    {
        // ReSharper disable once HeapView.ObjectAllocation.Evident
        return new Item
        {
            Name = name,
            Quality = quality,
            SellIn = sellIn
        };
    }

    private static GildedRose CreateGildedRose(Item actualItem)
    {
        // ReSharper disable once HeapView.ObjectAllocation.Evident
        return new GildedRose([actualItem]);
    }
}