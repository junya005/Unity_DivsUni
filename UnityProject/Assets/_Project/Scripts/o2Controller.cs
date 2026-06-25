using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o2Controller : MonoBehaviour
{
    public int deleteCoolTime;
    private float coolDown;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = deleteCoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
