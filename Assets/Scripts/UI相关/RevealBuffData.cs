using TMPro;
using UnityEngine;

public class RevealBuffData : MonoBehaviour
{
    public BuffDataSO buffData;
    public TextMeshProUGUI[] text;

    private void FixedUpdate()
    {
        text[0].text = BuffText(buffData.addDamage, "伤害加成");
        text[1].text = BuffText(buffData.addDistance, "距离加成");
        text[2].text = BuffText(buffData.addFrequency, "频率加成");
        text[3].text = BuffText(buffData.addSpeed, "射速加成");
    }

    private string BuffText(float buffValue, string name)
    {
        return $"{name}" + '\n' +
               $"{buffValue}";
    }
}
