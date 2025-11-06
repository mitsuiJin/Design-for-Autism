using UnityEngine;

public class BgAndObject : MonoBehaviour
{
    public GameObject imageTarget1; // 첫 번째 ImageTarget
    public GameObject imageTarget2; // 두 번째 ImageTarget

    public GameObject object1_Map1; // ImageTarget의 Object1_Map1
    public GameObject object1_Map2; // ImageTarget의 Object1_Map2
    public GameObject object2_Map1; // ImageTarget2의 Object2_Map1
    public GameObject object2_Map2; // ImageTarget2의 Object2_Map2

    void Start()
    {
        // PlayerPrefs에서 SelectedBackground 값을 가져옴
        string selectedBackground = PlayerPrefs.GetString("SelectedBackground");

        // 기본적으로 모든 오브젝트 비활성화
        DisableAllObjects();

        // SelectedBackground 값에 따라 맵에 맞는 오브젝트 활성화
        if (selectedBackground == "Background1")
        {
            ActivateObjectsForMap1();
        }
        else if (selectedBackground == "Background2")
        {
            ActivateObjectsForMap2();
        }
        else
        {
            Debug.LogError("Unknown background selected.");
        }
    }
    void DisableAllObjects()
    {
        if (object1_Map1 != null)
            object1_Map1.SetActive(false);
        if (object1_Map2 != null)
            object1_Map2.SetActive(false);
        if (object2_Map1 != null)
            object2_Map1.SetActive(false);
        if (object2_Map2 != null)
            object2_Map2.SetActive(false);
    }

    void ActivateObjectsForMap1()
    {
        if (object1_Map1 != null)
            object1_Map1.SetActive(true);
        if (object2_Map1 != null)
            object2_Map1.SetActive(true);
    }

    void ActivateObjectsForMap2()
    {
        if (object1_Map2 != null)
            object1_Map2.SetActive(true);
        if (object2_Map2 != null)
            object2_Map2.SetActive(true);
    }
}
