using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://medium.com/codex/making-a-rts-game-2-adding-a-very-basic-ui-unity-c-8420480afda0
// https://medium.com/codex/making-a-rts-game-3-setting-up-in-game-resources-unity-c-92355714b2d7

public class UIManager : MonoBehaviour
{
    //public Transform resourceMenu;
    //public GameObject resourceButtonPrefab;
    public Transform resourcesUIParent;
    public GameObject gameResourcesDisplayPrefab;

    private Dictionary<string, Text> _resourceTexts;
    private Dictionary<string, Button> _resourceButtons;

    private void Awake()
    {
        _resourceTexts = new Dictionary<string, Text>();
        foreach (KeyValuePair<string, GameResources> pair in GlobalRes.GAME_RESOURCES)
        {
            GameObject display = Instantiate(gameResourcesDisplayPrefab, resourcesUIParent);
            display.name = pair.Key;
            _resourceTexts[pair.Key] = display.transform.Find("Text").GetComponent<Text>();
            _SetResourceText(pair.Key, pair.Value.Amount);
        }
        /*
        _resourceButtons = new Dictionary<string, Button>();
        for (int i = 0; i < GlobalRes.SHOP_DATA.Length; i++)
        {
            // ...
            _resourceButtons[code] = b;
            if (!GlobalRes.SHOP_DATA[i].CanBuy())
            {
                b.interactable = false;
            }
        }
        */
    }

    private void _SetResourceText(string resource, int value)
    {
        _resourceTexts[resource].text = value.ToString();
    }

    public void UpdateResourceTexts()
    {
        foreach (KeyValuePair<string, GameResources> pair in GlobalRes.GAME_RESOURCES)
        {
            _SetResourceText(pair.Key, pair.Value.Amount);
        }
    }
    /*
    public void CheckBuildingButtons()
    {
        foreach (ShopData data in GlobalRes.SHOP_DATA)
        {
            _resourceButtons[data.Code].interactable = data.CanBuy();
        }
    }
    */
}
