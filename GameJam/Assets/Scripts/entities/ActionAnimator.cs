using System;
using UnityEngine;

namespace AssemblyCSharp
{
		[RequireComponent(typeof(Animator))]
	public class ActionAnimator : MonoBehaviour
	{
		public bool facingRight = false;
		public bool attacking = false;
		public bool walking = false;
		public bool dead = false;

		Animator anim;
		void Awake()
		{
			anim = GetComponent<Animator>();
		}

		void Update()
		{
			anim.SetBool ("Attacking", attacking);
			anim.SetBool ("Walking", walking);
			anim.SetBool ("Dead", dead);
			anim.SetBool ("FacingRight", facingRight);
		}
	}
}

