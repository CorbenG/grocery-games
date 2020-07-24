using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerid;

    float deltaX;
    float deltaY;
    Rigidbody _body;

    public float speed;

    public PlayerController otherPlayer;

    private bool inMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaX = Input.GetAxis(playerid + "_Horizontal");
        deltaY = Input.GetAxis(playerid + "_Vertical");

        Vector2 inputVec = new Vector2(deltaX, deltaY).normalized;

        

        if (!inMenu) 
        {
            _body.velocity = new Vector3(deltaX * speed + deltaY * speed,
            _body.velocity.y, deltaY * speed - deltaX * speed);
        }
        

        if (Input.GetAxisRaw(playerid + "_Horizontal") == 0 && Input.GetAxisRaw(playerid + "_Vertical") == 0)
        {
            _body.velocity = new Vector3(_body.velocity.x / 2, _body.velocity.y, _body.velocity.z / 2);

        }
    }
    void OnTriggerStay(Collider other)
    {
        Office office = other.GetComponent<Office>();
        if (office != null)
        {
            if (Input.GetAxis(playerid + "_Action") > 0 && inMenu == false)
            {
                Debug.Log("Open office");
                inMenu = true;
            }
        }
    }

}

