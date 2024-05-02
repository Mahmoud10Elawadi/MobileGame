using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class PlayerAttackHandler : MonoBehaviour
{
    private PlayerState playerState;
    [SerializeField] private Collider2D attackModeCollider;
    private bool isModeActive;
    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
    }
    public void SetModeState(bool _isActive) { 
        isModeActive = _isActive;
        HandleState();
    }
    private void HandleState() {
        attackModeCollider.gameObject.SetActive(isModeActive);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) { 
           collision.gameObject.SetActive(false);
            playerState.Score++;
            Debug.Log($"player score is {playerState.Score}");
        }   
    }
}
