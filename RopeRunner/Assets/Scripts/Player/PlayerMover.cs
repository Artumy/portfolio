using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _speedBetweenLinesPlayer = 5;
    [SerializeField] private int _speedBetweenLinesTarget = 10;
    [SerializeField] private SwipePlayer _swipePlayerScript;
    [SerializeField] private PlayerModelChanger _playerModelChanger;
    [SerializeField] private Transform _target;
    
    private PlayerEffects _playerEffects;
    private Transform _player;
    private float _lineDistance = 1;
    private int _lineToMove = 0;
    private bool _canMove = false;
    private bool _canControl = true;
    private bool _immortable = false;

    private float _width;
    private float _height;

    public int LineToMove => _lineToMove;
    public bool isSwipe = true;

    private void OnEnable()
    {
        _playerModelChanger.Destroed += StopMove;
    }

    private void OnDisable()
    {
        _playerModelChanger.Destroed -= StopMove;
    }

    void Awake()
    {
        _width = (float)Screen.width / 3.0f;
        _height = (float)Screen.height / 3.0f;
    }

    private void Start()
    {
        _player = GetComponent<Transform>();
        _playerEffects = GetComponent<PlayerEffects>();
        _canMove = false;
    }

    private void Update()
    {
        //Move(_player, _speedBetweenLinesPlayer);
        //Move(_target, _speedBetweenLinesTarget);
        MoveOfFinger(_player, 5);
        MoveOfFinger(_target, 5);
        if (_canControl)
        {
            if (isSwipe)
                Swipe();
            //else
                //MoveOfFinger();
        }
        if (_swipePlayerScript.tap) _canMove = true;
    }

    private void FixedUpdate()
    {
        if (_canMove == true)
        {
            _player.position += new Vector3(0f, 0f, _speed * Time.deltaTime);
            _target.position += new Vector3(0f, 0f, _speed * Time.deltaTime);
        }
    }

    private void Swipe()
    {
        if (_swipePlayerScript.swipeRight)
        {
            if (_lineToMove < 1)
            {
                _lineToMove++;
            }
        }

        if (_swipePlayerScript.swipeLeft)
        {
            if (_lineToMove > -1)
            {
                _lineToMove--;
            }

        }
    }

    private void MoveOfFinger(Transform newPos, int sidesSpeed)
    {
        if (Input.touchCount > 0 && Input.touchCount < 2)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                //if (touch.position.x < Screen.width - 2 * _width && touch.position.x > 0) _lineToMove = -1;
                //else if (touch.position.x > Screen.width - 2 * _width && touch.position.x < Screen.width - _width) _lineToMove = 0;
                //else _lineToMove = 1;
                Vector3 newPositions = new Vector3((touch.position.x / Screen.width) * 4 - 2, newPos.position.y, newPos.position.z);
                newPos.position = Vector3.Lerp(newPos.position, newPositions, sidesSpeed * Time.deltaTime);
            }
        }

        //if(Input.GetMouseButton(0))
        //{
        //    Vector3 newPositions = new Vector3((Input.mousePosition.x / Screen.width) * 4 - 2, newPos.position.y, newPos.position.z);
        //    newPos.position = Vector3.Lerp(newPos.position, newPositions, sidesSpeed * Time.deltaTime);
        //}
    }

    public void ChangeSpeedOnTime(float speed, float time)
    {
        StartCoroutine(SpeedTimer(speed, time));
    }

    public void ChangeVisibilityEffect(float time)
    {
        StartCoroutine(EffectsTimer(time));
    }

    public void StopMove()
    {
        _canMove = false;
    }

    //private void Move(Transform newPos, int speedBetweenLines)
    //{
    //    Vector3 newPositions = new Vector3(_lineToMove * _lineDistance, newPos.position.y, newPos.position.z);
    //    if (_lineToMove == -1)
    //        newPositions += Vector3.left * _lineDistance;
    //    else if (_lineToMove == 1)
    //        newPositions += Vector3.right * _lineDistance;
    //    newPos.position = Vector3.Lerp(newPos.position, newPositions, speedBetweenLines * Time.deltaTime);
    //}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Button button))
        {
            button.Crash();

            if (_immortable == false)
            {
                _playerModelChanger.TakeDamage();
                ChangeSpeedOnTime(-4f, 2f);
            }
        }
        if (collider.TryGetComponent(out Pillow pillow))
        {
            pillow.Crash();
        }
        if (collider.TryGetComponent(out PreFinishTrigger preFinishTrigger))
        {
            _lineToMove = 0;
            _canControl = false;
        }
        if (collider.TryGetComponent(out FinishTrigger finishTrigger))
        {
            _speed = 7;
        }
    }

    private IEnumerator SpeedTimer(float speed, float time)
    {
        _speed += speed;
        float stepTime = time / 20f;
        float currentTime = time;
        float stepSpeed = speed / 20;
        _immortable = true;

        while (currentTime > 0)
        {
            currentTime -= stepTime;
            _speed -= stepSpeed;
            yield return new WaitForSeconds(stepTime);
        }

        _immortable = false;
    }

    private IEnumerator EffectsTimer(float time)
    {
        float stepTime = time / 20f;
        float currentTime = time;

        while (currentTime > 0)
        {
            currentTime -= stepTime;
            yield return new WaitForSeconds(stepTime);
        }

        _playerEffects.StopFastEffect();

    }
}
