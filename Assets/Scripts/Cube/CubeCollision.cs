using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CubeCollision : MonoBehaviour
{
    Cube cube;
   
    private void Awake()
    {
        cube = GetComponent<Cube>();
      
    }


    private void OnCollisionEnter(Collision collision)
    {
        ContactOtherCube(collision);
        
    }

   
    private void ContactOtherCube(Collision collision)
    {
        
        Cube otherCube = collision.gameObject.GetComponent<Cube>();

        if (otherCube != null && cube.cubeID > otherCube.cubeID)
        {
            if (cube.CubeNumber == otherCube.CubeNumber)
            {
                
                Vector3 contactPoint = collision.contacts[0].point;

                if (otherCube.CubeNumber < CubeSpawner.instance.maxCubeNumber)
                {
                    Cube newCube = CubeSpawner.instance.Spawn(cube.CubeNumber * 2, contactPoint);  //yeni oluþan küpün pozisyonu

                    
                    float pushForce = 2.5f;
                    newCube._rb.AddForce(new Vector3(0, 2.5f, 1f) * pushForce, ForceMode.Impulse); // yeni oluþan küpün yapacaðý hareket
                    newCube._lineRenderer.SetActive(false);                    
                    DOTweenManager.instance.NewCubeAnimation(newCube);// yeni küp animasyonu 

                   
                    float randomValue = Random.Range(-20, 20);  //tork
                    Vector3 randomDirection = Vector3.one * randomValue;
                    newCube._rb.AddTorque(randomDirection);
                    



                }
                Collider[] surroundedCubes = Physics.OverlapSphere(contactPoint, 2f); //çarptýðý nesnelerin vereceði tepki
                float explosionForce = 100f;
                float explosionRadius = 1f;

               
                foreach (Collider coll in surroundedCubes)
                {
                   if (coll.attachedRigidbody != null)
                       coll.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);
                }

                
                Particle.instance.PlayExplosion(contactPoint, cube.CubeColor);
                CubeSpawner.instance.DestroyCube(cube);               
                CubeSpawner.instance.DestroyCube(otherCube);
                AudioManager.instance.CubesTouchPlay();
                

            }
        }
    }
}
    

