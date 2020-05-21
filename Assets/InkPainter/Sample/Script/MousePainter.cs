using UnityEngine;

namespace Es.InkPainter.Sample
{
    public class MousePainter : MonoBehaviour
    {
        /// <summary>
        /// Types of methods used to paint.
        /// </summary>
        [System.Serializable]
        private enum UseMethodType
        {
            RaycastHitInfo,
            WorldPoint,
            NearestSurfacePoint,
            DirectUV,
        }

        [SerializeField]
        public Brush brush1;

        [SerializeField]
        private Brush brush2;

        [SerializeField]
        private UseMethodType useMethodType = UseMethodType.RaycastHitInfo;

        [SerializeField]
        bool erase = false;

        private void Update()
        {
            // if (Input.GetMouseButton (0)) {
            // 	PaintGame(brush1);
            // }

            // if (Input.GetMouseButton (1)) {
            // 	PaintGame(brush2);
            // }
        }

        public void OnGUI()
        {
            if (GUILayout.Button("Reset"))
            {
                foreach (var canvas in FindObjectsOfType<InkCanvas>())
                    canvas.ResetPaint();
            }
        }

        public void PaintGame(Brush brush, Vector3 inputPosition)
        {
            var ray = Camera.main.ScreenPointToRay(inputPosition); //Input.mousePosition
            bool success = true;
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                var paintObject = hitInfo.transform.GetComponent<InkCanvas>();

                if (paintObject != null)
                    switch (useMethodType)
                    {
                        case UseMethodType.RaycastHitInfo:
                            success = erase ? paintObject.Erase(brush, hitInfo) : paintObject.Paint(brush, hitInfo);
                            break;

                        case UseMethodType.WorldPoint:
                            success = erase ? paintObject.Erase(brush, hitInfo.point) : paintObject.Paint(brush, hitInfo.point);
                            break;

                        case UseMethodType.NearestSurfacePoint:
                            success = erase ? paintObject.EraseNearestTriangleSurface(brush, hitInfo.point) : paintObject.PaintNearestTriangleSurface(brush, hitInfo.point);
                            break;

                        case UseMethodType.DirectUV:
                            if (!(hitInfo.collider is MeshCollider))
                                Debug.LogWarning("Raycast may be unexpected if you do not use MeshCollider.");
                            success = erase ? paintObject.EraseUVDirect(brush, hitInfo.textureCoord) : paintObject.PaintUVDirect(brush, hitInfo.textureCoord);
                            break;
                    }
                if (!success)
                    Debug.LogError("Failed to paint.");
            }
        }

        public void CahngeColor()
        {
            if (brush1.Color == Color.red)
            {
                brush1.Color = Color.green;
            }
            else
            {
                brush1.Color = Color.red;
            }
        }
    }
}