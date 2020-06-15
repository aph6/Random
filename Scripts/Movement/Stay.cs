using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Stay : PlayerMove
    {
        public Stay(Player player) : base(player) { }

        public override IEnumerator ExecuteMove()
        {
            yield return new WaitForSeconds(1f);

            player.InCoroutine = false;
        }

        public override Tuple<Vector3, Vector3, Vector3> ControlPoints()
        {
            var origin = transform.position;
            var passing = origin;
            var target = origin;

            return Tuple.Create(origin, passing, target);
        }
    }
}
