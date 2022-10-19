/*
********************************************************************
* ActionChain - NEEEU Spaces GmbH
*
* This files is part of the ActionChain package.
* 
* Written by Ingo Randolf, 2021 - 2022
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*********************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEEEU.ActionChain
{
    [DisallowMultipleComponent]
    public abstract class ActionChainBase : MonoBehaviour
    {
        //
        protected ActionChainBase parentAction;
        protected List<IActionChainTrigger> childActions = new List<IActionChainTrigger>();
        int currentIdx = 0;

        protected virtual void Awake()
        {
            if (transform.parent)
            {
                parentAction = transform.parent.GetComponent<ActionChainBase>();
            }

            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    var t = child.GetComponent<IActionChainTrigger>();
                    if (t != null)
                    {
                        childActions.Add(t);
                    }
                }
            }
        }

        virtual public void Reset()
        {
            currentIdx = 0;
        }

        protected virtual void _TriggerNext()
        {
            if (currentIdx < childActions.Count)
            {
                int i = currentIdx;
                currentIdx++;
                childActions[i].Trigger();
            }
            else
            {
                currentIdx = 0;
                TriggerParentNext();
            }
        }

        protected virtual void TriggerParentNext()
        {
            if (parentAction)
            {
                parentAction._TriggerNext();
            }
            else
            {
                Done();
            }
        }

        protected virtual void Done() { }
    }
}