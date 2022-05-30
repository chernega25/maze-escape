using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "New Wall Part", fileName = "Wall Part")]
public class WallPartsSO : ScriptableObject
{
    [SerializeField] TileBase _tile;
    [SerializeField] GameObject _prefab;

    public TileBase tile {
        get { return _tile; }
    }

    public GameObject prefab {
        get { return _prefab; }
    }
}
