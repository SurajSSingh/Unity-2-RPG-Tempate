using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopKeeper : MonoBehaviour
{
    public GameObject popupText;
    public Item.ItemType type;

    public PlayerManager pm;

    private bool inShopZone = false;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && inShopZone)
        {
            int totalAmount = pm.SellAll(type);
            popupText.GetComponent<TextMeshProUGUI>().text = $"Sold all {type.ToString()} items and made {totalAmount}.";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        popupText.SetActive(true);
        inShopZone = true;
        popupText.GetComponent<TextMeshProUGUI>().text = $"Press [R] to sell all {type.ToString()} items.";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inShopZone = false;
        popupText.SetActive(false);
    }
}
