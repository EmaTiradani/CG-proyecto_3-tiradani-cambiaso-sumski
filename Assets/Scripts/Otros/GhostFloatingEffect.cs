using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFloatingEffect : MonoBehaviour
{

    public GameObject ghost;
    public float speed = 0.2f;
    public float minMove = 0.25f;
    public float maxMove = 0.5f;
    private float startY;

    private bool up = true;

    // Start is called before the first frame update
    void Start()
    {
        startY = ghost.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (ghost.transform.position.y >= startY + maxMove)
        {
            up = false;
        }
        if (ghost.transform.position.y < startY - minMove)
        {
            up = true;
        }

        if (up)
        {
            ghost.transform.position = new Vector3(ghost.transform.position.x, ghost.transform.position.y + Time.deltaTime * speed, ghost.transform.position.z);
        } else
        {
            ghost.transform.position = new Vector3(ghost.transform.position.x, ghost.transform.position.y - Time.deltaTime * speed * speed, ghost.transform.position.z);
        }

    }
}
