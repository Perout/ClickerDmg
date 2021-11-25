using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePoint : MonoBehaviour
{
    const int Freeq = 3;
    public int GameTime = 10;
    public Text GameTimeText;

    public EndMenuHelper endMenuHelper;
    public GameObject RubyPrefab;
    public Text DamageText;
    public Slider  HealthSlider;

    public Transform StartPosition;
    public GameObject GoldPrefab;
    public GameObject [] MonsterPrefab;

    public Text PlayerGoldUI;
    public Text RubyText;
   
    public int PlayerGold;
    public int PlayerRuby;

    public int PlayerDamage = 10;

    public bool EndGame { get; set; }
    int _count;
   
    float _curentTime;
   

    void Start()
    {
        Time.timeScale = 1;
        InvokeRepeating("Timer", 0, 1);
    }

    void Timer()
    {
        _curentTime++;
        GameTimeText.text = (GameTime - _curentTime).ToString();
        if (_curentTime>=GameTime)
        {//закончить игру
            Time.timeScale = 0;
            EndGame = true;
            endMenuHelper.gameObject.SetActive(true);
            endMenuHelper.ShowEndGame(PlayerGold);
        }
    }
    void Update()
    {
        PlayerGoldUI.text = PlayerGold.ToString();
        DamageText.text = PlayerDamage.ToString();
        RubyText.text = PlayerRuby.ToString();

    }
    public void TakeRuby(int ruby)
    {
        PlayerRuby += ruby;
        GameObject rubyObj = Instantiate(RubyPrefab) as GameObject;
        Destroy(rubyObj, 3);
    }
public void TakeGold(int gold )
    {
        PlayerGold += gold;
        GameObject goldObj =  Instantiate(GoldPrefab) as GameObject;
        Destroy(goldObj, 2);
        SpawnMonstre();
    }
    public void SpawnMonstre()
    {
        _count++;
        int randomMaxValue = _count / Freeq + 1;

        if (randomMaxValue >= MonsterPrefab.Length)
            randomMaxValue = MonsterPrefab.Length;

        int index = Random.Range(0, randomMaxValue);
        GameObject monsterObj = Instantiate(MonsterPrefab[index]) as GameObject;
        monsterObj.transform.position = StartPosition.position;
        
    }
}
