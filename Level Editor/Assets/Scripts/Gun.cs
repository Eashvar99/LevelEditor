using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//GDW Game
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 10f;

    public int maxAmmo = 30;
    private int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;

    private float nextTimetoFire = 0f;

    private PoolManager _pool;

    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManager>();
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <=0)
        {
            StartCoroutine(Reload());
            return;
        }
        //player has inputted time to shoot
        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Input.GetKey(KeyCode.R) && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
        }
    }

    //must wait a certain amount of time to reload and shoot again
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    //shoots rays at objects
    void Shoot()
    {
        currentAmmo--;
        RaycastHit hitInfo;

        //check if we actually hit anything
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {

            //find the target component on obect we just hit and store it
            Target target = hitInfo.transform.GetComponent<Target>();


            //apply damage to target
            if (target != null)
            {
                target.takeDamage(damage);
            }

            //apply force to target on impact
            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }

            //check if we hit a wall so we can display bulletholes
            if(hitInfo.collider.tag == "Wall")
            {
                
                for(int i = 0; i < _pool.holeList.Count; i++)
                {
                    //if object is inactive in list, use it
                    if(_pool.holeList[i].activeInHierarchy == false)
                    {
                        _pool.holeList[i].SetActive(true);
                        _pool.holeList[i].transform.position = hitInfo.point;
                        _pool.holeList[i].transform.rotation = Quaternion.LookRotation(hitInfo.normal);
                        break;
                    }
                    //in case we go through the entire list and require more bullet holes, create some  
                    else
                    {
                        if(i == _pool.holeList.Count - 1)
                        {
                        GameObject newBullet = Instantiate(_pool.bulletHole) as GameObject;
                        newBullet.transform.parent = _pool.transform;
                        newBullet.SetActive(false);
                        _pool.holeList.Add(newBullet);               
                        }     
                    }
                }
            }

            
        }
    }
}
