using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager {

    GameObject pfGround;
    Transform root;
    List<Ground> listActive;
    List<Ground> listDeActive;
    // Use this for initialization
    public void Init (GameObject _pfGround, Transform _root) {
        pfGround = _pfGround;
        root = _root;
        listActive = new List<Ground>();
        listDeActive = new List<Ground>();

    }
    public void Reset()
    {
        while (listActive.Count > 0)
        {
            Unspawn(listActive[0]);
        }
    }
    public void Clear()
    {
        Ground _object;
        while (listActive.Count > 0)
        {
            _object = listActive[0];
            listActive.RemoveAt(0);
            _object.DestroyObject();
        }

        while (listDeActive.Count > 0)
        {
            _object = listDeActive[0];
            listDeActive.RemoveAt(0);
            _object.DestroyObject();
        }
    }
    public void AddObject()
    {
        GameObject _item = Utils.Spawn(pfGround, root);
        Ground _ground = _item.GetComponent<Ground>();
        listDeActive.Add(_ground);
        _ground.deActive = Unspawn;
        _ground.Deactivate();
    }
    public void AddObject(int length)
    {
        for (int i = 0; i < length; i++)
        {
            AddObject();
        }
    }
    public void Unspawn(Ground _object)
    {
        listActive.Remove(_object);
        listDeActive.Add(_object);
        _object.Deactivate();
    }
    public Ground Spawn(int ww, int hh, int xx)
    {
        Utils.Log("Spawn Ground");
        if (listDeActive.Count == 0)
        {
            AddObject();
        }
        Ground _object = listDeActive[0];
        listDeActive.RemoveAt(0);
        listActive.Add(_object);
        _object.Activate();
        _object.init(ww, hh, xx);
        return _object;
    }
}
