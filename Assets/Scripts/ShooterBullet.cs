using UnityEngine;

public class ShooterBullet : Shooter
{
    public GameObject projectile;

    public override void Shoot()
    {
        // TODO: Create the prefab projectiles with the same rotation as the pawn
        Debug.Log("It works!");
        GameObject dupProjectile;
        dupProjectile = Instantiate(projectile, transform.position + transform.up, transform.rotation) as GameObject;
        //dupProjectile.GetComponent<DamageOnOverlap>().instantKill = false;
        dupProjectile.GetComponent<DamageOnOverlap>().immuneObject = this.gameObject;
        //dupProjectile.GetComponent<DamageOnOverlap>().isObstacle = true;
    }
}
