using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlAudio : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string createdTag;
    public static AudioSource audioSource;
    void Start()
    {
        GameObject obj = GameObject.FindWithTag(this.createdTag);
        if (obj != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = this.createdTag;
            DontDestroyOnLoad(this.gameObject);
            GameObject dontDestroyObj = GameObject.FindGameObjectWithTag("music_created");
            audioSource = dontDestroyObj.GetComponent<AudioSource>();
            audioSource.enabled = PlayerPrefs.GetInt("music", 1) == 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
