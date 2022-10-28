using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int _moneyCount = 1000;

    public Text moneyText;
    public int MoneyCount => _moneyCount;

    private void Start()
    {
    }

    private void Update()
    {
        moneyText.text = _moneyCount.ToString();
    }

    public bool MoneyDeplete(int amount)
    {
        if(_moneyCount - amount < 0)
        {
            return false;
        }

        _moneyCount -= amount;
        return true;
    }

    public void MoneyAdd(int amount)
    {
        _moneyCount += amount;
    }
    
}
