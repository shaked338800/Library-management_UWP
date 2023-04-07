using System;

namespace Models.Enums
{
    [Flags]
    public enum CategoriesB
    {
        None = 1,
        Adventure = 2,
        Action = 4,
        Classics = 8,
        Fantasy = 16,
        Horror = 32,
        Comics = 64,
        Comedy = 128,
        ScienceFiction = 256,
        Detective = 512,
        Mystery = 1024,
        HistoricalFiction = 2048
    };
    [Flags]
    public enum CategoriesJ
    {
        None = 1,
        CookingBook = 2,
        Comics = 4,
        Poetry = 8,
        NewsPaper = 16,
        TravelGuildes = 32
    };
}
