using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemy_Health;


    [Space]

    public GameObject obj_Bullet;
    public float shot_Time_Min, shot_Time_Max;
    public int shot_Chance;

    [Header("BOSS")]
    public bool is_Boss;
    public GameObject obj_Bullet_Boss;
    public float time_Bullet_Boss_Spawn;
    private float _timer_Shot_Boss;
    public int shot_Chance_Boss;

    private void Start()
    {
        if(!is_Boss)
        {
            Invoke("OpenFire", Random.Range(shot_Time_Min, shot_Time_Max));
        }
    }

    private void Update()
    {
        if(is_Boss)
        {
            if(Time.time > _timer_Shot_Boss)
            {
                _timer_Shot_Boss = Time.time + time_Bullet_Boss_Spawn;
                OpenFire();
                OpenFireBoss();
            }
        }
    }

    private void OpenFire()
    {
        if(Random.value < (float)shot_Chance / 100)
        {
            Instantiate(obj_Bullet, transform.position, Quaternion.identity);
        }
    }

    private void OpenFireBoss()
    {
        if(Random.value < (float)shot_Chance_Boss / 100)
        {
            for(int z = -40; z < 40; z += 10)
            {
                Instantiate(obj_Bullet_Boss, transform.position, Quaternion.Euler(0, 0, z));
            }
        }
    }

    public void GetDamage(int damage)
    {
        enemy_Health -= damage;

        if(enemy_Health <= 0)
        {
            Destruction();
        }
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetDamage(1);
            Player.instance.GetDamage(1);
        }
        if (collision.tag == "Shield")
        {
            GetDamage(1);
            Player.instance.GetDamageShield(1);
        }
    }
}
