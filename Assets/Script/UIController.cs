using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] SettingPopup settingPopup;
    private int score;
    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    private void Start()
    {
        score= 0;
        scoreLabel.text = score.ToString();
        settingPopup.close();
    }
    void OnEnemyHit()
    {
        score += 1;
        scoreLabel.text=score.ToString();
    }
    
    // Update is called once per frame
    
    public void OnopenSetting()
    {
        Time.timeScale = 0f;
        settingPopup.open();
    }
}
