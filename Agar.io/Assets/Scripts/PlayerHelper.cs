using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHelper : NetworkBehaviour
{
    [SyncVar]
    public float Speed = 10;

    [SyncVar]
    public float Size = 0.2f;

    [SyncVar]
    public Color Color = Color.blue;

    GameHelper _gameHelper;

    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();

        if (!isLocalPlayer)
            return;

        _gameHelper.CurrentPlayer = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Size, Size, Size);
        GetComponent<SpriteRenderer>().color = Color;

        if (!isLocalPlayer)
            return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector3.MoveTowards(transform.position, mousePos, Time.deltaTime * Speed);

        CheckBounds();
    }

    private void CheckBounds()
    {

        //top
        if (transform.position.x >= _gameHelper.MapSize.x)
            transform.position = new Vector3(_gameHelper.MapSize.x - 0.01f,
                transform.position.y, 0);
        if (transform.position.y >= _gameHelper.MapSize.y)
            transform.position = new Vector3(transform.position.x,
                _gameHelper.MapSize.y - 0.01f, 0);
        //bottom
        if (transform.position.x <= -_gameHelper.MapSize.x)
            transform.position = new Vector3(-_gameHelper.MapSize.x + 0.01f,
                transform.position.y, 0);
        if (transform.position.y <= -_gameHelper.MapSize.y)
            transform.position = new Vector3(transform.position.x,
                -_gameHelper.MapSize.y + 0.01f, 0);
    }

    [Server]
    public void ChangeSize(float size)
    {
        Size = size;
        Speed = 1 / Size;
        transform.localScale = new Vector3(Size, Size, Size);
    }

    [ServerCallback]
    private void OnTriggerStay2D(Collider2D collision)
    {
        Bounds enemy = collision.bounds;
        Bounds current = GetComponent<Collider2D>().bounds;

        Vector2 centerEnemy = enemy.center;
        Vector2 centerCurrent = current.center;

        if(current.size.x > enemy.size.x &&
            Vector3.Distance(centerCurrent, centerEnemy) < current.size.x)
        {
            if (collision.GetComponent<PointHelper>())
            {
                _gameHelper.CreatePoint(Color.red);
                ChangeSize(Size + 0.05f);
            }
            else
                ChangeSize(Size + collision.transform.localScale.x);

            NetworkServer.Destroy(collision.gameObject);
        }

    }
}
