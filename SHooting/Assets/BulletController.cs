using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 direction;
    public float damage;
    public float moveSpeed = 1;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        float _moveSpeed = (moveSpeed) * Time.fixedDeltaTime;
        transform.Translate(direction * _moveSpeed);
            if(this.transform.position.z >= 10)
        {
            Managers.Data.Bullets.Remove(this as BulletController);
            Managers.Pool.Destroy(this.gameObject);
        }
    }
}
