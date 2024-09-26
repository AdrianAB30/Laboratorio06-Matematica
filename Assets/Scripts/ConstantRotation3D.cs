using UnityEngine;

namespace Mathematics.Week6
{
    public class ConstantRotation3D : MonoBehaviour
    {
        public float WorldRotation = 20f;

        void Update()
        {
            this.transform.Rotate(new Vector3(WorldRotation, 0, 0) * Time.deltaTime);
        }
    }  
}