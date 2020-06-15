using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovementState : State
    {
        public MovementState(Player player) : base(player) { }

        public override void Tick()
        {
            if (!player.InCoroutine)
            {
                player.SetState(new DamageState(player));
            }
        }

        public override void OnStateEnter() => player.InCoroutine = true;

        public override void Execute()
        {
            Debug.Log(player.PlayerMoves[player.CurrentPhase].ControlPoints());
            player.StartCoroutine(player.PlayerMoves[player.CurrentPhase].ExecuteMove());
        }

        public override void OnStateExit() => player.StopAllCoroutines();

    }
}
