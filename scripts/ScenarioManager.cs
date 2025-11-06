using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    public GameObject[] map1Backgrounds;
    public GameObject[] map2Backgrounds;
    public GameObject map1Background1_PopUp;

    public GameObject[] marker1Objects;
    public GameObject[] marker2Objects;
    public GameObject[] marker3Objects;
    public GameObject[] marker4Objects;
    public GameObject[] marker5Objects;

    public Button btnNext;
    public Button btnBack;
    public Button btnPopUp;
    public Button btnPopOut;

    private int currentStep = 0;
    private string selectedBackground;

    void Start()
    {
        selectedBackground = PlayerPrefs.GetString("SelectedBackground", "map1_background1");
        Debug.Log($"Selected background: {selectedBackground}");

        btnNext.onClick.AddListener(OnNextButtonClick);
        btnBack.onClick.AddListener(OnBackButtonClick);
        btnPopUp.onClick.AddListener(OnPopUpButtonClick);
        btnPopOut.onClick.AddListener(OnPopOutButtonClick);

        InitializeBackgrounds();
    }

    void OnNextButtonClick()
    {
        if (selectedBackground.StartsWith("map1") && currentStep < map1Backgrounds.Length - 1)
        {
            currentStep++;
        }
        LoadStep(currentStep);
    }

    void OnBackButtonClick()
    {
        if (currentStep > 0)
        {
            currentStep--;
        }
        LoadStep(currentStep);
    }

    void OnPopUpButtonClick()
    {
        DeactivateAllObjects();
        map1Background1_PopUp.SetActive(true);
        ActivatePopUpMarkers();
    }

    void OnPopOutButtonClick()
    {
        DeactivateAllObjects();
        map1Backgrounds[0].SetActive(true);
        btnPopUp.gameObject.SetActive(true);
        ActivateMarkerObjects(0);
    }

    void InitializeBackgrounds()
    {
        DeactivateAllObjects();

        if (selectedBackground.StartsWith("map1"))
        {
            map1Backgrounds[0].SetActive(true);
            ActivateMarkerObjects(0); // 초기 값이 map1_background1
            btnPopUp.gameObject.SetActive(true);
        }
        else if (selectedBackground.StartsWith("map2"))
        {
            map2Backgrounds[0].SetActive(true);
            ActivateMarkerObjects(3); // 초기 값이 map2_background1
        }
    }


    void LoadStep(int step)
    {
        DeactivateAllObjects();

        if (selectedBackground.StartsWith("map1"))
        {
            // map1은 3단계까지 존재하므로, 0 ~ 2로 제한
            if (step >= map1Backgrounds.Length)
            {
                step = 0; // Loop back to the first step
            }
            map1Backgrounds[step].SetActive(true);
            ActivateMarkerObjects(step);

            if (step == 0)
            {
                btnPopUp.gameObject.SetActive(true);
            }
        }
        else if (selectedBackground.StartsWith("map2"))
        {
            
            // map2는 1단계만 존재하므로, step은 0만 허용
            if (step >= map2Backgrounds.Length)
            {
                step = 0; // Loop back to the first step
            }
            map2Backgrounds[step].SetActive(true);
            ActivateMarkerObjects(step + 3); // map2는 step + 3으로 마커 활성화
        }
    }


    void DeactivateAllObjects()
    {
        foreach (var obj in map1Backgrounds) obj.SetActive(false);
        map1Background1_PopUp.SetActive(false);
        foreach (var obj in map2Backgrounds) obj.SetActive(false);


        foreach (var obj in marker1Objects) obj.SetActive(false);
        foreach (var obj in marker2Objects) obj.SetActive(false);
        foreach (var obj in marker3Objects) obj.SetActive(false);
        foreach (var obj in marker4Objects) obj.SetActive(false);
        foreach (var obj in marker5Objects) obj.SetActive(false);
        btnPopOut.gameObject.SetActive(false);
        btnPopUp.gameObject.SetActive(false);
    }

    void ActivateMarkerObjects(int step)
    {
        switch (step)
        {
            case 0:
                marker1Objects[0].SetActive(true);
                marker2Objects[0].SetActive(true);
                break;
            case 1:
                marker1Objects[1].SetActive(true);
                marker2Objects[1].SetActive(true);
                break;
            case 2:
                marker1Objects[2].SetActive(true);
                marker2Objects[2].SetActive(true);
                marker3Objects[0].SetActive(true);
                break;
            case 3:
                marker1Objects[3].SetActive(true);
                marker4Objects[0].SetActive(true);
                marker5Objects[0].SetActive(true);
                break;
        }
    }

    void ActivatePopUpMarkers()
    {
        marker1Objects[0].SetActive(true);
        marker2Objects[0].SetActive(true);
        btnPopOut.gameObject.SetActive(true);
        btnPopUp.gameObject.SetActive(false);
    }
}
