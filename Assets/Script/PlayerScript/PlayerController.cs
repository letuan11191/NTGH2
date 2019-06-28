using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Joystick VirtualJoyStick;
    float getHorizontal;
    float getVertical;
    float speed;
    bool OnGround;
    // Start is called before the first frame update
    void Start()
    {
        OnGround = false;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        getHorizontal += VirtualJoyStick.Horizontal();
        //getVertical -= VirtualJoyStick.Vertical()
        //this.transform.Translate(new Vector2(getHorizontal, this.transform.position.y));    
        if(OnGround)
        {
            getVertical = this.transform.position.y;
            this.transform.position = new Vector2(getHorizontal, getVertical ) * Time.deltaTime * speed;
        }            
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if(Other.transform.name== "Ground")
        {
            
            OnGround = true;

        }
    }

    void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.transform.name == "Ground")
            OnGround = false;
    }
}
