using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonHelper : MonoBehaviour
{
    public bool IsRuby;
    public bool IsHero;
    public GameObject HeroPrefar;
    public GameObject UpPrefar;

    public Text DamageText;
    public Text PriceText;
    public Image IcoImage;

    public int Damage = 10;
    public int Price = 100;
    GamePoint _gamePoint;
   void Start()
        {
            _gamePoint = GameObject.FindObjectOfType<GamePoint>();

        DamageText.text = '+'+ Damage.ToString();

        PriceText.text = Price.ToString();

    }
    void Update()
    {
        
    }
    public void UpClick()
    {
        if (!IsRuby && _gamePoint.PlayerGold>=Price||
            IsRuby && _gamePoint.PlayerRuby >= Price)
        {
            if (!IsRuby)
                _gamePoint.PlayerGold -= Price;
            else
                _gamePoint.PlayerRuby -= Price;

            if(IsHero == false)
            _gamePoint.PlayerDamage += Damage;

            else
            {
                GameObject hero = Instantiate(HeroPrefar) as GameObject;
                Vector3 heroPos = new Vector3(Random.Range(5f, 9f), Random.Range(-2f, -3f),0);
                hero.transform.position = heroPos;
            }

            GameObject upEffect = Instantiate(UpPrefar) as GameObject;

            Transform canvas = GameObject.Find("Canvas").transform;
            upEffect.transform.SetParent(canvas);
            upEffect.GetComponent<Image>().sprite = IcoImage.sprite;//брать с икнокон картинку

            Destroy(upEffect,1);

            if (IsHero ==false)
            Destroy(gameObject);
        }
    }
}
