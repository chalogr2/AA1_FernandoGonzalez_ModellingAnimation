using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace RobotController
{

    public struct MyQuat
    {

        public float w;
        public float x;
        public float y;
        public float z;
    }

    public struct MyVec
    {

        public float x;
        public float y;
        public float z;
    }






    public class MyRobotController
    {
        #region class variables

        MyQuat quati1, quati2, quati3, quati4; //initial rotations (excercise 1)
        MyQuat quati5, quati6, quati7, quati8;

        int timeAnim1 = 0;
        int currentTime = 0;
        int timeframe = 16;

        float angle1 = 0;
        float angle2 = 0;
        float angle3 = 110;

        float angle1g = -57;
        float angle2g = 3;
        float angle3g = 80;

        bool myCondition = false;
        bool inPosition = false;
        bool arrive1 = false;
        bool arrive2 = false;
        bool arrive3 = false;

        #endregion

        #region public methods



        public string Hi()
        {

            string s = "hello world from my Robot Controller";
            return s;

        }


        //EX1: this function will place the robot in the initial position

        public void PutRobotStraight(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            //todo: change this, use the function Rotate declared below


            MyVec rotA1, rotA2, rotA3, rotA4;

            rotA1.x = 0;
            rotA1.y = 1;
            rotA1.z = 0;

            rotA2.x = 0;
            rotA2.y = 0;
            rotA2.z = 0;

            rotA3.x = 1;
            rotA3.y = 0;
            rotA3.z = 0;

            rotA4.x = 0;
            rotA4.y = 0;
            rotA4.z = 1;

            quati1 = emptyQuaternion(); //0
            quati1 = Rotate(quati1, rotA1, 74);
            rot0 = quati1;

            quati2 = Rotate(rot0, rotA1, 0);
            rot1 = quati2;

            quati3 = emptyQuaternion();
            quati3 = Rotate(rot1, rotA3, 60);
            rot2 = quati3;

            quati4 = emptyQuaternion();
            quati4 = Rotate(rot1, rotA3, 110);
            rot3 = quati4;

            inPosition = true;
        }



        //EX2: this function will interpolate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.


        public bool PickStudAnim(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            MyVec rotA1, rotA2, rotA3, rotA4;

            rotA1.x = 0;
            rotA1.y = 1;
            rotA1.z = 0;

            rotA2.x = 0;
            rotA2.y = 0;
            rotA2.z = 0;

            rotA3.x = 1;
            rotA3.y = 0;
            rotA3.z = 0;

            rotA4.x = 0;
            rotA4.y = 0;
            rotA4.z = 1;

            if (inPosition)
            {
                myCondition = true;
                inPosition = false;
                
            }
            //todo: add a check for your condition



            if (myCondition)
            {
                currentTime = TimeSinceMidnight;
                if (timeAnim1 <= currentTime)
                {
                    if (angle1 > angle1g)
                    {
                        angle1 = angle1 - 5f;
                    }
                    else
                    {
                        arrive1 = true;
                    }

                    if (angle2 < angle2g)
                    {
                        angle2 = angle2 + 5f;
                    }
                    else
                    {
                        arrive2 = true;
                    }

                    if (angle3 > angle3g)
                    {
                        angle3 = angle3 - 5f;
                    }
                    else
                    {
                        arrive3 = true;
                    }

                    timeAnim1 = TimeSinceMidnight + timeframe * 2;
                    Debug.Log(angle1);
                }

                quati5 = emptyQuaternion(); //0
                quati5 = Rotate(quati1, rotA1, angle1);
                rot0 = quati5;

                quati6 = Rotate(rot0, rotA3, angle2);
                rot1 = quati6;

                quati7 = emptyQuaternion();
                quati7 = Rotate(rot0, rotA3, 60);
                rot2 = quati7;

                quati8 = emptyQuaternion();
                quati8 = Rotate(rot0, rotA3, angle3);
                rot3 = quati8;

                if (arrive1 && arrive2 && arrive3)
                {
                    myCondition = false;
                    angle1 = 0;
                    angle2 = 0;
                    angle3 = 110;
                    arrive1 = arrive2 = arrive3 = false;
                }

                return true;
            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        //EX3: this function will calculate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.
        //the only difference wtih exercise 2 is that rot3 has a swing and a twist, where the swing will apply to joint3 and the twist to joint4

        public bool PickStudAnimVertical(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            bool myCondition = false;
            //todo: add a check for your condition



            while (myCondition)
            {
                //todo: add your code here


            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        public static MyQuat GetSwing(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }


        public static MyQuat GetTwist(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }




        #endregion


        #region private and internal methods

        internal int TimeSinceMidnight { get { return (DateTime.Now.Hour * 3600000) + (DateTime.Now.Minute * 60000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; } }


        private static MyQuat NullQ
        {
            get
            {
                MyQuat a;
                a.w = 1;
                a.x = 0;
                a.y = 0;
                a.z = 0;
                return a;

            }
        }

        internal MyQuat emptyQuaternion()
        {
            MyQuat quat;
            quat.w = 1;
            quat.x = 0;
            quat.y = 0;
            quat.z = 0;

            return quat;
        }

        internal MyQuat Multiply(MyQuat q1, MyQuat q2)
        {

            MyQuat result;
            MyVec qV1, qV2, rV;

            qV1.x = q1.x;
            qV1.y = q1.y;
            qV1.z = q1.z;

            qV2.x = q2.x;
            qV2.y = q2.y;
            qV2.z = q2.z;

            result.w = q1.w * q2.w + Vector3DotProduct(qV1, qV2);
            rV = AddVector3(AddVector3(ScaleVector3(qV1, q2.w), ScaleVector3(qV2, q1.w)), Vector3CrossProduct(qV1, qV2));

            result.x = rV.x;
            result.y = rV.y;
            result.z = rV.z;

            return result;

        }

        internal MyQuat Rotate(MyQuat currentRotation, MyVec axis, float angle)
        {

            //takes currentRotation, and calculates a new quaternion rotated by an angle "angle" along the normalized axis "axis"

            MyQuat result, quat2;
            MyVec qV2;

            //Create a second quaternion from the axis and angle:
            float theta = ((float)Math.PI / 180) * angle; //convert euler angle to radians (theta)!!
            quat2.w = (float)Math.Cos(theta / 2);
            qV2 = ScaleVector3(axis, (float)Math.Sin(theta / 2));
            quat2.x = qV2.x;
            quat2.y = qV2.y;
            quat2.z = qV2.z;

            //Multiply both quaternions to implement the rotation:
            result = Multiply(currentRotation, quat2);

            return result;

        }

        internal float Vector3DotProduct(MyVec v1, MyVec v2)
        {
            float result = (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
            return result;
        }

        internal MyVec Vector3CrossProduct(MyVec v1, MyVec v2)
        {
            MyVec result;
            result.x = (v1.y * v2.z) - (v1.z * v2.y);
            result.y = (v1.z * v2.x) - (v1.x * v2.z);
            result.z = (v1.x * v2.y) - (v1.y * v2.x);

            return result;
        }

        internal MyVec ScaleVector3(MyVec v, float scalar)
        {
            MyVec result;
            result.x = v.x * scalar;
            result.y = v.y * scalar;
            result.z = v.z * scalar;

            return result;
        }

        internal MyVec AddVector3(MyVec v1, MyVec v2)
        {
            MyVec result;
            result.x = v1.x + v2.x;
            result.y = v1.y + v2.y;
            result.z = v1.z + v2.z;

            return result;
        }

        internal MyQuat InvertQuaternion(MyQuat q)
        {
            q.x = -q.x;
            q.y = -q.y;
            q.z = -q.z;

            return q;
        }

        #endregion






    }
}
