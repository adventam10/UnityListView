using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListViewHandler : MonoBehaviour, ListViewDataSource
{
    [SerializeField]
    private ListView _listView;
    private List<int> _dataList = new List<int>();

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            _dataList.Add(i);
        }

        _listView.dataSource = this;
        _listView.selector = delegate (int index) {
             Debug.Log("テーブルデリゲート: " + index);
        };
        _listView.ReloadData();
    }

    public void Action1()
    {
        // _listView.ScrollAtIndex(0);
    }

    public void Action2()
    {
        // _listView.ScrollAtIndex(7);
    }

    public void Action3()
    {
        for (int i = 0; i < 20; i++)
        {
            _dataList.Add(i);
        }
        _listView.ReloadData();
    }
    public object Data(int index) {
        return _dataList[index].ToString();
    }

    public int dataCount { 
        get { return _dataList.Count; }
    }
}
