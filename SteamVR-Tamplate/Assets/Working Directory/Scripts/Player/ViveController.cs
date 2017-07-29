using System.Collections;
using UnityEngine;

public class ViveController : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    public SteamVR_Controller.Device leftController { get { return (int)leftTrackedObj.index == -1 ? null : SteamVR_Controller.Input((int)leftTrackedObj.index); } }
    public SteamVR_Controller.Device rightController { get { return (int)rightTrackedObj.index == -1 ? null : SteamVR_Controller.Input((int)rightTrackedObj.index); } }
    private SteamVR_TrackedObject leftTrackedObj;
    private SteamVR_TrackedObject rightTrackedObj;
    
    private Transform viveCamera;

    void Start () {
        leftTrackedObj = transform.Find("Controller (left)").GetComponent<SteamVR_TrackedObject>();
        rightTrackedObj = transform.Find("Controller (right)").GetComponent<SteamVR_TrackedObject>();
        viveCamera = transform.Find("Camera (eye)");
    }

    void Update ()
    {
        if (!isInitialized())
            return;

        // Controller Inputs

        rightTrigger();
        leftTrigger();
        
        rightControllerGripButton();
        leftControllerGripButton();

        rightTouchpadPress();
        leftTouchpadPress();

        leftTouchpad();
        rightTouchpad();
    }

    private bool isInitialized()
    {
        return (leftController != null && rightController != null);
    }
    
    #region Trigger

    private void rightTrigger()
    {
        if (rightController.GetTouchDown(triggerButton))
        {

        }

        if (rightController.GetTouch(triggerButton))
        {

        }

        if (rightController.GetTouchUp(triggerButton))
        {

        }
        if (rightController.GetPressDown(triggerButton))
        {

        }

        if (rightController.GetPress(triggerButton))
        {

        }

        if (rightController.GetPressUp(triggerButton))
        {

        }
    }
    
    private void leftTrigger()
    {
        if (leftController.GetTouchDown(triggerButton))
        {

        }

        if (leftController.GetTouch(triggerButton))
        {

        }

        if (leftController.GetTouchUp(triggerButton))
        {

        }
        if (leftController.GetPressDown(triggerButton))
        {

        }

        if (leftController.GetPress(triggerButton))
        {

        }

        if (leftController.GetPressUp(triggerButton))
        {

        }
    }

    #endregion

    #region GripButton

    private void rightControllerGripButton()
    {
        if (rightController.GetPressDown(gripButton))
        {

        }

        if (rightController.GetPress(gripButton))
        {

        }

        if (rightController.GetPressUp(gripButton))
        {

        }
    }

    private void leftControllerGripButton()
    {
        if (leftController.GetPressDown(gripButton))
        {

        }

        if (leftController.GetPress(gripButton))
        {

        }

        if (leftController.GetPressUp(gripButton))
        {

        }
    }

    #endregion

    #region Touchpad touch

    private void rightTouchpad()
    {

    }

    private void leftTouchpad()
    {
        //Touchpad Movement 
        if (leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x > 0.5 || leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x < -0.5 ||
            leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y > 0.5 || leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y < -0.5)
        {
            Vector3 moveDirection = new Vector3(leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x, 0, leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);
            moveDirection = transform.TransformDirection(moveDirection);
        }

        if (leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y > 0.5 || leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y < -0.5)//UpDown
        {
            transform.position += new Vector3(viveCamera.forward.x, 0, viveCamera.forward.z) * leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y * Time.deltaTime * 3;
        }

        if (leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x > 0.5 || leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x < -0.5)//LeftRight
        {
            transform.position += new Vector3(viveCamera.right.x, 0, viveCamera.right.z) * leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x * Time.deltaTime * 3;
        }
    }
    #endregion

    #region TouchpadPress

    private void rightTouchpadPress()
    {
        if (rightController.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && rightController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y > 0.8)
        {
            Debug.Log("Right Touchpad up pressed.");          
        }

        if (rightController.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && rightController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y < -0.8)
        {          
            Debug.Log("Right Touchpad down pressed.");
        }

        if (rightController.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && rightController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x < -0.8)
        {
            Debug.Log("Right Touchpad left pressed.");
        }

        if (rightController.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && rightController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x > 0.8)
        {
            Debug.Log("Right Touchpad right pressed.");
        }
    }

    private void leftTouchpadPress()
    {
        if (leftController.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y > 0.8)
        {
            Debug.Log("Left Touchpad up pressed.");            
        }

        if (leftController.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y < -0.8)
        {
            Debug.Log("Left Touchpad down pressed.");
        }

        if (leftController.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x < -0.8)
        {
            Debug.Log("Left Touchpad left pressed.");
        }

        if (leftController.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && leftController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x > 0.8)
        {
            Debug.Log("Left Touchpad right pressed.");
        }
    }
    #endregion
}
