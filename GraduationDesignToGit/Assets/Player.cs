using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public enum _eGameState
    {
        Ready,
        Play,
        End
    }
    public _eGameState GameState = _eGameState.Ready;
    CharacterController _characterController;
    Animator _animator;
    public GameObject[] _otherCharactor;

    public string _country;
    public string _name;
    public float _maxSpeed;
    public float _rotSpeed;
    public float _curSpeed;
    public float _curLab = -0.5f;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        StartCoroutine(GameStart());
    }
    void OnEnable()
    {
        this._name = GameManager._instance._name;
        this._maxSpeed = GameManager._instance._maxSpeed;
        this._rotSpeed = GameManager._instance._rotSpeed;
    }
    void Update()
    {
        SetCharactor();
        EndGame();
    }
    void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        float TurnDist = h * _rotSpeed * Time.deltaTime;
        transform.rotation = transform.rotation * Quaternion.Euler(0, TurnDist, 0);
        if (h <= -0.9f)
        {
            _animator.SetBool("Turn", true);
        }
        else
        {
            _animator.SetBool("Turn", false);
        }
    }
    void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
        float move = v * _curSpeed;
        Vector3 MoveVec = transform.forward * move;
        _characterController.SimpleMove(MoveVec);
        if (v != 0)
        {
            _curSpeed += 0.2f;
            if (_curSpeed >= _maxSpeed)
            {
                _curSpeed = _maxSpeed;
            }
        }
        else
        {
            _curSpeed -= 0.1f;
            if (_curSpeed <= 0)
            {
                _curSpeed = 0;
            }
        }
    }
    void SetCharactor()
    {
        _country = GameManager._instance._country;
        if (GameState == _eGameState.Play)
        {

            if (_country == _otherCharactor[0].name)
            {

                _otherCharactor[0].gameObject.SetActive(true);
                for (int i = 1; i < _otherCharactor.Length; i++)
                {
                    _otherCharactor[i].gameObject.SetActive(false);
                }
            }
            else if (_country == _otherCharactor[0].name)
            {
                _otherCharactor[0].gameObject.SetActive(true);
                for (int i = 1; i < _otherCharactor.Length; i++)
                {
                    _otherCharactor[i].gameObject.SetActive(false);
                }
            }
            else if (_country == _otherCharactor[0].name)
            {
                _otherCharactor[0].gameObject.SetActive(true);
                for (int i = 1; i < _otherCharactor.Length; i++)
                {
                    _otherCharactor[i].gameObject.SetActive(false);
                }
            }
            else if (_country == _otherCharactor[0].name)
            {
                _otherCharactor[0].gameObject.SetActive(true);
                for (int i = 1; i < _otherCharactor.Length; i++)
                {
                    _otherCharactor[i].gameObject.SetActive(false);
                }
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StartLine")
        {
            _curLab += 0.5f;
        }
    }
    void EndGame()
    {
        if (_curLab == GameManager._instance._maxLab)
        {
            GameState = _eGameState.End;

        }
    }
    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(0.5f);
        GameState = _eGameState.Play;
        while (GameState == _eGameState.Play)
        {
            Move();
            Turn();
            yield return null;
        }


    }
}
