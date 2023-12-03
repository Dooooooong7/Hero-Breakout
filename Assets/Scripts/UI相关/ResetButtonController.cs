using UnityEngine;
using UnityEngine.UI;

public class ResetButtonController : MonoBehaviour
{
    public RectTransform panel2;
    public RectTransform panel1;
    public float moveDuration = 0.3f;

    public void OnResetButtonClick()
    {
        StartCoroutine(MovePanel2Back());
    }

    private System.Collections.IEnumerator MovePanel2Back()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = panel2.localPosition;
        Vector3 targetPosition = new Vector3(0f, -1208f, 0f); // 设置为原始位置，这里的位置根据你的需求调整

        // 移动Panel2回到原始位置
        while (elapsedTime < moveDuration)
        {
            panel2.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panel2.localPosition = targetPosition;

        // 显示Panel1
        panel1.gameObject.SetActive(true);
    }
}