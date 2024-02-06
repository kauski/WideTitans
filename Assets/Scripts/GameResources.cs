using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://medium.com/codex/making-a-rts-game-3-setting-up-in-game-resources-unity-c-92355714b2d7

public class GameResources
{
    private string _name;
    private int _currentAmount;

    public GameResources(string name, int initialAmount)
    {
        _name = name;
        _currentAmount = initialAmount;
    }

    public void AddAmount(int value)
    {
        _currentAmount += value;
        if (_currentAmount < 0) _currentAmount = 0;
    }

    public string Name { get => _name; }
    public int Amount { get => _currentAmount; }

    /*
    public void Place()
    {
        // ...

        // update game resources: remove the cost of the building
        // from each game resource
        foreach (KeyValuePair<string, int> pair in _data.Cost)
        {
            GlobalRes.GAME_RESOURCES[pair.Key].AddAmount(-pair.Value);
        }
    }

    public bool CanBuy()
    {
        return _data.CanBuy();
    }
    */
}
