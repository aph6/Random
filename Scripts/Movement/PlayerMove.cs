using Assets.Scripts;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class PlayerMove
    {
        protected readonly Player player;
        protected readonly Transform transform;

        public PlayerMove(Player player)
        {
            this.player = player;
            this.transform = player.transform;
        }

        public abstract IEnumerator ExecuteMove();

        public virtual Tuple<Vector3, Vector3, Vector3> ControlPoints() { return null; }
    }
}
