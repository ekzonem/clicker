using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Achive : Main
{
    bool[] achButtonState;
    bool[] achState;

    public string[] arrTitleA;
    public Sprite[] arrSpriteA;
    public GameObject A_Button;
    public GameObject content;

    private List<GameObject> list = new List<GameObject>();
    private VerticalLayoutGroup __group;

    int count_improve_start_planet;
    int count_improve_ecology;
    int count_improve_infrastrukture;
    int count_improve_technology;
    int count_improve_culture;

    int value_get_ach_state;
    int value_get_button_state;
    void Start()
    {
        scene_setting = 1;
        LoadState();
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = Vector3.zero;
        __group = GetComponent<VerticalLayoutGroup>();
        SetAchive();

        LoadMoney();
        SetMoney();

    }

    public void GetAchive(int id)
    {
        list[id].GetComponent<Button>().interactable = false;
        list[id].GetComponentsInChildren<Image>()[1].sprite = arrSpriteA[1];

        money += 13 * Shop.revenue;
        total_money += 13 * Shop.revenue;

        achButtonState[id] = false;
        achState[id] = true;
        SaveState(id);
        SetMoney();
    }

    private void RemovedList()
    {
        foreach (var el in list)
        {
            Destroy(el);
        }
        list.Clear();
    }

    void SetAchive()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = Vector3.zero;
        RemovedList();
        if (arrTitleA.Length > 0)
        {
            var example1 = Instantiate(A_Button, transform);
            var height = example1.GetComponent<RectTransform>().rect.height;
            var tr = GetComponent<RectTransform>();
            tr.sizeDelta = new Vector2(tr.rect.width, height * arrTitleA.Length);
            Destroy(example1);
            for (int i = 0; i < arrTitleA.Length; i++)
            {
                var example = Instantiate(A_Button, transform);
                if (achState[i] == true)
                {
                    example.GetComponentsInChildren<Image>()[1].sprite = arrSpriteA[1];
                }
                else
                {
                    example.GetComponentsInChildren<Image>()[1].sprite = arrSpriteA[0];
                }

                example.GetComponentInChildren<Text>().text = arrTitleA[i].Replace(":", ":\n");
                int id = i;
                example.GetComponent<Button>().onClick.AddListener(() => GetAchive(id));

                list.Add(example);
                if (achButtonState[i] == false)
                {
                    list[i].GetComponent<Button>().interactable = false;
                }
                else
                {
                    list[i].GetComponent<Button>().interactable = true;
                }

            }
        }
    }


    private void SaveState(int i)
    {
        int value_save = achButtonState[i] ? 1 : 0;
        PlayerPrefs.SetInt("achButtonState_" + i, value_save);

        value_save = achState[i] ? 1 : 0;
        PlayerPrefs.SetInt("achState_" + i, value_save);
    }

    private void LoadState()
    {
        achButtonState = new bool[arrTitleA.Length];
        achState = new bool[arrTitleA.Length];

        count_improve_ecology = 0;
        count_improve_infrastrukture = 0;
        count_improve_technology = 0;
        count_improve_culture = 0;

        for (int i = 0; i < arrTitleA.Length; i++)
        {
            value_get_button_state = PlayerPrefs.GetInt("achButtonState_" + i);
            achButtonState[i] = value_get_button_state == 1;
            value_get_ach_state = PlayerPrefs.GetInt("achState_" + i);
            achState[i] = value_get_ach_state == 1;
        }
        count_improve_start_planet = PlayerPrefs.GetInt("count_infrastrukture_"+0) + PlayerPrefs.GetInt("count_technology_"+0) + PlayerPrefs.GetInt("count_ecology_"+0) + PlayerPrefs.GetInt("count_culture_"+0);
        for (int i = 0; i < 5; i++)
        {
            count_improve_ecology += PlayerPrefs.GetInt("count_ecology_" + i);
            count_improve_infrastrukture += PlayerPrefs.GetInt("count_infrastrukture_" + i);
            count_improve_technology += PlayerPrefs.GetInt("count_technology_" + i);
            count_improve_culture += PlayerPrefs.GetInt("count_culture_" + i);
        }
    }
    void Update()
    {
        //Achive 1
        if (count_improve_start_planet >= 100 && !achState[0])
        {
            list[0].GetComponent<Button>().interactable = true;
        }
        //Achive 2
        if (GlobalShop.globalState[0] && !achState[1])
        {
            list[1].GetComponent<Button>().interactable = true;
        }
        //Achive 3
        if ((GlobalShop.globalState[1] || GlobalShop.globalState[4] || GlobalShop.globalState[7] || GlobalShop.globalState[10]) && !achState[2])
        {
            list[2].GetComponent<Button>().interactable = true;
        }
        //Achive 4
        if (trade_money >= 1000 && !achState[3])
        {
            list[3].GetComponent<Button>().interactable = true;
        }
        //Achive 5
        if (GlobalShop.globalState[9] && !achState[4])
        {
            list[4].GetComponent<Button>().interactable = true;
        }
        //Achive 6
        if (count_improve_ecology >= 100 && !achState[5])
        {
            list[5].GetComponent<Button>().interactable = true;
        }
        //Achive 7
        if (count_improve_technology >= 100 && !achState[6])
        {
            list[6].GetComponent<Button>().interactable = true;
        }
        //Achive 8
        if (count_improve_infrastrukture >= 100 && !achState[7])
        {
            list[7].GetComponent<Button>().interactable = true;
        }
        //Achive 9
        if (count_improve_culture >= 100 && !achState[8])
        {
            list[8].GetComponent<Button>().interactable = true;
        }
        //Achive 10
        if (spent_money >= 10000 && !achState[9])
        {
            list[9].GetComponent<Button>().interactable = true;
        }
        //Achive 11
        if (count_improve_culture + count_improve_ecology + count_improve_infrastrukture + count_improve_technology >= 300 && !achState[10])
        {
            list[10].GetComponent<Button>().interactable = true;
        }
        //Achive 12
        if (spent_money_all >= 50000 && !achState[11])
        {
            list[11].GetComponent<Button>().interactable = true;
        }
        //Achive 13
        if (GlobalShop.globalState[2] && GlobalShop.globalState[5] && GlobalShop.globalState[8] && GlobalShop.globalState[11] && !achState[12])
        {
            list[12].GetComponent<Button>().interactable = true;
        }
        //Achive 14
        if (total_money >= 100000 && !achState[13])
        {
            list[13].GetComponent<Button>().interactable = true;
        }
    }
}