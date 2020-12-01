using System.Collections.Generic;
using System.Linq;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour {
    [SerializeField, Expandable]
    Tilemap tilemap = default;
    [SerializeField, Expandable]
    TileBase fillTile = default;
    [SerializeField, Expandable]
    TileBase borderTile = default;
    [SerializeField, Range(1, 100)]
    int width = 10;
    [SerializeField, Range(1, 100)]
    int height = 10;
    [SerializeField]
    bool fillTilemap = false;

    IEnumerable<Vector3Int> positionsInsideTilemap {
        get {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    yield return new Vector3Int(x, y, 0);
                }
            }
        }
    }

    void OnValidate() {
        if (!tilemap) {
            TryGetComponent(out tilemap);
        }
        if (fillTilemap) {
            fillTilemap = false;
            var positions = positionsInsideTilemap.ToArray();
            tilemap.SetTiles(positions, Enumerable.Repeat(fillTile, positions.Length).ToArray());
            tilemap.SetTile(Vector3Int.zero, borderTile);
            Debug.Log(tilemap.GetTile(tilemap.WorldToCell(new Vector3(0, 1, 0))));
        }
    }
}
