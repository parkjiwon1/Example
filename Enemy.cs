using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;

    private void OnCollisionEnter(Collision other) //부딪힐 경우(충돌 시작)
    {
        ScoreManager.Instance.Score++;
        // ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);//ScoreManager의 싱글턴 객체 사용 코드 

        GameObject explosion = Instantiate(explosionFactory); // 충돌하면 폭발효과 공장에서 폭발효과를 하나 만듦

        explosion.transform.position = transform.position; // 폭발 위치 시킴

        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);

            GameObject emObject = GameObject.Find("EnemyManager"); //enemymanager 클래스 가져오기

            EnemyManager manager = emObject.GetComponent<EnemyManager>(); //enemymanager 컴포넌트 가져옴

            manager.enemyObjectPool.Add(other.gameObject); //리스트에 삽입

        }
        else
        {
            gameObject.SetActive(false);
        }

        /*
         GameObject smObject = GameObject.Find("ScoreManager"); //씬의 scoremanager를 불러와서 smobject 변수에 저장

         ScoreManager sm = smObject.GetComponent<ScoreManager>(); //smobject의 구성요소인 scoremanager를 불러와서 scoremanager 객체인 sm에 저장

         sm.SetScore(sm.GetScore() + 1); // Scoremanager의 setscore함수를 불러와서 get 함수로 수정 <- 이전 코드
        */

       
     
    }
    Vector3 dir;

    public GameObject explosionFactory; //폭발 공장의 주소
    void Start()
    {
        
    }
    void OnEnable()
    {

        int randValue = UnityEngine.Random.Range(0, 10); //0~10 중 랜덤한 숫자

        if (randValue < 3) //0,1,2가 나올 확률은 30퍼센트
        {
            GameObject target = GameObject.Find("Player"); //씬에 있는 플레이어 오브젝트를 찾아줘

            if (target != null)
            {
                dir = target.transform.position - transform.position; //플레이어의 위치 - enemy객체의 위치 = 플레이어 방향 벡터

                dir.Normalize(); // 방향의 크기를 1로 하고 싶다.
            }
            else 
            {
                dir = Vector3.down;
            }
        }
        else //나머지 70퍼센트
        {
            dir = Vector3.down; //70퍼 확률로 그냥 밑으로 내려가게
        }
    }
   
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime; // position = p0 + vt
    }

}
