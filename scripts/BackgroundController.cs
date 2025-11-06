using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public RawImage background1;
    public RawImage background2;

    void Start()
    {
        // Debug.Log를 통해 background1과 background2의 상태를 출력
        Debug.Log("background1: " + (background1 != null ? background1.name : "null"));
        Debug.Log("background2: " + (background2 != null ? background2.name : "null"));

        // PlayerPrefs에서 SelectedBackground 값을 가져옴
        string selectedBackground = PlayerPrefs.GetString("SelectedBackground");

        // SelectedBackground 값에 따라 배경 활성화 여부 설정
        if (selectedBackground == "Background1")
        {
            if (background1 != null)
                background1.gameObject.SetActive(true);
            if (background2 != null)
                background2.gameObject.SetActive(false);
        }
        else if (selectedBackground == "Background2")
        {
            if (background1 != null)
                background1.gameObject.SetActive(false);
            if (background2 != null)
                background2.gameObject.SetActive(true);
        }
        else
        {
            // 기본적으로 하나를 활성화하거나 기타 처리
            if (background1 != null)
                background1.gameObject.SetActive(true);
            if (background2 != null)
                background2.gameObject.SetActive(false);
        }
    }
}
