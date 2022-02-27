using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;

    private int currentScore; //private으로 설정하여 setscore에서 값을 모두 다룰 수 있게 이양한다.

    public Text bestScoreUI;

    private int bestScore; //private으로 설정하여 setscore에서 점수와 관련된 값을 모두 다룰 수 있게 이양한다. (캡슐화)

    public static ScoreManager Instance = null; // 점수를 관리하는 유일한 매니저, 싱글턴으로 디자인

    void Awake()
    {
        if (Instance == null) //만약 싱글턴 객체에 값이 없으면 생성된 자기 자신을 할당
        {
            Instance = this;//자기 자신 객체 this
        }
    }

    public int Score
    {
        get
        {
            return currentScore;
        }
        set 
        {
           
            currentScore = value;

            currentScoreUI.text = "현재 점수: " + currentScore; //현재 점수 출력

            if (currentScore > bestScore) //현재 점수가 최고점수보다 높다면
            {
                bestScore = currentScore;//갱신

                bestScoreUI.text = "최고 점수: " + bestScore; //갱신된 최고점수 출력

                PlayerPrefs.SetInt("Best Score", bestScore); //최고점수가 int자료형 변수이기 때문에 Set Int로 저장, PlayerPrefs라는 객체 사용
            }
        }
    }

    void Start() // scoremanager가 생성될 때
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0); // 최고 점수를 불러와 bestScore에 넣어주기
        // 0은 만약 저장된 내용이 없을 시에 기본으로 반환할 값
        bestScoreUI.text = "최고 점수 : " + bestScore; // 불러온 bestScore 출력
    }

    
    void Update()
    {
        
    }
}
