using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsAndBonus : MonoBehaviour
{

    public GameObject obj_bonus;
    public float time_Bonus_Spawn;

    public GameObject[] obj_Planets;
    public float time_Planet_Spawn;
    public float speed_Planets;

    List<GameObject> planetsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BonusCreation());

        StartCoroutine(PlanetsCreation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BonusCreation()
    {
        while(true)
        {
            yield return new WaitForSeconds(time_Bonus_Spawn);

            Instantiate(
                obj_bonus, new Vector2(Random.Range(PlayerMoving.instance.borders.minX, PlayerMoving.instance.borders.maxX),
                PlayerMoving.instance.borders.maxY * 1.5f), Quaternion.identity);
        }
    }

    IEnumerator PlanetsCreation()
    {
        for(int i = 0; i < obj_Planets.Length; i++)
        {
            planetsList.Add(obj_Planets[i]);
        }

        yield return new WaitForSeconds(7);

        while(true)
        {
            int randomIndex = Random.Range(0, planetsList.Count);

            GameObject newPlanet = Instantiate(planetsList[randomIndex],
                new Vector2(Random.Range(PlayerMoving.instance.borders.minX, PlayerMoving.instance.borders.maxX),
                PlayerMoving.instance.borders.maxY * 1.5f),
                Quaternion.Euler(0, 0, Random.Range(-25, 25)));

            planetsList.RemoveAt(randomIndex);

            if(planetsList.Count == 0)
            {
                for(int i = 0; i < obj_Planets.Length; i++)
                {
                    planetsList.Add(obj_Planets[i]);
                }
            }

            newPlanet.GetComponent<ObjMoving>().speed = speed_Planets;

            yield return new WaitForSeconds(time_Planet_Spawn);
        }
    }
}
