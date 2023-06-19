using UnityEngine;
using UnityEngine.UI;

public class MainScene : Main
{
    public Sprite[] arrSpritePlanet;
    private RectTransform buttonTransform;

    public static double revenue_main;
    Button mainButton;

    public Transform centerPoint;
    float move_distance = 10f;
    float move_speed = 8f;

    float radius_x = 2f;
    float radius_y = 1f;
    float angle = 0f;

    bool moveUp = false;
    void Start()
    {
        scene_setting = 0;
        Load();
        mainButton = GetComponent<Button>();
        mainButton.onClick.AddListener(ButtonClick);
        buttonTransform = mainButton.GetComponent<RectTransform>();
        GetComponentInChildren<Image>().sprite = arrSpritePlanet[planet_id];
    }
    void MoveUpDown()
    {
        if (moveUp)
        {
            buttonTransform.anchoredPosition += new Vector2(0, move_distance * Time.deltaTime * move_speed);
            if (buttonTransform.anchoredPosition.y >= 247f)
                moveUp = false;
        }
        else
        {
            buttonTransform.anchoredPosition -= new Vector2(0, move_distance * Time.deltaTime * move_speed);
            if (buttonTransform.anchoredPosition.y < 0f)
                moveUp = true;
        }
    }
    void MoveEllips()
    {
        move_speed = 1f;
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius_x;
        float y = centerPoint.position.y+1f + Mathf.Sin(angle) * radius_y;

        transform.position = new Vector2(x, y);

        angle += move_speed * Time.deltaTime;
        if (angle > Mathf.PI * 2f)
        {
            angle -= Mathf.PI * 2f;
        }
    }
    public void ButtonClick()
    {
        money += revenue_main;
        total_money += revenue_main;
        SetMoney();
    }
    public void Load()
    {
        revenue_main = PlayerPrefs.GetFloat("revenue", 1.0f);
        planet_id = PlayerPrefs.GetInt("planet_id");
    }
    void Update()
    {   
        switch (planet_id)
        {
            case 1 or 3:
                MoveUpDown();
                break;
            case 2 or 4:
                MoveEllips();
                break;
        }
    }
}
