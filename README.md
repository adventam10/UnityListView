# UnityListView
![UnityHub-2.4.3](https://img.shields.io/badge/UnityHub-2.4.3-brightgreen) ![Unity-2020.3.6f1](https://img.shields.io/badge/Unity-2020.3.6f1-brightgreen)

`UITableView` ぽいリスト表示できるやつをUnityでつくってみました。

![list_1](https://user-images.githubusercontent.com/34936885/119059183-c60b4a00-ba0a-11eb-9d7a-afaaa6ea3199.gif)

## 使い方
1. セルを Prefab 化する  
`Scene` に `Button` を置いて Assets にドラッグ&ドロップします。
1. `ListViewCell` を継承したスクリプトを作成する

    ```cs
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
    ```
1. Prefab 化したセルにスクリプトを設定する  
   <img width="282" alt="cell" src="https://user-images.githubusercontent.com/34936885/119058995-657c0d00-ba0a-11eb-994c-6f4e2d85b427.png">
1. `Scene` に `ScrollView` を配置する
1. `ScrollView` に `ListView` スクリプトを設定する  
    <img width="286" alt="listView" src="https://user-images.githubusercontent.com/34936885/119058987-614fef80-ba0a-11eb-9476-fc3430177604.png">
1. 適当なスクリプトを設定して以下の様の記載する

    ```cs
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
        
        public object Data(int index) {
            return _dataList[index].ToString();
        }
        
        public int dataCount { 
            get { return _dataList.Count; }
        }
    }
    ```

## 課題
いくつか課題がありますが難しいのであきらめました。

1. 画面サイズが変わった場合にセル数がおかしくなる  
`ScrollView` の高さとセルの高さから必要なセル数を計算する処理を画面サイズ変更時にもやる必要がある？
1. セルの高さを `ScrollView` 上と Prefab 化したセルの二箇所で行う必要がある（しないとサイズが合わない）  
   <img width="130" alt="cell2" src="https://user-images.githubusercontent.com/34936885/119059089-978d6f00-ba0a-11eb-9a5e-3499011b2bc1.png">
1. 上下に無限にスクロールできてしまう  
    <img width="130" alt="cell_height" src="https://user-images.githubusercontent.com/34936885/119059223-d7eced00-ba0a-11eb-8180-7520f792ee71.gif">
1. 指定の位置にコードでスクロールしたい 
`verticalNormalizedPosition` 使えばできるかと思ったのですが難しいのであきらめました。
1. `ReloadData()` 後もスクロール位置を保持したい  
こちらも難しいのでリロード時は一番上へ戻すようにしました。