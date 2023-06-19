using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    public GameObject prefab;
    int unlock;
    GameObject introduction;
    void Start()
    {
        unlock = PlayerPrefs.GetInt("introduction");
        if (unlock == 0)
        {
            introduction = Instantiate(prefab);
            introduction.GetComponentInChildren<Button>().onClick.AddListener(ClickIntroduction);
        }  
    }
    public void ClickIntroduction()
    {
        PlayerPrefs.SetInt("introduction",1);
        Destroy(introduction);
    }

}
