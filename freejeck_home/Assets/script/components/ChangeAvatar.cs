using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.iuixi.FreeJeck
{
	using Types.ShopItems;
	/// <summary>
	/// Change avatar.
	/// </summary>
	public class ChangeAvatar : MonoBehaviour
	{
		private UserModel model;

		void Start ()
		{
			model = Singletons.GET<UserModel>();

			//foreach (var item in model.avatars) {
//				ChangeCloth (item.szItemNif);
			//}
			/// test
			ChangeCloth ("ma01_hair_1031");
			ChangeCloth ("ma01_head_1011");
			ChangeCloth ("ma01_upper_1031");
			ChangeCloth ("ma01_foot_1031");
			ChangeCloth ("ma01_lower_1031");
			ChangeCloth ("ma01_top_1014");
			ChangeCloth ("ma01_arm_5008");
	
		}

        /// <summary>
        ///   加载衣服,并换装
        /// </summary>
		public void ChangeCloth (string name)
		{
			Transform prefab = Resources.Load<Transform>(name);
			Transform cloth = Instantiate(prefab.FindChild(name));
			cloth.SetParent (gameObject.transform);
			AddCloth (cloth);
			Transform meat = prefab.FindChild(cloth.tag);
			ChangeMeat (meat, cloth.tag);

		}

        /// <summary>
        ///   更换衣服下面的mesh,当换了衣服的时候,有的模型会把人的肉露出来
        ///   如果衣服没有提供合适的meat,则会把裸模上的肉给隐藏掉,反之换掉它
        /// </summary>
		private void ChangeMeat (Transform srcMeat, string tag)
		{
			Transform myMeat = gameObject.transform.Find (tag);
           
			if (myMeat != null && srcMeat != null) {
//				Transform meat = Instantiate(srcMeat);
//				meat.SetParent (gameObject.transform);
				SkinnedMeshRenderer srcSkin = srcMeat.GetComponent<SkinnedMeshRenderer> ();
				SkinnedMeshRenderer mySkin = myMeat.GetComponent<SkinnedMeshRenderer> ();
                ChangeBones (mySkin, srcSkin);
			}
			else if(myMeat != null && srcMeat == null){
				myMeat.gameObject.SetActive(false);
			}
		}

        /// <summary>
        /// 替换骨骼,裸模上并没有这个mesh
        /// </summary>
        private void ReplaceBones(SkinnedMeshRenderer srcSkin)
        {
            Transform[] bonesMy = gameObject.GetComponentsInChildren<Transform> ();
			Transform[] bonesSrc = srcSkin.bones;
			string rootName = srcSkin.rootBone.name;

            List<Transform> bones = new List<Transform> ();
			foreach (Transform boneM in bonesSrc) {
				foreach (Transform boneS in bonesMy) {
					if (boneM != null && boneS != null) {
						if (boneM.name != boneS.name) {
							continue;
						}
						bones.Add (boneS);
					}
				}
			}
		
			foreach (Transform boneS in bonesMy) {
				if (boneS != null) {
					if (rootName == boneS.name) {
						srcSkin.rootBone = boneS;
						break;
					}
				}
			}
            srcSkin.bones = bones.ToArray();
        }

        /// <summary>
        ///   更换骨骼
        /// </summary>
		private void ChangeBones (SkinnedMeshRenderer mySkinMeshRender, SkinnedMeshRenderer srcSkin)
		{
            if(mySkinMeshRender == null)
            {
                ReplaceBones(srcSkin);
                return;
            }
			Transform[] bonesMy = gameObject.GetComponentsInChildren<Transform> ();
			Transform[] bonesSrc = srcSkin.bones;
			string rootName = srcSkin.rootBone.name;
			mySkinMeshRender.bones = null;
		
			List<Transform> bones = new List<Transform> ();
			foreach (Transform boneM in bonesSrc) {
				foreach (Transform boneS in bonesMy) {
					if (boneM != null && boneS != null) {
						if (boneM.name != boneS.name) {
							continue;
						}
						bones.Add (boneS);
					}
				}
			}
		
			foreach (Transform boneS in bonesMy) {
				if (boneS != null) {
					if (rootName == boneS.name) {
						mySkinMeshRender.rootBone = boneS;
						break;
					}
				}
			}
			mySkinMeshRender.bones = bones.ToArray ();
			mySkinMeshRender.sharedMesh = srcSkin.sharedMesh;
			mySkinMeshRender.sharedMaterials = srcSkin.sharedMaterials;
		}


        /// <summary>
        ///   把衣服附在骨骼上
        /// </summary>
		private void AddCloth (Transform cloth)
		{
			SkinnedMeshRenderer mySkinMeshRender = cloth.gameObject.GetComponent<SkinnedMeshRenderer> ();
			Transform[] bonesMy = gameObject.GetComponentsInChildren<Transform> ();
			Transform[] bonesSrc = mySkinMeshRender.bones;
			string rootName = mySkinMeshRender.rootBone.name;
			mySkinMeshRender.bones = null;
		
			List<Transform> bones = new List<Transform> ();
			foreach (Transform boneM in bonesSrc) {
				foreach (Transform boneS in bonesMy) {
					if (boneM != null && boneS != null) {
						if (boneM.name != boneS.name) {
							continue;
						}
						bones.Add (boneS);
					}
				}
			}

			foreach (Transform boneS in bonesMy) {
				if (boneS != null) {
					if (rootName == boneS.name) {
						mySkinMeshRender.rootBone = boneS;
						break;
					}
				}
			}

			mySkinMeshRender.bones = bones.ToArray ();

		}
	}
}