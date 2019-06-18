using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Button_foodomatic : MonoBehaviour
{
    public bool isActive = false;
    private bool stage1Complete = false;
    private bool stage2Complete = false;
    private bool stage3Complete = false;
    private bool stage4Complete = false;
    private bool stage5Complete = false;
    private bool stage6Complete = false;
    private bool stage7Complete = false;

    public GameObject FoodOMaticWallPiece;
    public GameObject FoodOMatic;
    public GameObject Funnel;
    public GameObject Door;
    public GameObject Legs;

    private Vector3 FoodOMaticWallPiece_Origin;
    private Vector3 FoodOMatic_Origin;
    public Vector3 Funnel_Origin;
    public Vector3 Door_Origin;
    public Vector3 Legs_Origin;

    private float wallMoveSpeedHorizontal = 0.004f;
    private float wallMoveSpeedVertical = 0.008f;
    private float foodomaticMoveSpeedHorizontal = 0.007f;
    private float funnelMoveSpeedVertical = 0.4f;
    private float doorMoveSpeedRotateX = 2.0f;

    void Start()
    {
        FoodOMaticWallPiece_Origin = FoodOMaticWallPiece.transform.position;
        FoodOMatic_Origin = FoodOMatic.transform.position;
        Funnel_Origin = Funnel.transform.localPosition;
        Door_Origin = Door.transform.localEulerAngles;
        Legs_Origin = Legs.transform.localEulerAngles;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            if (isActive)
            {
                stage1Complete = true;
                stage2Complete = true;
                stage3Complete = true;
                stage4Complete = true;
                stage5Complete = true;
                stage6Complete = true;
                stage7Complete = true;

                isActive = false; 
            }
            else
            {
                stage1Complete = false;
                stage2Complete = false;
                stage3Complete = false;
                stage4Complete = false;
                stage5Complete = false;
                stage6Complete = false;
                stage7Complete = false;

                isActive = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            if (!stage1Complete)
            {
                var foodWallPiecePos = FoodOMaticWallPiece.transform.position;
                if (foodWallPiecePos.x < FoodOMaticWallPiece_Origin.x + 0.1f)
                {
                    FoodOMaticWallPiece.transform.position = new Vector3(foodWallPiecePos.x + wallMoveSpeedHorizontal, foodWallPiecePos.y, foodWallPiecePos.z);
                }
                else stage1Complete = true;
            }
            else if (!stage2Complete)
            {
                var foodWallPiecePos = FoodOMaticWallPiece.transform.position;
                if (foodWallPiecePos.y > FoodOMaticWallPiece_Origin.y - 0.4f)
                {
                    FoodOMaticWallPiece.transform.position = new Vector3(foodWallPiecePos.x, foodWallPiecePos.y - wallMoveSpeedVertical, foodWallPiecePos.z);
                }
                else stage2Complete = true;
            }
            else if (!stage3Complete)
            {
                var foodPos = FoodOMatic.transform.position;
                if (foodPos.x > FoodOMatic_Origin.x - 0.7f)
                {
                    FoodOMatic.transform.position = new Vector3(foodPos.x - foodomaticMoveSpeedHorizontal, foodPos.y, foodPos.z);
                }
                else stage3Complete = true;
            }
            else if (!stage4Complete)
            {
                var funnelPos = Funnel.transform.localPosition;
                if (funnelPos.y < Funnel_Origin.y + 29.2f)
                {
                    Funnel.transform.localPosition = new Vector3(funnelPos.x, funnelPos.y + funnelMoveSpeedVertical, funnelPos.z);
                }
                else stage4Complete = true;
            }
            else if (!stage5Complete)
            {
                var doorPos = Door.transform.localEulerAngles;
                if (doorPos.x < Door_Origin.x + 90.0f && doorPos.x > 0.0f)
                {
                    Door.transform.localEulerAngles = new Vector3(doorPos.x + doorMoveSpeedRotateX, doorPos.y, doorPos.z);
                    var legsPos = Legs.transform.localEulerAngles;
                    if (legsPos.x > Legs_Origin.x - 90.0f)
                    {
                        Legs.transform.localEulerAngles = new Vector3(legsPos.x - doorMoveSpeedRotateX, legsPos.y, legsPos.z);
                    }
                }
                else stage5Complete = true;
            }
            else if (!stage6Complete)
            {
                var foodWallPiecePos = FoodOMaticWallPiece.transform.position;
                if (foodWallPiecePos.y < FoodOMaticWallPiece_Origin.y)
                {
                    FoodOMaticWallPiece.transform.position = new Vector3(foodWallPiecePos.x, foodWallPiecePos.y + wallMoveSpeedVertical, foodWallPiecePos.z);
                }
                else stage6Complete = true;
            }
            else if (!stage7Complete)
            {
                var foodWallPiecePos = FoodOMaticWallPiece.transform.position;
                if (foodWallPiecePos.x > FoodOMaticWallPiece_Origin.x)
                {
                    FoodOMaticWallPiece.transform.position = new Vector3(foodWallPiecePos.x - wallMoveSpeedHorizontal, foodWallPiecePos.y, foodWallPiecePos.z);
                }
                else stage7Complete = true;
            }
        }
        else
        {
            if (stage7Complete)
            {
                var foodWallPiecePos = FoodOMaticWallPiece.transform.position;
                if (foodWallPiecePos.x < FoodOMaticWallPiece_Origin.x + 0.1f)
                {
                    FoodOMaticWallPiece.transform.position = new Vector3(foodWallPiecePos.x + wallMoveSpeedHorizontal, foodWallPiecePos.y, foodWallPiecePos.z);
                }
                else stage7Complete = false;
            }
            else if (stage6Complete)
            {
                var foodWallPiecePos = FoodOMaticWallPiece.transform.position;
                if (foodWallPiecePos.y > FoodOMaticWallPiece_Origin.y - 0.4f)
                {
                    FoodOMaticWallPiece.transform.position = new Vector3(foodWallPiecePos.x, foodWallPiecePos.y - wallMoveSpeedVertical, foodWallPiecePos.z);
                }
                else stage6Complete = false;
            }
            else if (stage5Complete)
            {
                var doorPos = Door.transform.localEulerAngles;
                if (doorPos.x > Door_Origin.x || Math.Abs(doorPos.x) < 0.2f)
                {
                    Door.transform.localEulerAngles = new Vector3(doorPos.x - doorMoveSpeedRotateX, doorPos.y, doorPos.z);
                    var legsPos = Legs.transform.localEulerAngles;
                    if (legsPos.x < Legs_Origin.x)
                    {
                        Legs.transform.localEulerAngles = new Vector3(legsPos.x + doorMoveSpeedRotateX, legsPos.y, legsPos.z);
                    }
                }
                else stage5Complete = false;
            }
            else if (stage4Complete)
            {
                var funnelPos = Funnel.transform.localPosition;
                if (funnelPos.y > Funnel_Origin.y)
                {
                    Funnel.transform.localPosition = new Vector3(funnelPos.x, funnelPos.y - funnelMoveSpeedVertical, funnelPos.z);
                }
                else stage4Complete = false;
            }
            else if (stage3Complete)
            {
                var foodPos = FoodOMatic.transform.position;
                if (foodPos.x < FoodOMatic_Origin.x)
                {
                    FoodOMatic.transform.position = new Vector3(foodPos.x + foodomaticMoveSpeedHorizontal, foodPos.y, foodPos.z);
                }
                else stage3Complete = false;
            }
            else if (stage2Complete)
            {
                var foodWallPiecePos = FoodOMaticWallPiece.transform.position;
                if (foodWallPiecePos.y < FoodOMaticWallPiece_Origin.y)
                {
                    FoodOMaticWallPiece.transform.position = new Vector3(foodWallPiecePos.x, foodWallPiecePos.y + wallMoveSpeedVertical, foodWallPiecePos.z);
                }
                else stage2Complete = false;
            }
            else if (stage1Complete)
            {
                var foodWallPiecePos = FoodOMaticWallPiece.transform.position;
                if (foodWallPiecePos.x > FoodOMaticWallPiece_Origin.x)
                {
                    FoodOMaticWallPiece.transform.position = new Vector3(foodWallPiecePos.x - wallMoveSpeedHorizontal, foodWallPiecePos.y, foodWallPiecePos.z);
                }
                else stage1Complete = false;
            }
        }
    }
}
