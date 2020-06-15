using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Forward : PlayerMove
    {
        public Forward(Player player) : base(player) { }
        
        public override IEnumerator ExecuteMove()
        {
            var origin = transform.position;
            var target = transform.position + transform.forward * 10;

            float t = 0f;

            while (t < 1)
            {
                t += Time.deltaTime;

                transform.position = Vector3.Lerp(origin, target, t);

                yield return new WaitForEndOfFrame();
            }

            transform.position = Grid.GridPosition(transform.position);

            yield return new WaitForSeconds(1f);

            player.InCoroutine = false;
        }

        public override Tuple<Vector3, Vector3, Vector3> ControlPoints()
        {
            var origin = transform.position;
            var passing = origin + transform.forward * 10;
            var target = passing;

            return Tuple.Create(origin, passing, target);
        }
    } 
}
