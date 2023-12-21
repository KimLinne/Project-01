using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    Rigidbody2D rigid;
    Vector3 moveDir;
    BoxCollider2D boxCollider2D;
    Animator anim;
    private Camera mainCam;

    [Header("플레이어 데이터")]
    [SerializeField,Tooltip("이동속도")] float moveSpeed = 5f;
    


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        mainCam = Camera.main;
    }

    
    void Update()
    {

        moving();
        turning();


    }

    private void moving()
    {


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            
        }
        

    }

    private void turning()
    {
        if (moveDir.x > 0 && transform.localScale.x > -1)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else if (moveDir.x < 0 && transform.localScale.x < 1)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

}
