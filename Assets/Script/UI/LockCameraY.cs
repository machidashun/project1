using UnityEngine;
using Cinemachine;
 
[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
public class LockCameraY : CinemachineExtension
{
    [Tooltip("カメラのY座標を固定する値")]
    public float m_YPosition = 10;
    public float[] limit;//0↑1↓
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = m_YPosition;
            state.RawPosition = pos;
            /* float playerPos = GameObject.FindWithTag("Player").gameObject.transform.position.y;
            float cameraPos =  state.RawPosition.y;

            if(5 < playerPos && playerPos >= m_YPosition)
            {
                m_YPosition += 0.01f ;
            }
            else if(0 > playerPos && playerPos <=  m_YPosition)
            {
                m_YPosition -= 0.01f;
            } */
            
        }
    }

}
