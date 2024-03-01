using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : MonoBehaviour
{
    // Start is called before the first frame update
    public void open()
    {
        gameObject.SetActive(true);
    }
    public void close()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }
    public void OnSpeedValue(float speed)
    {
        Debug.Log($"Speed:{speed}");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
