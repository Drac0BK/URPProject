using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;

public class AimOverride : MonoBehaviour
{
    [Header("Camera Data")]
    [SerializeField][Tooltip("Camera used for aiming, set to control")]
    private CinemachineVirtualCamera m_aimCam = null;
    [SerializeField][Tooltip("Camera's standard sensitivity")]
    private float m_camSensitivity;
    [SerializeField][Tooltip("Camera's sensitivity when aiming")]
    private float m_aimCamSnesitivity;
    [Header("Layer Masking")]
    [SerializeField][Tooltip("Layers to ignore")]
    private LayerMask m_aimLayerMask = new LayerMask();
    private Transform m_aimCamTransform;

    [Header("Bullet Data")]
    [SerializeField][Tooltip("Provide a spawn position for the bullet")] // shooting to be done
    private Transform m_bulletSpawnPos;
    [SerializeField][Tooltip("Provide a prefab for the bullet to be spawned")] // shooting to be done
    private GameObject m_bulletPrefab;

    private PlayerControlsTPS m_controller;
    private InputManagerTPS m_inputs;
    private Animator m_animator;

    private Vector2 m_currentAnimationVec;
    private Vector2 m_animationDirection;

    [Space(20)]
    [Header("Other")]
    [Tooltip("How far can the bullet be shot for hit scan")]
    public float m_shotDistance = 200.0f;

    [Tooltip("use to control the rate at with the layers in the animation change.")]
    public float animationLayerTransition = 10f;

    [Tooltip("Use to control how far it projects on a miss, useful for aiming via animation rigging")]
    public float missedRaycastDistance = 200f;


    public Transform m_aimMarkerTransform;

    // Start is called before the first frame update
    private void Awake()
    {
        m_controller = GetComponent<PlayerControlsTPS>();
        m_inputs = GetComponent<InputManagerTPS>();
        m_animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 movement = m_inputs.move.normalized;
        m_currentAnimationVec = Vector2.SmoothDamp(m_currentAnimationVec, movement, ref m_animationDirection, 0.1f, 1.0f); ;

        m_animator.SetBool("IsStillADS",movement == Vector2.zero ? true : false);
        m_animator.SetBool("IsMotionADS", m_inputs.aim);
        m_animator.SetFloat("ForwardMotion", m_currentAnimationVec.y);
        m_animator.SetFloat("RightMotion", m_currentAnimationVec.x);

        Vector3 mouseWorldPos;
        Vector2 screenCenter = new Vector2(Screen.width/2,Screen.height/2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        Transform hitRay = null;
        if (Physics.Raycast(ray, out RaycastHit hit, m_shotDistance, m_aimLayerMask))
        {
            m_aimMarkerTransform.position = hit.point;
            mouseWorldPos = hit.point;
            hitRay = hit.transform;
        }
        else
        {
            m_aimMarkerTransform.position = ray.GetPoint(missedRaycastDistance);
            mouseWorldPos = ray.GetPoint(missedRaycastDistance);
        }
        if (m_inputs.aim)
        {
            m_aimCam.gameObject.SetActive(true);
            m_controller.SetCamSensitivity(m_aimCamSnesitivity);
            m_controller.SetRotateOnMove(false);
            m_animator.SetLayerWeight(1,Mathf.Lerp(m_animator.GetLayerWeight(1),
                1f, Time.deltaTime * animationLayerTransition));

            Vector3 aimTarget = mouseWorldPos;
            aimTarget.y = transform.position.y;
            Vector3 aimDirection = (aimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection,Time.deltaTime * 20);

        }
        else if(!m_inputs.aim)
        {
            m_aimCam.gameObject.SetActive(false);
            //m_controller.SetCamSensitivity(m_aimCamSnesitivity);
            //m_controller.SetRotateOnMove(false);
            //m_animator.SetLayerWeight(1, Mathf.Lerp(m_animator.GetLayerWeight(1), 1f, Time.deltaTime * animationLayerTransition));
        }
    }
}
