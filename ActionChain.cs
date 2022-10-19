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
    public class ActionChain : ActionChainTrigger
    {
        public UnityEvent done;

        public override void Trigger()
        {
            Reset();
            base.Trigger();
        }

        protected override void Done()
        {
            done?.Invoke();
        }

        public override void Reset()
        {
            base.Reset();

            ActionChainBase[] items = GetComponentsInChildren<ActionChainBase>();
            foreach (var item in items)
            {
                // exclude myself
                if (item.gameObject != gameObject)
                {
                    item.Reset();
                }
            }

        }
    }
}
