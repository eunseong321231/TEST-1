using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public StatData player;
    public float attackCooldown;
    public float currentCooldown;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = Managers.Data.Setting(true, 5, 5, 1, 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove2();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    public void PlayerMove01()
    {
        Vector3 moveInput = new Vector3(0,0,0);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        transform.position += moveInput * player.moveSpeed * Time.deltaTime;
    }

    public void PlayerMove2()
    {
        Vector3 moveInput = Vector3.zero;
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        rb.velocity = moveInput * player.moveSpeed;
    }
    public void FireProjectile()
    {
        GameObject temp = Managers.Pool.Pop(bullet);
        BulletController bc = temp.GetComponent<BulletController>();

        temp.transform.position = this.gameObject.transform.position;
        bc.direction = Vector3.forward;
        bc.damage = player.bulletDamage;
        bc.moveSpeed = player.bulletLevel;

        Managers.Data.Bullets.Add(bc);
    }
}


