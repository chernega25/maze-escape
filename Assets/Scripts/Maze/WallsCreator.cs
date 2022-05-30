using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallsCreator : MonoBehaviour
{
    [SerializeField] List<WallPartsSO> wallParts;
    [SerializeField] Tilemap wallsTilemap;

    void Start()
    {
        Vector3 center = new Vector3(0.5f, 0.5f, 0);

        for (int i = -50; i < 50; ++i) {
            for (int j = -50; j < 50; ++j) {
                Vector3Int tilePos = new Vector3Int(i, j, 0);
                TileBase tile = wallsTilemap.GetTile(tilePos);
                foreach (WallPartsSO wallPart in wallParts) {
                    if (tile == wallPart.tile) {
                        GameObject wall = Instantiate(wallPart.prefab, tilePos + center, Quaternion.identity, transform);
                        ShadowController shadowController = wall.GetComponentInChildren<ShadowController>();
                        if (shadowController != null) {
                            shadowController.InitializeShadows(
                                wallsTilemap.HasTile(tilePos + Vector3Int.up),
                                wallsTilemap.HasTile(tilePos + Vector3Int.down),
                                wallsTilemap.HasTile(tilePos + Vector3Int.left),
                                wallsTilemap.HasTile(tilePos + Vector3Int.right)
                            );
                        }
                    }
                }
            }
        }
        
    }

    void Update()
    {
        
    }
}