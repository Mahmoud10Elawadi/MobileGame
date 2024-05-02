using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileHandler : MonoBehaviour
{
    [SerializeField] private Image tileImg;
    private SpwanManager spwanManager;
    private Transform _playerTrans;
    [SerializeField] private Transform enemyPosTrans;

    public Transform EnemyPosTrans { get => enemyPosTrans; set => enemyPosTrans = value; }

    public void SetDir(bool isRight) { 
        var xPos = Screen.width / 2 - tileImg.rectTransform.sizeDelta.x/2;
        xPos = isRight? xPos : -xPos;
        var pos = tileImg.rectTransform.anchoredPosition;
        pos.x = xPos;
        tileImg.rectTransform.anchoredPosition = pos;
    }
    public void SetManager (SpwanManager manager) => spwanManager = manager;
    public void SetPlayerTrans (Transform player) => _playerTrans = player;

    private void Update()
    {
        if (_playerTrans != null)
        {
            var disPlayer = _playerTrans.transform.position.y - transform.position.y;
            if (disPlayer > 2) {
                spwanManager.ResetTitle(this);
            }
        }
    }
}
