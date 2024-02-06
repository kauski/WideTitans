using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://medium.com/codex/making-a-rts-game-3-setting-up-in-game-resources-unity-c-92355714b2d7

public class ShopData
{
    private string _code;
    private int _healthpoints;
    private Dictionary<string, int> _cost;

    public ShopData(string code, int healthpoints, Dictionary<string, int> cost)
    {
        _code = code;
        _healthpoints = healthpoints;
        _cost = cost;
    }

    public bool CanBuy()
    {
        foreach (KeyValuePair<string, int> pair in _cost)
        {
            if (GlobalRes.GAME_RESOURCES[pair.Key].Amount < pair.Value)
            {
                return false;
            }
        }
        return true;
    }

    public string Code { get => _code; }
    public int HP { get => _healthpoints; }
    public Dictionary<string, int> Cost { get => _cost; }
}