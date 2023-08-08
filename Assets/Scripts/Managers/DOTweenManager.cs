using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenManager : MonoBehaviour
{
  
    public static DOTweenManager instance;

    
   
    

    private void Awake()
    {
        instance = this;
    }

    public void CubeSpawnAnimation(Cube cube)  // k�p olu�turma animasyonu
    {
        cube.transform.DOScale(new Vector3(0, 0, 0), 0.2f).From();
    }

    public void NewCubeAnimation(Cube newCube)  // k�pler �arp��t���nda olu�an animasyon
    {
        newCube.transform.DOScale(new Vector3(.6f, .6f, .6f), .5f).OnComplete(() =>
        {
            newCube.transform.DOScale(new Vector3(.41f, .41f, .41f), .5f);

        });
    }

    

    
}
