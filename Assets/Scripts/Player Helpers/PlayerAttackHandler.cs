using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TMPro namespace

[RequireComponent(typeof(PlayerState))]
public class PlayerAttackHandler : MonoBehaviour
{
    private PlayerState playerState;
    [SerializeField] private Collider2D attackModeCollider;
    private bool isModeActive;
    public TMP_Text scoreText; // Reference to Text Mesh Pro object

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
    }

    public void SetModeState(bool _isActive)
    {
        isModeActive = _isActive;
        HandleState();
    }

    private void HandleState()
    {
        attackModeCollider.gameObject.SetActive(isModeActive);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            playerState.Score++;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {playerState.Score}";
        }
        else
        {
            Debug.LogError("ScoreText reference not assigned in PlayerAttackHandler!");
        }
    }
}
