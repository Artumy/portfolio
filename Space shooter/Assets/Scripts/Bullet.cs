using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

    public bool is_Enemy_Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(is_Enemy_Bullet && collision.tag == "Player")
        {
            Player.instance.GetDamage(damage);

            Destruction();
        }
        else if(!is_Enemy_Bullet && collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().GetDamage(damage);

            Destruction();
        }
        else if(is_Enemy_Bullet && collision.tag == "Shield")
        {
            Player.instance.GetDamageShield(damage);

            Destruction();
        }
    }
}
