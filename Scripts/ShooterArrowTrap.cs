using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterArrowTrap : Trap
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float shootForce;
    private bool _isTrapActive = false;

    public void Shoot()
    {
        var bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * shootForce);
    }

    public override void PlayAnimation(string name)
    {
        if (!_isTrapActive)
        {
            base.PlayAnimation(name);
            Shoot();
            _isTrapActive = true;
        }
    }
}