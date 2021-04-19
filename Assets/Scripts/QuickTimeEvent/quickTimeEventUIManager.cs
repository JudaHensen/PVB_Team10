using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickTimeEventUIManager : MonoBehaviour
{

    public GameObject iconNorth;
    public GameObject iconEast;
    public GameObject iconSouth;
    public GameObject iconWest;


    void Start()
    {
        SpawnInput();
    }

    // Update is called once per frame
    void SpawnInput()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0f);
        GameObject input = iconSouth;
            
            
        Instantiate(input, pos, Quaternion.identity);
    }
}
