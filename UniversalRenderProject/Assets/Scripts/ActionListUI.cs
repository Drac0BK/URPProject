using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionListUI : MonoBehaviour
{
    public ActionList actionList;
    public ActionUI prefab;

    // Start is called before the first frame update 
    IEnumerator Start()
    {
        Player player = actionList.GetComponent<Player>();
        foreach (Action a in actionList.actions)
        {
            // make this a child of ours on creation.  
            // Don't worry about specifying a position as the LayotGroup handles that
            ActionUI ui = Instantiate(prefab, transform);
            ui.SetAction(a);
            ui.Init(player);

        }
        yield return new WaitForEndOfFrame();

        GetComponent<ContentSizeFitter>().enabled = false;
        GetComponent<LayoutGroup>().enabled = false;
    }
}
