using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHelper : MonoBehaviour
{
    HeathHelper _healthHelper;
    public int Damage { get; set; }
    void Start()
    {
       
    }


    void Update()
    {
         if(_healthHelper==null)
            _healthHelper = GameObject.FindObjectOfType<HeathHelper>();
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _healthHelper.transform.position, Time.deltaTime*15);
        }
        if (Vector2.Distance(transform.position,_healthHelper.transform.position)<0.1f)
        //Попал 
        {
            _healthHelper.GetHit(Damage);

            Destroy(gameObject);
        }
        
    }
}
