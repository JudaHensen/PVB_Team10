using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventManagment
{
    public class GameEvent : MonoBehaviour
    {
        public GameEventType eventType;
        public int ID;
        public GameEvent(GameEventType _type)
        {
            this.eventType = _type;
        }

        public GameEvent(GameEventType _type, int _ID)
        {
            this.eventType = _type;
            this.ID = _ID;
        }
    }
}
