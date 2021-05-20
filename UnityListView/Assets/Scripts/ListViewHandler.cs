using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListViewHandler : MonoBehaviour, ListViewDataSource
{
    private List<int> _dataList = new List<int>();
    private ListView _listView;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            _dataList.Add(i);
        }

        GameObject resultObj = GameObject.Find("ListView");
        _listView = resultObj.GetComponent<ListView> ();
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
