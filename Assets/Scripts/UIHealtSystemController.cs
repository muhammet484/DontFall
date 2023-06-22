using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealtSystemController : MonoBehaviour
{
    [SerializeField] GameObject[] Hearts;

    List<GameObject> ActiveHearts = new List<GameObject>();

    [SerializeField] UIButtonsHandler buttonsHandler;
    //Test purpose
    [EButton]
    void IncreaseHealth()
    {
        GameManager.Instance.IncreasePlayerHealthCount(1);
    }
    [EButton]
    void DecreaseHealth()
    {
        GameManager.Instance.PlayerDied();
    }
    // Start is called before the first frame update
    void Start()
    {
        buttonsHandler.OnStartButtonClickAction += () =>
        {
            for (int i = 0; i < GameManager.Instance.GetPlayerHealthCount(); i++)
            {
                Hearts[i].SetActive(true);
            }
            foreach (var obj in Hearts)
                if (obj.activeInHierarchy)
                    ActiveHearts.Add(obj);
        };
        GameManager.Instance.AddOnPlayerHealthIncrease(() =>
        {
            var obj = Hearts[ActiveHearts.Count];
            obj.SetActive(true);
            ActiveHearts.Add(obj);
        });

        GameManager.Instance.AddOnPlayerDie(() =>
        {
            ActiveHearts[ActiveHearts.Count - 1].SetActive(false);
            ActiveHearts.RemoveAt(ActiveHearts.Count - 1);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
