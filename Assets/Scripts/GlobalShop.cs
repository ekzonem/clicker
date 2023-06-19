using UnityEngine;
using UnityEngine.UI;

class GlobalShop : Main
{
    public Button[] arrButtonGlobal;

    public static bool[] globalState;
    bool[] globalButtonState;

    int count_infrastrukture;
    int count_technology;
    int count_ecology;
    int count_culture;

    int value_choise;

    void Start()
    {
        scene_setting = 3;
        globalState = new bool[12];
        globalButtonState = new bool[12];

        LoadDateGlobalShop();
        LoadMoney();
        SetMoney();

        SetStateButton();
    }
    public void Choice(int id)
    {
        SetAfterClickState(id);
        switch (id)
        {
            case 0:
                planet_id = 1;
                planet_level = 1;
                break;
            case 1:
                MainScene.revenue_main *= 2;
                value_choise = 500;
                break;
            case 2:
                value_choise = 1000;
                break;
            case 3:
                planet_id = 2;
                planet_level = 2;
                break;
            case 4:
                MainScene.revenue_main *= 2;
                value_choise = 2000;
                break;
            case 5:
                value_choise = 3000;
                break;
            case 6:
                planet_id = 3;
                planet_level = 3;
                break;
            case 7:
                MainScene.revenue_main *= 2;
                value_choise = 4000;
                break;
            case 8:
                value_choise = 5000;
                break;
            case 9:
                planet_id = 4;
                planet_level = 4;
                break;
            case 10:
                MainScene.revenue_main *= 2;
                value_choise = 8000;
                break;
            case 11:
                value_choise = 10000;
                break;
        }
        money -= value_choise;
        spent_money_all+= value_choise;
        SaveState(id);
        LoadRequirement();
    }
    void SetAfterClickState(int id)
    {
        globalState[id] = true;
        arrButtonGlobal[id].interactable = false;
        arrButtonGlobal[id].GetComponent<Image>().color = Color.red;
        globalButtonState[id] = false;
    }
    void LoadRequirement()
    {
        count_infrastrukture = PlayerPrefs.GetInt("count_infrastrukture_" + planet_id);
        count_technology = PlayerPrefs.GetInt("count_technology_" + planet_id);
        count_ecology = PlayerPrefs.GetInt("count_ecology_" + planet_id);
        count_culture = PlayerPrefs.GetInt("count_culture_" + planet_id);
    }
    private void LoadDateGlobalShop()
    {
        LoadRequirement();

        for (int i = 0; i < 12; i++)
        {
            int value_get = PlayerPrefs.GetInt("globalButtonState_" + i);
            globalButtonState[i] = value_get == 1;
        }
        for (int i = 0; i < 12; i++)
        {
            int value_get = PlayerPrefs.GetInt("globalState_" + i);
            globalState[i] = value_get == 1;
        }
        
    }
    private void SaveState(int i)
    {
        int value_save = globalButtonState[i] ? 1 : 0;
        
        PlayerPrefs.SetInt("globalButtonState_" + i, value_save);

        value_save = globalState[i] ? 1 : 0;
        PlayerPrefs.SetInt("globalState_" + i, value_save);

        PlayerPrefs.SetInt("planet_id", planet_id);

        PlayerPrefs.SetInt("planet_level", planet_id);
    }
    void SetStateButton()
    {
        for (int i = 0; i < 12; i++)
        {
            arrButtonGlobal[i].interactable = globalButtonState[i];
            if (globalState[i] == true)
            {
                arrButtonGlobal[i].GetComponent<Image>().color = Color.red;
            }
        }
    }
    void Update()
    {
        //Planet1
        if (!globalState[0] && planet_level == 0 && count_infrastrukture >= 10 && count_technology >= 15 && count_ecology >= 5 && count_culture >= 10)
        {
            arrButtonGlobal[0].interactable = true;
            globalButtonState[0]= true;
            SaveState(0);
        }
        //Trade_Way1
        if (!globalState[1] && money >= 500 && planet_id == 1 && count_infrastrukture >= 11 && count_technology >= 10 && count_ecology >= 2 && count_culture >= 7)
        {
            arrButtonGlobal[1].interactable = true;
            globalButtonState[1] = true;
            SaveState(1);
        }
        //Trade1
        if (globalState[1] && !globalState[2] && money >= 1000 && planet_id == 1 && count_infrastrukture >= 15 && count_technology >= 20 && count_ecology >= 5 && count_culture >= 13)
        {
            arrButtonGlobal[2].interactable = true;
            globalButtonState[2] = true;
            SaveState(2);
        }
        //Planet2
        if (!globalState[3] && planet_level == 1 && count_infrastrukture >= 20 && count_technology >= 10 && count_ecology >= 25 && count_culture >= 7)
        {
            arrButtonGlobal[3].interactable = true;
            globalButtonState[3] = true;
            SaveState(3);
        }
        //Trade_Way2
        if (!globalState[4] && money >= 2000 && planet_id == 2 && count_infrastrukture >= 10 && count_technology >= 12 && count_ecology >= 15 && count_culture >= 9)
        {
            arrButtonGlobal[4].interactable = true;
            globalButtonState[4] = true;
            SaveState(4);
        }
        //Trade2
        if (globalState[4] && !globalState[5] && money >= 3000 && planet_id == 2 && count_infrastrukture >= 20 && count_technology >= 17 && count_ecology >= 23 && count_culture >= 15)
        {
            arrButtonGlobal[5].interactable = true;
            globalButtonState[5] = true;
            SaveState(5);
        }
        //Planet3
        if (!globalState[6] && planet_level == 2 && count_infrastrukture >= 0 && count_technology >= 0 && count_ecology >= 0 && count_culture >= 0)
        {
            arrButtonGlobal[6].interactable = true;
            globalButtonState[6] = true;
            SaveState(6);
        }
        //Trade_Way3
        if (!globalState[7] && money >= 4000 && planet_id == 3 && count_infrastrukture >= 15 && count_technology >= 17 && count_ecology >= 13 && count_culture >= 19)
        {
            arrButtonGlobal[7].interactable = true;
            globalButtonState[7] = true;
            SaveState(7);
        }
        //Trade3
        if (globalState[7] && !globalState[8] && money >= 5000 && planet_id == 3 && count_infrastrukture >= 25 && count_technology >= 30 && count_ecology >= 20 && count_culture >= 32)
        {
            arrButtonGlobal[8].interactable = true;
            globalButtonState[8] = true;
            SaveState(8);
        }
        //Planet4
        if (!globalState[9] && planet_level == 3 && count_infrastrukture >= 0 && count_technology >= 0 && count_ecology >= 0 && count_culture >= 0)
        {
            arrButtonGlobal[9].interactable = true;
            globalButtonState[9] = true;
            SaveState(9);
        }
        //Trade_Way4
        if (!globalState[10] && money >= 8000 && planet_id == 4 && count_infrastrukture >= 25 && count_technology >= 25 && count_ecology >= 25 && count_culture >= 25)
        {
            arrButtonGlobal[10].interactable = true;
            globalButtonState[10] = true;
            SaveState(10);
        }
        //Trade4
        if (globalState[10] && !globalState[11] && money >= 10000 && planet_id == 4 && count_infrastrukture >=35 && count_technology >= 35 && count_ecology >= 35 && count_culture >= 35)
        {
            arrButtonGlobal[11].interactable = true;
            globalButtonState[11] = true;
            SaveState(11);
        }
    }
}
