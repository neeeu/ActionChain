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
    public class ActionChainTrigger : ActionChainBase, IActionChainTrigger
    {
        [Header("Events")]
        public UnityEvent trigger;

        virtual public void Trigger()
        {
            try
            {
                trigger?.Invoke();
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            _TriggerNext();
        }
    }
}