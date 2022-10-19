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
using UnityEngine.Events;

namespace NEEEU.ActionChain
{
    public class ActionChainSwitch : ActionChainBase, IActionChainTrigger
    {
        [SerializeField] int value;

        [Header("Events")]
        public UnityEvent caseDefault;

        //
        protected List<ActionChainSwitchCase> caseActions = new List<ActionChainSwitchCase>();

        //
        protected override void Awake()
        {
            base.Awake();

            foreach (Transform child in transform)
            {
                ActionChainSwitchCase t = child.GetComponent<ActionChainSwitchCase>();
                if (t != null)
                {
                    caseActions.Add(t);
                }
            }
        }


        protected override void _TriggerNext()
        {
            TriggerParentNext();
        }


        public void SetValue(int v)
        {
            value = v;
        }

        public void Trigger()
        {
            bool found = false;
            foreach(ActionChainSwitchCase caseA in caseActions)
            {
                if (caseA.Value == value)
                {
                    found = true;
                    caseA.Trigger();
                    break;
                }
            }

            if (!found)
            {
                caseDefault?.Invoke();

                // trigger parent next
                TriggerParentNext();
            }

        }
    }

}