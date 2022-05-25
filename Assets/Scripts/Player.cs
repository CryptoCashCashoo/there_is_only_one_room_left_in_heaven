using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public float _MaxSpeed = 5f;
    Rigidbody2D _rb;

    public GameObject _Effect;
    public float _MaxPowerUpTime = 3f;
    float _PowerUpTime = 0f;
    public float _PowerUpSpeedMultiplayer = 2f;
    public Collider2D _MapBounds;

    SpriteRenderer _sr;
    public float _MaxTimeHit = 2f;
    public float _HitPenalizationMultiplayer = 0.5f;
    float _TimeHit = 0;



    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _Effect.SetActive(false);
    }



    public void ActivatePowerup()
    {
        _Effect.SetActive(true);
        _PowerUpTime = _MaxPowerUpTime;
    }

    void FixedUpdate()
    {
        if (_PowerUpTime > 0)
        {
            _PowerUpTime -= Time.fixedDeltaTime;
            if (_PowerUpTime <= 0)
                _Effect.SetActive(false);
        }

        if (_TimeHit >= 0)
        {
            _TimeHit -= Time.fixedDeltaTime;
            if (_TimeHit <= 0)
                _sr.color = Color.white;
        }


        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            dir.x = -1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            dir.x = 1;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            dir.y = 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            dir.y = -1;
        if (dir != Vector2.zero)
        {
            dir = dir.normalized;
            if (_TimeHit > 0)
                dir = dir * _MaxSpeed * _HitPenalizationMultiplayer;
            else
                dir = dir * _MaxSpeed * (_PowerUpTime > 0 ? _PowerUpSpeedMultiplayer : 1);
            _rb.AddForce(dir);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1f, 1f), Mathf.Clamp(transform.position.y, _MapBounds.bounds.min.y, _MapBounds.bounds.max.y), transform.position.z);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            Destroy(col.gameObject.transform.parent.gameObject);
            _TimeHit = _MaxTimeHit;
            _sr.color = Color.red;
            _PowerUpTime = 0.001f;
        }
        else if (col.transform.tag == "PowerUp")
        {
            ActivatePowerup();
            _TimeHit = 0.001f;
            Destroy(col.gameObject);
        }

        else if (col.transform.tag == "FinishCollider")
        {
            OnGameFinished.Instance.OnWin();
        }
    }
}
