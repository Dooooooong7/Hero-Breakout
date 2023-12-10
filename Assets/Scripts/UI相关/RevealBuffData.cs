using TMPro;
using UnityEngine;

public class RevealBuffData : MonoBehaviour
{
    public BuffDataSO buffData;
    public TextMeshProUGUI[] text;

    private void FixedUpdate()
    {
        text[0].text = BuffText((int)(100 * buffData.addDamage / 10f), "伤害加成");
        text[1].text = BuffText((int)(100 * buffData.addDistance / 15f), "距离加成");
        text[2].text = BuffText((int)(100 * buffData.addFrequency) , "频率加成");
        text[3].text = BuffText((int)(100 * buffData.addSpeed / 8f), "弹速加成");
    }

    private string BuffText(int buffValue, string name)
    {
        return $"{name}" + '\n' +
               $"{buffValue}%";
    }
}
