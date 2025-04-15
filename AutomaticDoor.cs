using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace afd_porta_automatica
{
    public enum DoorEvent { PresenceDetected, AbsenceDetected, SafetyObstacle }

    public class AutomaticDoor
    {
        public enum DoorState { Closed, Closing, Open, Opening }
        public DoorState CurrentState { get; set; }
        public int DoorPosition { get; set; }

        public AutomaticDoor()
        {
            CurrentState = DoorState.Closed;
            DoorPosition = 0;
        }

        public void ProcessEvent(DoorEvent trigger)
        {
                switch(CurrentState) { 
                    case DoorState.Closed when trigger == DoorEvent.PresenceDetected:
                        CurrentState = DoorState.Opening;
                        break;

                    case DoorState.Open when trigger == DoorEvent.AbsenceDetected:
                        CurrentState = DoorState.Closing;
                        break;

                    case DoorState.Closing:
                        if (trigger == DoorEvent.PresenceDetected)
                            CurrentState = DoorState.Opening;
                        else if (trigger == DoorEvent.SafetyObstacle)
                        {
                            CurrentState = DoorState.Open;
                            DoorPosition = 100;
                        }
                        break;
                }
        }

        public void UpdatePosition()
        {
            if (CurrentState == DoorState.Opening)
            {
                DoorPosition = Math.Min(100, DoorPosition + 10);
                if (DoorPosition == 100) CurrentState = DoorState.Open;
            }
            else if (CurrentState == DoorState.Closing)
            {
                DoorPosition = Math.Max(0, DoorPosition - 10);
                if (DoorPosition == 0) CurrentState = DoorState.Closed;
            }
        }
    }
}