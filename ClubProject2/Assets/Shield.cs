using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shield : MonoBehaviour
{
    private float liveTime = 2.0f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Attaches the shield to the "Player" gameobject aka locks it to the postion of the player
        transform.position = player.transform.position;
        transform.SetParent(player);

    }
    void Update()
    {
        liveTime -= Time.deltaTime;
        if (liveTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
