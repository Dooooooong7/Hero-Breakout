using UnityEngine;
using UnityEngine.UI;

public class RevealMenuInfo : MonoBehaviour
{
    public RectTransform panel1;
    public RectTransform panel2;
    public float moveDuration = 0.3f;

    public void OnButtonClick()
    {
        StartCoroutine(MovePanel2());
    }

    private System.Collections.IEnumerator MovePanel2()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = panel2.localPosition;
        Vector3 targetPosition = Vector3.zero;
        
        // 移动Panel2至屏幕中央底部
        while (elapsedTime < moveDuration)
        {
            panel2.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        panel2.localPosition = targetPosition;

        // 隐藏Panel1
        // panel1.gameObject.SetActive(false);
    }
}