 using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using DG.Tweening;

public class CubeSpawner : MonoBehaviour
{
    public static CubeSpawner instance;

    public Queue<Cube> cubesQueue = new Queue<Cube>();

    [SerializeField] private int _queueSize = 20;
    [SerializeField] private bool _queueGrow = true;

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Color[] _cubeColors; 

   
    private Vector3 _spawnPosition;


    public ScoreData _scoreData;
    
    
    private void Awake()
    {
        instance = this;

        _spawnPosition= transform.position;

        InitializeCubesQueue();
        UIManager.instance.highScoreText.text = "rekor : " + PlayerPrefs.GetInt("highScore").ToString();
        
    }

    private void InitializeCubesQueue()
    {
        for (int i = 0; i < _queueSize; i++)
        {
            AddCubeQueue();
        }
    }

    private void AddCubeQueue()
    {
        Cube cube = Instantiate(_cubePrefab, _spawnPosition, Quaternion.identity, transform).GetComponent<Cube>();             
        cube.gameObject.SetActive(false);
        cube.isMainCube = false;
        cubesQueue.Enqueue(cube);
    }

    public Cube Spawn(int number, Vector3 position)
    {
        if (cubesQueue.Count == 0)
        {
            if (_queueGrow)
            {
                _queueSize++;
                AddCubeQueue();
            }
            else
            {
                return null;
            }
        }

        Cube cube = cubesQueue.Dequeue();       
        cube.transform.position = position;
        cube.SetNumber(number);
        cube.Color(GetColor(number));
        cube.transform.rotation = Quaternion.identity;
        cube.gameObject.SetActive(true);
        DOTweenManager.instance.CubeSpawnAnimation(cube);
        cube._lineRenderer.SetActive(true);
        

        return cube;
    }

    public Cube SpawnRandom()
    {
        return Spawn(GenerateRandomNumber(), _spawnPosition);
    }

    public void DestroyCube(Cube cube)
    {
        _scoreData.Score(cube);       
        cube._rb.velocity = Vector3.zero;
        cube._rb.angularVelocity = Vector3.zero;
        cube.transform.rotation = Quaternion.identity;
        cube.isMainCube = false;
        cube.gameObject.SetActive(false);
        cubesQueue.Enqueue(cube);
    }

    public int GenerateRandomNumber()
    {
        return (int)Mathf.Pow(2,Random.Range(1, 6));
    }

    private Color GetColor(int number)
    {
        return _cubeColors[(int)(Mathf.Log(number) / Mathf.Log(2)) - 1];
    }

   
}

