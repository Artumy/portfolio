using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyWaves
{
    public float timeToStart;
    public GameObject wave;
    public bool is_Last_Wave;
}

public class LevelController : MonoBehaviour
{

    public static LevelController instance;
    public GameObject[] playerShip;
    public EnemyWaves[] enemyWaves;

    private bool is_Final = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemyWaves.Length; i++)
        {
            StartCoroutine(CreateEnemyWave(enemyWaves[i].timeToStart, enemyWaves[i].wave, enemyWaves[i].is_Last_Wave));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(is_Final == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("Win");
        }
        if(Player.instance == null)
        {
            Debug.Log("Lose");
        }
    }

    IEnumerator CreateEnemyWave(float delay, GameObject Wave, bool Final)
    {
        if (delay != 0)
            yield return new WaitForSeconds(delay);
        if (Player.instance != null)
            Instantiate(Wave);

        if (Final == true)
            is_Final = true;
    }
}
