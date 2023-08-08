using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
       
    [SerializeField]  private TMP_Text[] numbersText;
    [HideInInspector] public Color CubeColor;
    [HideInInspector] public int CubeNumber;
    [HideInInspector] public Rigidbody _rb;
    [HideInInspector] public bool isMainCube;
    [HideInInspector] public int cubeID;

    public GameObject _lineRenderer;
    private MeshRenderer _cubeMeshRenderer;
   
    static int staticID = 0;
    

  

    private void Awake()
    {
        
        cubeID = staticID++;
        _cubeMeshRenderer= GetComponent<MeshRenderer>();
        _rb=GetComponent<Rigidbody>();
        
    }

    public void Color (Color color)
    {
        CubeColor = color;
        _cubeMeshRenderer.material.color = color;
       
        
    }

    public void SetNumber(int number)
    {
        CubeNumber= number;

        for (int i = 0; i < 6; i++)
        {
            numbersText[i].text = number.ToString();
        }
    }
}
