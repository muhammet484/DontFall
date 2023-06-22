using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableObjectsUIHandler : MonoBehaviour
{
    [SerializeField] Text TwiceJumpText;
    [SerializeField] GameObject LooseMenu;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.PlayerInventory.AddOnTwiceJumpAmountChanced(() =>
        {
            TwiceJumpText.text = GameManager.Instance.PlayerInventory.TwiceJumpAmount.ToString();
        });

        GameManager.Instance.AddOnPlayerLoose(() =>
        {
            LooseMenu.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
