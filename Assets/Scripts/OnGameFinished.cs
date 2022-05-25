using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.Events;

public class OnGameFinished : MonoBehaviour
{
    [SerializeField] UnityEvent _OnWin;
    [SerializeField] UnityEvent _OnLoose;

    public static OnGameFinished Instance;

    bool _haveEnded = false;
    void Awake()
    {
        _haveEnded = false;
        Instance = this;
    }

    public void OnWin()
    {
        if (_haveEnded)
            return;
        _haveEnded = true;
        _OnWin.Invoke();
    }

    public void OnLoose()
    {
        if (_haveEnded)
            return;
        _haveEnded = true;
        _OnLoose.Invoke();
    }

}
