using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class DamageState : State
    {
        public DamageState(Player player) : base(player) { }

        public override void Tick()
        {
            if (player.CurrentPhase < 3)
            {
                player.CurrentPhase += 1;
                player.SetState(new MovementState(player));
            }

            else
            {
                player.OnTurnEnded();
                player.TimerBehaviour.ResetTimer();
                player.CurrentPhase = 0;
                player.InTurn = false;
                player.SetState(new IdleState(player));
            }
               
        }

        public override void OnStateEnter()
        {

        }

        public override void OnStateExit()
        {
            player.StopAllCoroutines();
        }

    }
}
