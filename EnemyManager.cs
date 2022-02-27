using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float minTime = 0.5f;

    public float maxTime = 1.0f;

    float currentTime;

    float createTime = 1;

    public GameObject enemyFactory;

    public int poolSize = 10;

    public List<GameObject> enemyObjectPool;

    public Transform[] spawnPoints;


    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory); //에너미 공장에서 에너미를 생성

            enemyObjectPool.Add(enemy); //enemy를 오브젝트 풀에 넣는다.

            enemy.SetActive(false); //비활성화
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime; //시간이 흐르다가

        if (currentTime > createTime) //만약 현재 시간이 일정 시간이 되면
        {
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];

                enemyObjectPool.Remove(enemy);

                int index = Random.Range(0, spawnPoints.Length);

                enemy.transform.position = spawnPoints[index].position;

                enemy.SetActive(true);
               
            }
            currentTime = 0; //현재 시간 초기화

            createTime = Random.Range(minTime, maxTime); //생성 시간 초기화
        }
    }
}
