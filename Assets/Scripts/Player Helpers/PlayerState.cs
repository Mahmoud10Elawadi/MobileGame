using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int hp;
    [SerializeField] private float power;
    [SerializeField] private float speed;

    public int Score { get => score; set => score = value; }
    public int Hp { get => hp; set => hp = value; }
    public float Power { get => power; set => power = value; }
    public float Speed { get => speed; set => speed = value; }
}
