using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://medium.com/codex/making-a-rts-game-3-setting-up-in-game-resources-unity-c-92355714b2d7

public class GlobalRes
{

    // ...

    public static Dictionary<string, GameResources> GAME_RESOURCES =
        new Dictionary<string, GameResources>()
    {
        { "gold", new GameResources("Gold", 0) },
        { "food", new GameResources("Food", 0) },
        { "wood", new GameResources("Wood", 0) },
        { "cloth", new GameResources("Cloth", 0) },
    };

    /*
    public static ShopData[] SHOP_DATA = new ShopData[]
    {
        new ShopData("House", 100, new Dictionary<string, int>()
        {
            { "gold", 100 },
            { "wood", 120 }
        }),
        new ShopData("Tower", 100, new Dictionary<string, int>()
        {
            { "gold", 80 },
            { "wood", 80 },
            { "stone", 100 }
        })
    };
    */
}
