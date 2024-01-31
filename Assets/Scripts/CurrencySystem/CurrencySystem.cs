using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencySystem : MonoBehaviour
{
    public TMP_Text textCurrency;
    public int defaultCurrency;
    private int _currency;
    public static CurrencySystem instance;

    private void Awake()
    {
        Init();
        instance = this;
    }

    public void Init()
    {
        _currency = defaultCurrency;
        UpdateUI();
    }
    public void Gain(int val)
    {
        _currency += val;
        UpdateUI();
    }
    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            _currency -= val;
            UpdateUI();
            return true;
        }
        return false;
    }
    public bool EnoughCurrency(int val)
    {
        if (val <= _currency)
            return true;
        else
            return false;
    }
    void UpdateUI()
    {
        textCurrency.text = _currency.ToString();
    }
}
