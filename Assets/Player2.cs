using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class Player2 : MonoBehaviour
{

    public float _MaxSpeed = 5f;
    float _currentSpeed = 0;
    public Collider2D _MapBounds;
    public Collider2D _WinCollider;

    public void Start()
    {
        _currentSpeed = _MaxSpeed;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * _currentSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1f, 1f), Mathf.Clamp(transform.position.y, _MapBounds.bounds.min.y, _MapBounds.bounds.max.y), transform.position.z);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "FinishCollider")
            OnGameFinished.Instance.OnLoose();
    }
}
