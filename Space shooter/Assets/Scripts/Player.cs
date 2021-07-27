using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static Player instance = null;
    public int player_Health = 1;

    public GameObject obj_Shield;
    public int shield_Health = 1;

    private Slider _slider_hp_Player;
    private Slider _slider_hp_Shield;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        _slider_hp_Player = GameObject.FindGameObjectWithTag("sl_HP").GetComponent<Slider>();
        _slider_hp_Shield = GameObject.FindGameObjectWithTag("sl_Shield").GetComponent<Slider>();
    }

    private void Start()
    {
        _slider_hp_Player.value = (float)player_Health / 10;

        if(shield_Health != 0)
        {
            obj_Shield.SetActive(true);

            _slider_hp_Shield.value = (float)shield_Health / 10;
        }
        else
        {
            obj_Shield.SetActive(false);
            _slider_hp_Shield.value = 0;
        }
    }

    public void GetDamageShield(int damage)
    {
        shield_Health -= damage;
        _slider_hp_Shield.value = (float)shield_Health / 10;

        if(shield_Health <= 0)
        {
            obj_Shield.SetActive(false);
        }
    }

    public void GetDamage(int damage)
    {
        player_Health -= damage;
        _slider_hp_Player.value = (float)player_Health / 10;

        if (player_Health <= 0)
            Destruction();
    }

    void Destruction()
    {
        Destroy(gameObject);
    }


}
