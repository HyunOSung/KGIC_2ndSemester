using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FSM
{
    public float moveSpeed;
    public float attackRunSpeed;
    public float rotSpeed = 90.0f;
    CharacterController cc;

    public GameObject target;

    public Transform marker;
    public float Gravity;
    LayerMask layerMask;
    //public bool moveOn = true;




    // Start is called before the first frame update
    protected override void Start()
    {
        //부모 클래스의 함수 호출
        base.Start();

        cc = GetComponent<CharacterController>();
        //layerMask = (1 << LayerMask.NameToLayer("Block")) + (1 << LayerMask.NameToLayer("Click"));
        layerMask = LayerMask.GetMask("Click", "Enemy");
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            RaycastHit hitinfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitinfo, rayLength, layerMask))
            {
                Debug.Log("Picked!" + hitinfo.collider.gameObject);

                if (hitinfo.collider.gameObject.layer == LayerMask.NameToLayer("Click"))
                {
                    marker.SetParent(null);
                    marker.position = hitinfo.point;
                    //currentState = State.Run;

                    ////animator.SetBool("isMoveState", true); 
                    //animator.SetInteger("state", (int)currentState);
                    SetState(State.Run);
                }
                else if (hitinfo.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    marker.SetParent(hitinfo.transform, false);
                    marker.transform.localPosition = Vector3.zero;
                    marker.position = hitinfo.point;

                    moveSpeed = moveSpeed * 1.2f;

                    SetState(State.Attack);
                }
            }
        }



        //if (Physics.Raycast(transform.position, transform.forward * rayLength, out hitinfo))
        //{

        //    Debug.Log("Detected!" + hitinfo.collider.gameObject.layer);

        //}

        //moveOn = true;


        //Vector3 markerXZ = new Vector3(marker.position.x, transform.position.y, marker.position.z);
        Vector3 markerXZ = new Vector3(marker.position.x, transform.position.y, marker.position.z);


        if (Vector3.Distance(markerXZ, transform.position) <= 0.01f)
        {
            //moveOn = false;
            //moveSpeed = 0;
            if (currentState == State.Run)
            {
                //currentState = State.Idle;
                ////animator.SetBool("isMoveState", false);
                //animator.SetInteger("state", (int)currentState);
                SetState(State.Idle);
            }

            return;

        }
        //이동 = 방향 * 속도
        Vector3 dir = marker.position - transform.position;
        Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);
        Vector3 dirY = new Vector3(0, dir.y, 0);
        //Rigidbody rb;

        

        if(currentState == State.AttackRun)
        {
            cc.Move(dirXZ.normalized * attackRunSpeed * Time.deltaTime + Vector3.up * Physics.gravity.y * Time.deltaTime);
        }
        else
        {
            cc.Move(dirXZ.normalized * moveSpeed * Time.deltaTime + Vector3.up * Physics.gravity.y * Time.deltaTime);
        }

        //cc.Move(dirY * Gravity * Time.deltaTime);

        //보정이 필요한 부분 + 서서히 로테이션이 되게
        //transform.LookAt(markerXZ /** rotSpeed * Time.deltaTime*/);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dirXZ.normalized), rotSpeed * Time.deltaTime);

        //if (Mathf.Abs(Vector3.Distance(marker.position, transform.position)) <= 0.5f)
        //{
        //    moveOn = false;
        //    moveSpeed = 0;

        //}
        //Debug.Log(dirXZ);

        //if (dir.x - marker.position.x < 0.1f &&
        //    dir.x - marker.position.x > -0.1f &&
        //    dir.z - marker.position.z < 0.1f &&
        //    dir.z - marker.position.z > -0.1f
        //    )
        //{
        //    moveOn = false;
        //    moveSpeed = 0;
        //}
        //if (moveOn == true)
        //{
        //    moveSpeed = 3.0f;
        //}

    }

    private void FixedUpdate()
    {

    }

    public float rayLength;
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }


    protected override IEnumerator Idle()
    {
        Debug.Log(gameObject.name + "Idle.Start");
        while (isNewState == false)
        {
            //Debug.Log(gameObject.name + "Idle.Update");
            yield return null;
        }
        Debug.Log(gameObject.name + "Idle.End");
    }

    protected override IEnumerator Run()
    {
        Debug.Log(gameObject.name + "Run.Start");
        while (isNewState == false)
        {
            //Debug.Log(gameObject.name + "Run.Update");
            yield return null;
        }
        Debug.Log(gameObject.name + "Run.End");
    }

    IEnumerator Attack()
    {
        Debug.Log(gameObject.name + "Attack.Start");


        yield return new WaitForSeconds(3f);


        Debug.Log(gameObject.name + "Attack.End");

        SetState(State.Idle);
    }

    IEnumerator AttackRun()
    {
        Debug.Log(gameObject.name + "AttackRun.Start");
        while (isNewState == false)
        {
            //Debug.Log(gameObject.name + "Run.Update");
            yield return null;
        }
        Debug.Log(gameObject.name + "AttackRun.End");
    }

    void DebuffDamage()
    {

    }
}
