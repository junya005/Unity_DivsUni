using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject straightBullet;
    public int straightBulletCoolTime;
    public float counter_StraightBulletCoolTime;
    public GameObject gameManager;
    private void Start()
    {

    }

    private void Update()
    {
        if (GameManager.inGame)
        {
            if (counter_StraightBulletCoolTime > 0)
            {
                counter_StraightBulletCoolTime -= Time.deltaTime;
            }
            else
            {
                straightBulletCoolTime = Random.Range(3, 7);
                counter_StraightBulletCoolTime = straightBulletCoolTime;
                shot_StrightBullet();
            }
        }
    }

    void shot_StrightBullet()
    {
        GameObject Bullet = Instantiate(straightBullet);
        Bullet.SetActive(true);
    }
}
