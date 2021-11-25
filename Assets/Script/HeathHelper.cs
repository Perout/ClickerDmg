using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathHelper : MonoBehaviour
{
    public int RubyChanse;
    public int MaxHealth = 100;
    public int Health = 100;
    public int Gold = 90;

    GamePoint _gamePoint;
    bool _isDead;
    void Start()
    {
        _gamePoint = GameObject.FindObjectOfType<GamePoint>();

        _gamePoint.HealthSlider.maxValue = MaxHealth;
        _gamePoint.HealthSlider.value = MaxHealth;
    }



    public void GetHit(int damage)
    {
        if (_isDead)
        {
            return;
        }
        int health = Health - damage;

        if (health<=0)
        {
            _isDead = true;
            _gamePoint.TakeGold(Gold);

            int random = Random.Range(0, 100);
            if (random<RubyChanse)
            {
                _gamePoint.TakeRuby(1);
            }
            Destroy(gameObject);
        }
        GetComponent<Animator>().SetTrigger("Hit");
        Health = health;
        _gamePoint.HealthSlider.value = Health;
    }
}
