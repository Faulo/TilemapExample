using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour {
    [SerializeField, Expandable]
    Tilemap tilemap = default;
    [SerializeField, Expandable]
    TileBase borderTile = default;
    [SerializeField, Range(1, 100)]
    int width = 10;
    [SerializeField, Range(1, 100)]
    int height = 10;
    [SerializeField]
    bool createBorder = false;

    void OnValidate() {
        if (!tilemap) {
            TryGetComponent(out tilemap);
        }
        if (createBorder) {
            createBorder = false;
            //tilemap.SetTiles();
        }
    }
}
