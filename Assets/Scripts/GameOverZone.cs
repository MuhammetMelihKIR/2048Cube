using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();
        if (cube != null)
        {
            if (!cube.isMainCube && cube._rb.velocity.magnitude < 0.1f)
            {
                UIManager.instance.GameOverPanel();
            }
        }
    }
}
