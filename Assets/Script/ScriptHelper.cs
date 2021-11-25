using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHelper : MonoBehaviour
{
    GamePoint _gamePoint;
    PlayerHelper _playerHelper;
    void Start()
    {
        _gamePoint = GameObject.FindObjectOfType<GamePoint>();
        _playerHelper = GameObject.FindObjectOfType<PlayerHelper>();
    }


    private void OnMouseDown()
    {
        if (_gamePoint.EndGame)
        {
            return;
        }
        Debug.Log("OnMouseDown");
      
        GetComponent<HeathHelper>().GetHit(_gamePoint.PlayerDamage);
        _playerHelper.RunAttack();
    }
}
