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
    public class ActionChainFor : ActionChainBase, IActionChainTrigger
    {
        [SerializeField] int count = 0;

        [Header("Events")]
        public UnityEvent<int> trigger;

        //
        int idx = 0;

        public void Trigger()
        {
            if (idx < count)
            {
                try
                {
                    trigger?.Invoke(idx);
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e);
                }

                idx++;

                _TriggerNext();
            }
        }


        protected override void TriggerParentNext()
        {
            if (idx < count)
            {
                Trigger();
            }
            else
            {
                base.TriggerParentNext();
            }
        }

    }
}