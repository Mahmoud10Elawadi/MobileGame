using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] TileHandler prefab;
    [SerializeField] Transform placeHodler;
    [SerializeField] GameObject enemyPrefab;
    private List<TileHandler> tileHandlers = new();
    void Start()
    {
        GenerateTiles(Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f)));
    }

    public void GenerateTiles(Vector2 point) { 
        Vector2 tilePos = point;
        tilePos.y += 4.5f / 2;
        CreateTile(tilePos);
        tilePos.y += 4.5f / 2;
        tilePos.x = Random.Range(1, 100) % 2 == 0 ? 1 : -1;
        CreateTile(tilePos);
    }
    private void CreateTile(Vector2 pos) { 
        var tile = GetTitle();
        tile.SetManager(this);
        tile.SetPlayerTrans(playerTrans);
        tile.transform.position = pos;
        tile.transform.rotation = Quaternion.identity;
        tile.transform.parent = placeHodler;
        CreateEnemy(tile.EnemyPosTrans.position);
    }
    private void CreateEnemy(Vector3 pos)
    {
        var enemyTemp = Instantiate(enemyPrefab,pos, Quaternion.identity);
    }
    private TileHandler GetTitle() {
        if(tileHandlers.Count == 0) return Instantiate(prefab);
        var title = tileHandlers[0];
        tileHandlers.RemoveAt(0);
        return title;
   
    }

    public void ResetTitle(TileHandler tileHandler) {
        tileHandler.gameObject.SetActive(false); 
        tileHandlers.Add(tileHandler);
        var pos = tileHandler.transform.position;
        pos.y += 2;
        GenerateTiles(pos);
        GameManager.Instance.HandleCams();
    }
}
