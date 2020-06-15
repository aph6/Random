﻿using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class RightTurn : PlayerMove
    {

        public RightTurn(Player player) : base(player) { }

        public override IEnumerator ExecuteMove()
        {
            var origin = transform.position;
            var passing = transform.position + transform.forward * 10;
            var target = passing + transform.right * 10;

            Debug.Log(origin.ToString() + " " + passing.ToString() + " " + target.ToString());

            float t = 0f;

            while (t < 1)
            {
                t += Time.deltaTime;

                var objPosition = Geometry.BezierCurve(t, origin, passing, target);

                transform.LookAt(objPosition);
                transform.position = objPosition;

                yield return new WaitForEndOfFrame();
            }

            transform.position = Grid.GridPosition(transform.position);
            transform.rotation = Geometry.RoundRotation(transform.rotation);

            yield return new WaitForSeconds(1f);

            player.InCoroutine = false;

        }

        public override Tuple<Vector3, Vector3, Vector3> ControlPoints()
        {
            var origin = transform.position;
            var passing = transform.position + transform.forward * 10;
            var target = passing + transform.right * 10;

            return Tuple.Create(origin, passing, target);
        }

    }
}
