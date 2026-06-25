using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private Rigidbody2D rb2d;
    private float inputhol, inputver;
    public GameManager gameManager;
    public int damageCoolTime;
    public float damageCoolDown;
    private bool is_inputDamage;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Sprite Dog;
    public Sprite Humstar;
    public Sprite Penguin;

    Vector3 startTouchPos;
    Vector3 endTouchPos;

    float flickValue_x;
    float flickValue_y;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        is_inputDamage = true;
        animator = this.gameObject.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        SetPlayerCostume();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.inGame)
        {
            inputhol = Input.GetAxis("Horizontal");
            inputver = Input.GetAxis("Vertical");

            if (Input.GetKeyDown("a"))
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (Input.GetKeyDown("d"))
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (Input.GetMouseButtonDown(0) == true)
            {
                startTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }
            if (Input.GetMouseButton(0) == true)
            {
                endTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }
            if (Input.GetMouseButtonUp(0))
            {
                startTouchPos = Vector3.zero;
                endTouchPos = Vector3.zero;
            }



            if (damageCoolDown < 0)
            {
                if (animator.GetBool("invisible"))
                {
                    animator.SetBool("invisible", false);
                }
                is_inputDamage = true;
            }

            damageCoolDown -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.inGame)
        {
            FlickDirection();
            GetDirection();

            Vector2 move = new Vector2(inputhol, inputver);
            Debug.Log(move);
            rb2d.AddForce(move * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.inGame)
        {
            if (collision.gameObject.tag == "O2")
            {
                gameManager.sanso += 20f;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Bullet")
            {
                if (is_inputDamage)
                {
                    gameManager.playerHP -= 1;
                    if (gameManager.playerHP != 0)
                    {
                        is_inputDamage = false;
                        damageCoolDown = damageCoolTime;
                        animator.SetBool("invisible", true);
                        Destroy(collision.gameObject);
                    }
                }
            }
        }
    }

    private void SetPlayerCostume()
    {
        if (GameSettings.setting_characterID == 0)
        {
            spriteRenderer.sprite = Dog;
        }
        else if (GameSettings.setting_characterID == 1)
        {
            spriteRenderer.sprite = Humstar;
        }
        else if (GameSettings.setting_characterID == 2)
        {
            spriteRenderer.sprite = Penguin;
        }
    }

    void FlickDirection()
    {
        flickValue_x = endTouchPos.x - startTouchPos.x;
        flickValue_y = endTouchPos.y - startTouchPos.y;
        Debug.Log("x スワイプ量は" + flickValue_x);
        Debug.Log("y スワイプ量は" + flickValue_y);
    }

    void GetDirection()
    {
        if (flickValue_x > 50.0f)
        {
            inputhol = Mathf.Clamp(flickValue_x, -1.0f, 1.0f);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (flickValue_x < -50.0f)
        {
            inputhol = Mathf.Clamp(flickValue_x, -1.0f, 1.0f);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (flickValue_y > 50.0f)
        {
            inputver = Mathf.Clamp(flickValue_y, -1.0f, 1.0f);
        }

        if (flickValue_y < -50.0f)
        {
            inputver = Mathf.Clamp(flickValue_y, -1.0f, 1.0f);
        }
    }
}
