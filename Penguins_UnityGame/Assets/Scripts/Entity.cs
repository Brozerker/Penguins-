using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

namespace Assets.Scripts {
    class Entity {
        // 
        public UnityEngine.UI.Text label;
        void Start() {
            label.text = " ";
            label.fontSize = 5;
        }

        //public void AsttackClosest(float damage) {
        //    Transform finder = transform.FindChild("finder");
        //    EntityFinder ef = finder.GetComponent<EntityFinder>();
        //    if(ef.closestMarker != null) {
        //        Entity e = ef.closestMarker.getComponent<Entity>();
        //        e.setstat("hp", e.getstat("hp") - damage);
        //}
    }
}
