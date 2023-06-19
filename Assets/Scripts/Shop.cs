using System;
using UnityEngine;
using UnityEngine.UI;

public class Shop : Main
{
    public Button button_infrastrukture;
    public Button button_technology;
    public Button button_ecology;
    public Button button_culture;

    public Text text_infrastrukture;
    public Text text_technology;
    public Text text_ecology;
    public Text text_culture;

    int revenue_base = 1;

    int cost_base_i = 10;
    int cost_base_t = 8;
    int cost_base_e = 6;
    int cost_base_c = 4;

    double cost_factor = 1.07;
    double revenue_factor = 0.5;

    double infrastrukture_factor;
    double technology_factor;
    double ecology_factor;
    double culture_factor;

    public static double revenue;

    double cost_infrastrukture;
    int count_infrastrukture;

    double cost_technology;
    int count_technology;

    double cost_ecology;
    int count_ecology;

    double cost_culture;
    int count_culture;

    void Start()
    {
        scene_setting = 2;
        button_infrastrukture.onClick.AddListener(Click_button_infrastrukture);
        button_technology.onClick.AddListener(Click_button_technology);
        button_ecology.onClick.AddListener(Click_button_ecology);
        button_culture.onClick.AddListener(Click_button_culture);
        LoadDateShop();
    }

    private void Click_button_infrastrukture()
    {
        if (cost_infrastrukture <= money)
        {
            money -= cost_infrastrukture;
            spent_money += cost_infrastrukture;
            count_infrastrukture += 1;
            PlayerPrefs.SetInt("count_infrastrukture_" + planet_id, count_infrastrukture);
            cost_infrastrukture = cost_base_i * Math.Pow(cost_factor, count_infrastrukture);
            
        }
    }
    private void Click_button_technology()
    {
        if (cost_technology <= money)
        {
            money -= cost_technology;
            spent_money += cost_technology;
            count_technology += 1;
            PlayerPrefs.SetInt("count_technology_" + planet_id, count_technology);
            cost_technology = cost_base_t * Math.Pow(cost_factor, count_technology);
        }
    }
    private void Click_button_ecology()
    {
        if (cost_ecology <= money)
        {
            money -= cost_ecology;
            spent_money += cost_ecology;
            count_ecology += 1;
            PlayerPrefs.SetInt("count_ecology_" + planet_id, count_ecology);
            cost_ecology = cost_base_e * Math.Pow(cost_factor, count_ecology);
        }
    }
    private void Click_button_culture()
    {
        if (cost_culture <= money)
        {
            money -= cost_culture;
            spent_money += cost_culture;
            count_culture += 1;
            PlayerPrefs.SetInt("count_culture_" + planet_id, count_culture);
            cost_culture = cost_base_c * Math.Pow(cost_factor, count_culture);
        }
    }

    private void LoadDateShop()
    {
        count_infrastrukture = PlayerPrefs.GetInt("count_infrastrukture_" + planet_id);
        count_technology = PlayerPrefs.GetInt("count_technology_" + planet_id);
        count_ecology = PlayerPrefs.GetInt("count_ecology_" + planet_id);
        count_culture = PlayerPrefs.GetInt("count_culture_" + planet_id);

        cost_infrastrukture = cost_base_i * Math.Pow(cost_factor, count_infrastrukture);
        cost_technology = cost_base_t * Math.Pow(cost_factor, count_technology);
        cost_ecology = cost_base_e * Math.Pow(cost_factor, count_ecology);
        cost_culture = cost_base_c * Math.Pow(cost_factor, count_culture);

        switch (planet_id)
        {
            case 0:
                infrastrukture_factor = 1;
                technology_factor = 0.8;
                ecology_factor = 0.6;
                culture_factor = 0.4;
                break;
            case 1:
                infrastrukture_factor = 0.8;
                technology_factor = 1;
                ecology_factor = 0.2;
                culture_factor = 0.6;
                break;
            case 2:
                infrastrukture_factor = 0.8;
                technology_factor = 0.8;
                ecology_factor = 1;
                culture_factor = 0.6;
                break;
            case 3:
                infrastrukture_factor = 0.8;
                technology_factor = 0.8;
                ecology_factor = 0.6;
                culture_factor = 1;
                break;
            case 4:
                infrastrukture_factor = 1;
                technology_factor = 1;
                ecology_factor = 1;
                culture_factor = 1;
                break;
        }
    }
    public void CalculateRevenue()
    {
        revenue = revenue_base + (count_infrastrukture*infrastrukture_factor + count_technology*technology_factor + count_ecology*ecology_factor + count_culture*culture_factor)/100.0 * revenue_factor;
        PlayerPrefs.SetFloat("revenue", (float)revenue);
    }
    void Update()
    {
        text_infrastrukture.text = string.Format("{0:F4}   :  X{1}", cost_infrastrukture, count_infrastrukture);
        text_technology.text = string.Format("{0:F4}   :  X{1}", cost_technology, count_technology);
        text_ecology.text = string.Format("{0:F4}   :  X{1}", cost_ecology, count_ecology);
        text_culture.text = string.Format("{0:F4}   :  X{1}", cost_culture, count_culture);
        CalculateRevenue();
    }
}
