using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileHandler : MonoBehaviour
{
    [SerializeField] private Image tileImg;
    public void SetDir(bool isRight) { 
        var xPos = Screen.width / 2 - tileImg.rectTransform.sizeDelta.x/2;
        xPos = isRight? xPos : -xPos;
        var pos = tileImg.rectTransform.anchoredPosition;
        pos.x = xPos;
        tileImg.rectTransform.anchoredPosition = pos;
    }
}
