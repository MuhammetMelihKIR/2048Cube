using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    [Header("Touch Values")]
    [SerializeField] private float _speed;
    [SerializeField] private float _limitX;
    [SerializeField] private float _pushForce;
    bool _isMoving = false;
    bool _isPushed = false;
    
   

    public Cube mainCube;
    
    private Vector3 cubePos;
    public void Start()
    {

        SpawnCube();

    }
    public void Update()
    {   
        if (UIManager.instance.canTouch == true && _isMoving == false)
        {
            Movement();

            if (Input.GetMouseButtonUp(0) && _isPushed ==false)
            {
                PushCube();
                _isPushed= true;
                _isMoving = true;                
                Invoke("PushDelay", 0.5f);
            }
        }
       
        
    }
    private void PushDelay()
    {
        _isPushed= false;
        _isMoving = false;
        
    }
    private void Movement()
    {
        float newX = 0;
        float touchXDelta = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x/3 / Screen.width;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = mainCube.transform.position.x + _speed* touchXDelta *Time.deltaTime;
        newX = Mathf.Clamp(newX, -_limitX, _limitX);
        mainCube.transform.position = new Vector3(newX,mainCube.transform.position.y,mainCube.transform.position.z);


    }

    private void PushCube()
    {
        mainCube._lineRenderer.SetActive(false);
        mainCube._rb.AddForce(Vector3.forward * _pushForce, ForceMode.Impulse);
        AudioManager.instance.FrictionPlay();       
        Invoke("SpawnNewCube", 0.5f);      
    }

    
    private void SpawnNewCube()
    {
        mainCube.isMainCube = false;
        SpawnCube();

    }
    private void SpawnCube()
    {
        mainCube = CubeSpawner.instance.SpawnRandom();
        mainCube.isMainCube= true;
        cubePos = mainCube.transform.position;
    }


}
