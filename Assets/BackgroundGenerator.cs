using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class BackgroundGenerator : MonoBehaviour
{

    public List<Sprite> _backgrounds;
    public int _numberOfSpawnedObjects;
    BoxCollider2D _collider;


    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        for (int i = 0; i < _numberOfSpawnedObjects; i++)
            SpawnBackground();

    }

    void SpawnBackground()
    {
        GameObject go = new GameObject();
        go.transform.parent = transform;
        Vector3 randomPosition = new Vector3(Random.Range(_collider.bounds.min.x, _collider.bounds.max.x), Random.Range(_collider.bounds.min.y, _collider.bounds.max.y), Random.Range(_collider.bounds.min.z, _collider.bounds.max.z));
        go.transform.position = randomPosition;
        SpriteRenderer r = go.AddComponent<SpriteRenderer>();
        r.sprite = _backgrounds[Random.Range(0, _backgrounds.Count)];
    }

    void Update()
    {

    }
}
