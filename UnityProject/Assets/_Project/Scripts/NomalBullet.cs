using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBullet : MonoBehaviour
{
    public GameObject enemybullet;
    [SerializeField]
    private float attackrate;
    [SerializeField]
    private float attacknumber;
    private float cooldown;
    [SerializeField]
    private float bulletSpeed;
    public GameObject gameManagerObj;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.inGame)
        {
            if (gameManager.now_Levels >= 2)
            {
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime;
                }
                else
                {
                    attack();
                    attackrate = Random.Range(2, 6);
                    attacknumber = Random.Range(25, 35);
                    cooldown = attackrate;
                }
            }
        }
    }

    void attack()
    {
        for (int i = 0; i < attacknumber; i++)
        {
            float angle = i * 2 * Mathf.PI / attacknumber;
            Vector3 attackDirection = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            Quaternion attackRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);

            GameObject bullet = Instantiate(enemybullet, transform.position, attackRotation);
            bullet.GetComponent<Rigidbody2D>().velocity = attackDirection * bulletSpeed;
        }
    }
}
