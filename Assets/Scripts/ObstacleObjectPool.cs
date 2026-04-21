using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public GameObject obstacleBarrelPrefab;
    public GameObject obstacleBarrierPrefab;
    public GameObject obstacleStoneWallPrefab;
    public int poolSize = 10;

    private List<GameObject> obstacleBarrelPool;
    private List<GameObject> obstacleBarrierPool;
    private List<GameObject> obstacleStoneWallPool;

    void Awake()
    {
        obstacleBarrelPool = new List<GameObject>();
        obstacleBarrierPool = new List<GameObject>();
        obstacleStoneWallPool = new List<GameObject>();
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject barrel = Instantiate(obstacleBarrelPrefab);
            barrel.SetActive(false); // ปิดไว้ก่อน
            obstacleBarrelPool.Add(barrel);

            GameObject barrier = Instantiate(obstacleBarrierPrefab);
            barrier.SetActive(false);
            obstacleBarrierPool.Add(barrier);

            GameObject stoneWall = Instantiate(obstacleStoneWallPrefab);
            stoneWall.SetActive(false);
            obstacleStoneWallPool.Add(stoneWall);
        }
    }

    public GameObject Acquire(int obstacleType)
    {
        if (obstacleType == 0) // Barrel
        {
            foreach (GameObject obj in obstacleBarrelPool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true); 
                    return obj; 
                }
            }
        }
        else if (obstacleType == 1) // Barrier
        {
            foreach (GameObject obj in obstacleBarrierPool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
        }
        else if (obstacleType == 2) // StoneWall
        {
            foreach (GameObject obj in obstacleStoneWallPool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
        }
        
        return null; 
    }

    public void Release(GameObject obstacle, int obstacleType)
    {
        obstacle.SetActive(false);
    }
}
