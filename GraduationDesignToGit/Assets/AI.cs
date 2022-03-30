using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{
    public Transform[] _target;
    public Transform _targetpos;
    Animator _animator;

    int _nextTarget;
    int _aiSpeed;
    public float _curLab = -0.5f;
    public float _maxLab;
    public float _turn;

    void Start()
    {

        _aiSpeed = Random.Range(5, 8);
        _targetpos = _target[_nextTarget];
        StartCoroutine("AI_Move");
        StartCoroutine("AI_Animation");
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        SetLab();
    }
    IEnumerator AI_Move()
    {
        yield return new WaitForSeconds(3f);

        GetComponent<NavMeshAgent>().speed = _aiSpeed;
        GetComponent<NavMeshAgent>().SetDestination(_targetpos.position);
        while (true)
        {
            float dis = (_targetpos.position - transform.position).magnitude;
            if (dis <= 1)
            {
                _nextTarget++;
                _aiSpeed = Random.Range(5, 8);
                if (_nextTarget >= _target.Length)
                    _nextTarget = 0;

                _targetpos = _target[_nextTarget];
                GetComponent<NavMeshAgent>().speed = _aiSpeed;
                GetComponent<NavMeshAgent>().SetDestination(_targetpos.position);
            }
            yield return null;
        }
    }
    IEnumerator AI_Animation()
    {
        Vector3 lastPosition;
        while (true)
        {
            lastPosition = transform.position;
            yield return new WaitForSeconds(0.03f);
            if ((lastPosition - transform.position).magnitude > 0)
            {
                Vector3 dir = transform.InverseTransformPoint(lastPosition);
                Debug.Log(name + " " + dir.x);
                if (dir.x >= -0.01 && dir.x <= 0.01)
                {
                    if (_aiSpeed >= 7)
                    { _animator.SetBool("Sprint", true); }
                    else { _animator.SetBool("Sprint", false); }
                }
                if (dir.x >= _turn)
                {
                    _animator.SetBool("Turn", true);
                }
                else
                {
                    _animator.SetBool("Turn", false);
                }
            }
            yield return null;

        }
    }
    void SetLab()
    {
        if (_curLab == _maxLab)
        {
            StopCoroutine(AI_Move());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StartLine")
        {
            _curLab += 0.5f;
        }
    }
}
