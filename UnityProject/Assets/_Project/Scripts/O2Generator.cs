using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Generator : MonoBehaviour
{
    public int coolTime;
    public float coolDown;
    public GameObject o2;
    public List<Vector3> itemPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (GameManager.inGame) 
        {
            if (coolDown > 0)
            {
                coolDown -= Time.deltaTime;
            }
            else
            {
                GenerateO2();
                coolDown = coolTime;
            }
        }
    }

    void GenerateO2() 
    {
        int randomNum = Random.Range(0,itemPos.Count);
        GameObject o2Clone = Instantiate(o2);
        o2Clone.transform.position = itemPos[randomNum];
    }
}
