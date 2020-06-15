using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class IdleState : State
    {
        public IdleState(Player player) : base(player) { }

        public override void Tick()
        {
            if (player.InTurn)
            {
                player.SetState(new MovementState(player));
            }
        }

        public override void OnStateEnter()
        {

        }

        public override void OnStateExit()
        {

        }

        public override void SetMoves(MoveToken[] moveTokens)
        {
            base.SetMoves(moveTokens);
        }
    }
}
