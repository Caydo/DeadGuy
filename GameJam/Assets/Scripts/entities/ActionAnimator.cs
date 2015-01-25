using System;
using UnityEngine;

namespace AssemblyCSharp
{
    [RequireComponent(typeof(Animator))]
    public class ActionAnimator : MonoBehaviour
    {
        public bool attacking = false;
        public bool walking = false;
        public bool dead = false;

        Vector3 oldPosition;

        Animator anim;
        void Awake()
        {
            anim = GetComponent<Animator>();
        }

		Vector3 positionLastFrame;

        void Update()
        {
			bool walkThisFrame = walking;
			if (transform.position != positionLastFrame)
			{
				positionLastFrame = transform.position;
				walkThisFrame = true;
			}

			if (enabled) {
								anim.SetBool ("Attacking", attacking);
								anim.SetBool ("Walking", walkThisFrame);
								anim.SetBool ("Dead", dead);

								if (transform.position.x > oldPosition.x) {
										anim.SetBool ("FacingRight", true);
								} else if (transform.position.x < oldPosition.x) {
										anim.SetBool ("FacingRight", false);
								}
						}

            oldPosition = transform.position;
        }
    }
}
