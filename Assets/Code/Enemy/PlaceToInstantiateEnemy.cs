using UnityEngine;

namespace Code.Enemy
{
    internal static class PlaceToInstantiateEnemy
    {
        public static void Borders(Camera camera, ref float minX, ref float maxX, ref float minY, ref float maxY)
        {
            float widthCamera = camera.orthographicSize * camera.aspect;
            float heightCamera = camera.orthographicSize * ( 1/ camera.aspect );
            Vector2 centerCamera = camera.transform.position;

            minX = centerCamera.x - widthCamera;
            maxX = centerCamera.x + widthCamera;
            minY = centerCamera.y - heightCamera;
            maxY = centerCamera.y + heightCamera;
        }
    }
}