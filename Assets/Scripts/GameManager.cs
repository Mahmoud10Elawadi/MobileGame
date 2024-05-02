using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] private GameObject fCame;
    [SerializeField] private GameObject sCame;

    public static GameManager Instance { get => _instance; set => _instance = value; }
    private void Awake()
    {
        _instance = this;
    }
    private void OnDestroy()
    {
        _instance = null;
    }
    public void HandleCams() { 
        sCame.SetActive(true);
        fCame.SetActive(false);
    }
}
