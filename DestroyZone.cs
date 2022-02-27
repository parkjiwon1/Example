using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour // 영역 안에 다른 물체가 감지될 경우 그 물체를 없애고 싶다.
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet")|| other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.name.Contains("Bullet")) // 부딪힌 물체가 총알일 경우
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>(); //player 불러옴

                player.bulletObjectPool.Add(other.gameObject); //리스트에 총알 삽입
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject = GameObject.Find("EnemyManager"); //enemymanager 클래스 가져오기

                EnemyManager manager = emObject.GetComponent<EnemyManager>(); //enemymanager 컴포넌트 가져옴

                manager.enemyObjectPool.Add(other.gameObject); //리스트에 삽입
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
