using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private DataPointScale FilterDataPointScale;

    [SerializeField]
    private DataPointScale FilterMiniDataPointScale;

    [SerializeField]
    private DataPointScale ExhaustDataPointScale;

    [SerializeField]
    private DataPointScale ExhaustMiniDataPointScale;

    [SerializeField]
    private DataPointScale PistonDataPointScale;

    [SerializeField]
    private DataPointScale PistonMiniDataPointScale;

    [SerializeField]
    private Animator cameraAnimator;

    [SerializeField]
    private Animator engineAnimator;

    [SerializeField] private float engineSpeed = 10;

    [SerializeField] private Transform fullInfo;
    [SerializeField] private Transform fanInfo;
    [SerializeField] private Transform exhaustInfo;
    [SerializeField] private Transform pistonInfo;

    [SerializeField] private Transform fanInfoWorldSpace;
    [SerializeField] private Transform exhaustInfoWorldSpace;
    [SerializeField] private Transform pistonInfoWorldSpace;

    [SerializeField] private TextMeshProUGUI currentSpeed;

    [SerializeField] private Transform Header;
    [SerializeField] private Transform Body;

    [SerializeField] private Canvas splashScreenCanvas;
    private static readonly int speed = Animator.StringToHash("Speed");
    private static readonly int doPistons = Animator.StringToHash("DoPistons");
    private static readonly int doTopPart = Animator.StringToHash("DoTopPart");
    private static readonly int doMotor = Animator.StringToHash("DoMotor");
    private static readonly int doIdle = Animator.StringToHash("DoIdle");

    // Start is called before the first frame update
    void Start()
    {
        splashScreenCanvas.enabled = true;
        Body.gameObject.SetActive(false);
        Header.gameObject.SetActive(true);
        FilterDataPointScale.Init("CFM",6000);
        FilterMiniDataPointScale.Init("CFM", 6000);
        ExhaustDataPointScale.Init("PPM", 1000);
        ExhaustMiniDataPointScale.Init("PPM", 1000);
        PistonDataPointScale.Init("RPM", 8000);
        PistonMiniDataPointScale.Init("RPM", 8000);
        engineAnimator.SetFloat(speed, engineSpeed);
        ChangeToEngine();
    }


    void UpdateDataPoints()
    {
        float cmf =0;
        float ppm=0;
        float rpm=0;
        rpm = Random.Range(engineSpeed * 156, engineSpeed * 160);
        cmf = Random.Range(engineSpeed * 115, engineSpeed * 120);
        ppm = Random.Range(engineSpeed * 8, engineSpeed * 11);

        FilterDataPointScale.UpdateValue(cmf);
        FilterMiniDataPointScale.UpdateValue(cmf);
        ExhaustDataPointScale.UpdateValue(ppm);
        ExhaustMiniDataPointScale.UpdateValue(ppm);
        PistonDataPointScale.UpdateValue(rpm);
        PistonMiniDataPointScale.UpdateValue(rpm);
    }
    public void SpeedChange(float value)
    {
        currentSpeed.text = (value*100).ToString("F0");
           engineSpeed = value;
        engineAnimator.SetFloat(speed, engineSpeed);

    }
  public  void ChangeToPiston()
    {
        Body.gameObject.SetActive(true);
        Header.gameObject.SetActive(false);
        cameraAnimator.ResetTrigger(doIdle);
        cameraAnimator.ResetTrigger(doMotor);
        cameraAnimator.ResetTrigger(doTopPart);
        cameraAnimator.ResetTrigger(doPistons);

        cameraAnimator.SetTrigger(doPistons);

        pistonInfoWorldSpace.gameObject.SetActive(true);
        exhaustInfoWorldSpace.gameObject.SetActive(false);
        fanInfoWorldSpace.gameObject.SetActive(false);

        fullInfo.gameObject.SetActive(false);
        fanInfo.gameObject.SetActive(false);
        exhaustInfo.gameObject.SetActive(false);
        pistonInfo.gameObject.SetActive(true);
    }

  public void ChangeToFilter()
    {
        Body.gameObject.SetActive(true);
        Header.gameObject.SetActive(false);
        cameraAnimator.ResetTrigger(doIdle);
        cameraAnimator.ResetTrigger(doMotor);
        cameraAnimator.ResetTrigger(doTopPart);
        cameraAnimator.ResetTrigger(doPistons);

        cameraAnimator.SetTrigger(doTopPart);

        pistonInfoWorldSpace.gameObject.SetActive(false);
        exhaustInfoWorldSpace.gameObject.SetActive(false);
        fanInfoWorldSpace.gameObject.SetActive(true);

        fullInfo.gameObject.SetActive(false);
        fanInfo.gameObject.SetActive(true);
        exhaustInfo.gameObject.SetActive(false);
        pistonInfo.gameObject.SetActive(false);
    }

  public void ChangeToExhaust()
    {
        Body.gameObject.SetActive(true);
        Header.gameObject.SetActive(false);
        cameraAnimator.ResetTrigger(doIdle);
        cameraAnimator.ResetTrigger(doMotor);
        cameraAnimator.ResetTrigger(doTopPart);
        cameraAnimator.ResetTrigger(doPistons);

        cameraAnimator.SetTrigger(doMotor);

        pistonInfoWorldSpace.gameObject.SetActive(false);
        exhaustInfoWorldSpace.gameObject.SetActive(true);
        fanInfoWorldSpace.gameObject.SetActive(false);

        fullInfo.gameObject.SetActive(false);
        fanInfo.gameObject.SetActive(false);
        exhaustInfo.gameObject.SetActive(true);
        pistonInfo.gameObject.SetActive(false);
    }

  public void ChangeToEngine()
    {
        cameraAnimator.ResetTrigger(doIdle);
        cameraAnimator.ResetTrigger(doMotor);
        cameraAnimator.ResetTrigger(doTopPart);
        cameraAnimator.ResetTrigger(doPistons);

        cameraAnimator.SetTrigger(doIdle);
        pistonInfoWorldSpace.gameObject.SetActive(true);
        exhaustInfoWorldSpace.gameObject.SetActive(true);
        fanInfoWorldSpace.gameObject.SetActive(true);

        fullInfo.gameObject.SetActive(true);
        fanInfo.gameObject.SetActive(false);
        exhaustInfo.gameObject.SetActive(false);
        pistonInfo.gameObject.SetActive(false);


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        UpdateDataPoints();
    }
}
