using UnityEngine;
using UnityEngine.UI;

public class SampleCell : ListViewCell
{
    [SerializeField]
    private Text _text;

    public override void UpdateData(int index, object obj)
    {
        base.UpdateData(index, obj);
        _text.text = obj as string;
    }
}