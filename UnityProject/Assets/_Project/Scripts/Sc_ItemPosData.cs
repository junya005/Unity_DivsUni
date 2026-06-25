using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemPosData",fileName = "itemDataPos")]
public class Sc_ItemPosData : ScriptableObject
{
    public List<Vector3> itemDataPos = new List<Vector3>();

    public Vector3 GetItemPosData(int elm) 
    {
        return itemDataPos[elm];
    }
}
