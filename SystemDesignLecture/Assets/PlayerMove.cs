using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 10.0f;
    float rotateSpeed = 50.0f;
    public float backSpeed = 5.0f;
    public float horizSpeed = 7.5f;

    public float jumpStartSpeed = 50.0f;
    float jumpSpeed;

    bool bAir = false;

    public GameObject bullet;

    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0, 0, -backSpeed * Time.deltaTime), Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(-horizSpeed * Time.deltaTime,0,0), Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(horizSpeed * Time.deltaTime,0,0), Space.Self);
        }


        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
        }

        if(Input.GetKeyDown(KeyCode.Space) && bAir == false)
        {
            jumpSpeed = jumpStartSpeed;
            bAir = true;
        }

        if(bAir == true)
        {
            this.transform.Translate(0, jumpSpeed * Time.deltaTime, 0);
            Gravity();
        }

        if(bAir == false)
        {
            this.transform.position.Set(0, 0.5f, 0);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject pB = Instantiate(bullet, this.transform.position, this.transform.rotation);

        pB.GetComponent<BulletMove>().moveSpeed = bulletSpeed;

        //Instantiate(bullet,this.transform.position, this.transform.rotation);
    }

    void Gravity()
    {
        jumpSpeed = jumpSpeed - 30.0f * Time.deltaTime;

        if(this.transform.position.y <= 0.5f)
        {
            bAir = false;
            
           
        }
    }
}
