using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Main : MonoBehaviour
{
    public static double money;
    public static double total_money;
    public double trade_money;
    public double spent_money;
    public double spent_money_all;

    public static int planet_id;
    public static int planet_level;

    public static int scene_setting;

    double money_text_value;
    Text text;

    private void Start()
    {
        LoadMoney();
    }
    public void ToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void LoadMoney()
    {
        money = PlayerPrefs.GetFloat("money", 0.0f);
        total_money = PlayerPrefs.GetFloat("total_money", 0.0f);
        trade_money = PlayerPrefs.GetFloat("trade_money", 0.0f);
        spent_money = PlayerPrefs.GetFloat("spent_money", 0.0f);
        spent_money_all = PlayerPrefs.GetFloat("spent_money_all", 0.0f);

        planet_level = PlayerPrefs.GetInt("planet_level");
    }
    public void SetMoney()
    {
        PlayerPrefs.SetFloat("money", (float)money);
        PlayerPrefs.SetFloat("total_money", (float)total_money);
        PlayerPrefs.SetFloat("trade_money", (float)total_money);
        PlayerPrefs.SetFloat("spent_money", (float)total_money);
        PlayerPrefs.SetFloat("spent_money_all", (float)total_money);
        text = GameObject.FindWithTag("money_text").GetComponent<Text>();
        if (text != null)
        {
            money_text_value = money;
            if (money_text_value > 1000)
            {
                text.text = string.Format("{0:F3} T", money_text_value/1000.00);
            }
            else
            {
                text.text = string.Format("{0:F3}", money);
            }
           
        }
    }
    IEnumerator Farm()
    {
        yield return new WaitForSeconds(1);
        if (GlobalShop.globalState != null)
        {
            if (GlobalShop.globalState[2])
            {
                money += 0.001;
                trade_money += 0.001;
                total_money += 0.001;
            }
            if (GlobalShop.globalState[5])
            {
                money += 0.002;
                trade_money += 0.002;
                total_money += 0.002;
            }
            if (GlobalShop.globalState[8])
            {
                money += 0.004;
                trade_money += 0.004;
                total_money += 0.004;
            }
            if (GlobalShop.globalState[11])
            {
                money += 0.006;
                trade_money += 0.006;
                total_money += 0.006;
            }
        }
    }
    void Update()
    {
        
        StartCoroutine(Farm());
        SetMoney();
    }
}
