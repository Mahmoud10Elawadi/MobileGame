using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpwanTilesManager : MonoBehaviour
{
    [SerializeField] private TileHandler tilePrefab;
    [SerializeField] private RectTransform parentPlaceRect;
    [Range(1, 100)][SerializeField] private float rate = 1;
    [Range(1, 100)]  [SerializeField] private float duration = 1;
    List<TileHandler> tileHandlers = new List<TileHandler>();
    private void Start()
    {
        StartCoroutine(SpawnTile());    
    }
    private IEnumerator SpawnTile() {
        yield return new WaitForEndOfFrame();
        while(true){
            var tile = Instantiate(tilePrefab,parentPlaceRect);
            tileHandlers.Add(tile);
            var isRight =Random.Range(1, 100)% 2 == 0;
            var isLeft = Random.Range(100, 1) % 2 == 0;
            tile.SetDir(isRight);
            tile.SetDir(isLeft);
            yield return new WaitForSeconds(duration / rate);
        }
    }
}
