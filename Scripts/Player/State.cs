using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public abstract class State
    {
        protected readonly Player player;

        public State(Player player)
        {
            this.player = player;
        }

        public abstract void Tick();

        public virtual void OnStateEnter() { }

        public virtual void Execute() { }

        public virtual void OnStateExit() { }

        public virtual void SetMoves(MoveToken[] moveTokens) 
        {
            for (int i = 0; i < moveTokens.Length; i++)
            {
                switch (moveTokens[i])
                {
                    case MoveToken.Empty:
                        player.PlayerMoves[i] = new Stay(player);
                        break;
                    case MoveToken.Left:
                        player.PlayerMoves[i] = new LeftTurn(player);
                        break;
                    case MoveToken.Forward:
                        player.PlayerMoves[i] = new Forward(player);
                        break;
                    case MoveToken.Right:
                        player.PlayerMoves[i] = new RightTurn(player);
                        break;
                    default:
                        player.PlayerMoves[i] = new Stay(player);
                        break;
                }
            }
        }


        public virtual IEnumerator CheckForCollision()
        {
            yield break;
        }

    }
}
