using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ARSceneController : MonoBehaviour
{
    public Canvas loadingCanvas; // 로딩 화면을 포함한 Canvas
    public Image backgroundImage; // 배경 이미지
    public float loadingDuration = 1.0f; // 로딩 화면 표시 시간

    private void Start()
    {
        // 로딩 화면 표시
        if (loadingCanvas != null)
        {
            loadingCanvas.enabled = true;
        }

        // 배경 이미지 비활성화
        if (backgroundImage != null)
        {
            backgroundImage.enabled = false;
        }

        // 1초 후에 로딩 화면을 숨기고 배경 이미지를 표시
        StartCoroutine(ShowBackgroundAfterDelay());
    }

    private IEnumerator ShowBackgroundAfterDelay()
    {
        // 지정된 시간 동안 대기
        yield return new WaitForSeconds(loadingDuration);

        // 로딩 화면 숨김
        if (loadingCanvas != null)
        {
            loadingCanvas.enabled = false;
        }

        // 배경 이미지 표시
        if (backgroundImage != null)
        {
            backgroundImage.enabled = true;
        }
    }
}
