using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList : MonoBehaviour
{

    public Action[] _actions = null;
    List<ActionUI> uis = new List<ActionUI>();

    // lazy initialisation public accessor 
    public Action[] actions
    {
        get
        {
            if (_actions == null)
                _actions = GetComponents<Action>();
            return _actions;
        }
    }

}
