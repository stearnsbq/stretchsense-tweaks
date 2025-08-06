using HarmonyLib;
using MelonLoader;
using StretchSense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;


namespace ControllerPassthrough
{
    [HarmonyPatch(typeof(OpenGloveManager), "SendToOpenGloves")]
    static class Patch
    {
        private static void Prefix(ref ProfileGlove g, ref ControllerInputState c, ref SliderValues s)
        {


            if (Gamepad.current.aButton.IsPressed() && g.Handedness == Handedness.RIGHT)
            {
                c.SetButtonState(ControllerButton.BUTTON_1, true);
            }


            if (Gamepad.current.bButton.IsPressed() && g.Handedness == Handedness.RIGHT)
            {
                c.SetButtonState(ControllerButton.BUTTON_2, true);
            }



            if (Gamepad.current.dpad.up.IsPressed() && g.Handedness == Handedness.LEFT)
            {
                c.SetButtonState(ControllerButton.BUTTON_1, true);
            }

            if (Gamepad.current.dpad.right.IsPressed() && g.Handedness == Handedness.LEFT)
            {
                c.SetButtonState(ControllerButton.BUTTON_2, true);
            }

            if (Gamepad.current.startButton.IsPressed())
            {
                c.SetButtonState(ControllerButton.MENU, true);
            }


            c.SetButtonState(ControllerButton.TRIGGER, g.Handedness == Handedness.LEFT ? Gamepad.current.leftTrigger.value : Gamepad.current.rightTrigger.value);


            c.SetButtonState(ControllerButton.JOYSTICK_AXES, g.Handedness == Handedness.LEFT ? Gamepad.current.leftStick.value : Gamepad.current.rightStick.value);
             
           
        }

    }
}
