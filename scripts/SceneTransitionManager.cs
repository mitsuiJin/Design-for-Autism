using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public Canvas loadingCanvas; // 로딩 화면을 표시할 Canvas
    public float loadingDuration = 1.0f; // 로딩 화면 표시 시간 (초)
    public string targetSceneName; // 이동할 맵의 이름

    private Button startButton;

    private void Start()
    {
        // Start 버튼을 찾아 연결
        startButton = GetComponent<Button>();
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClick);
        }

        // 로딩 화면 비활성화
        if (loadingCanvas != null)
        {
            loadingCanvas.enabled = false;
        }
    }

    private void OnStartButtonClick()
    {
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        // 로딩 화면 활성화
        if (loadingCanvas != null)
        {
            loadingCanvas.enabled = true;
        }

        // 지정된 시간 동안 대기
        yield return new WaitForSeconds(loadingDuration);

        // Scene 로드
        SceneManager.LoadScene(targetSceneName);
    }
}
