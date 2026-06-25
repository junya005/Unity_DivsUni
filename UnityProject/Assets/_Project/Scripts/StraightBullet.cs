using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;

    private Vector2 targetDirection;

    void Start()
    {
        if (player != null)
        {
            targetDirection = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void Update()
    {
        transform.position += (Vector3)targetDirection * speed * Time.deltaTime;
    }
}
