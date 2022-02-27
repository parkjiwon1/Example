using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletFactory; //총알 공장 == 총알 파일

    public GameObject firePosition; //총알을 가져다 주면 발사할 총구 위치

    public int poolSize = 10;

    public List<GameObject> bulletObjectPool;

    void Start()// 1. 태어날 때 오브젝트 풀(탄창)에 총알을 하나씩 생성하여 넣고 싶다.
    {
        bulletObjectpool = new List<GameObject>();//2. 탄창을 총알 담을 수 있는 크기로 만들어준다. (리스트로)

        for (int i = 0; i < poolSize; i++)//3. 탄창에 넣을 총알 개수만큼 반복해
        {
            GameObject bullet = Instantiate(bulletFactory); //4. 총알 공장에서 총알을 생성한다.

            bulletObjectPool.Add(bullet) //5. 총알을 오브젝트 풀에 넣고 싶다.

            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //목표: 사용자가 발사 버튼을 누르면 총알을 발사하고 싶다.
        //순서: 1. 사용자가 발사 버튼을 누른다면

        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletObjectPool.Count > 0) //탄창 안에 총알이 있다면
            {
                GameObject bullet = bulletObjectPool[0]; //비활성화된 총알을 하나 가져온다.

                bullet.SetActive(true);// 총알을 발사

                bulletObjectPool.Remove(bullet); //오브젝트 풀 리스트에서 총알 제거

                bullet.transform.position = transform.position; //총알 위치시키기
            }
        }
    }
}
