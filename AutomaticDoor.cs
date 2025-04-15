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

    public partial class MainForm : Form
    {
        private readonly AutomaticDoor door = new AutomaticDoor();

        public MainForm()
        {
            InitializeComponent();
            UpdateInterface();
            movement.Interval = 500;
        }

        private void UpdateInterface()
        {
            pbDoorPosition.Value = door.DoorPosition;
            lblStatus.Text = $@"Estado: {door.CurrentState({door.DoorPosition) %}";

            phDoorPosition.ForeColor = door.CurrentState switch
            {
                AutomaticDoor.DoorState.Opening => Color.Orange,
                AutomaticDoor.DoorState.Closing => Color.Orange,
                AutomaticDoor.DoorState.Open => Color.LimeGreen,
                _ => Color.Red
            };
        }

        private void movementTimer_Tick(object sender, EventArgs e)
        {
            door.UpdatePosition();
            UpdateInterface();

            if (door.CurrentState is not (AutomaticDoor.DoorState.Opening or AutomaticDoor.DoorState.Closing))
            {
                movementTimer.Stop();
            }
        }

        private void btnPresence_Click(object sender, EventArgs e)
        {
            door.ProcessEvent(DoorEvent.PresenceDetected);
            HandleMovement()
        }

        private void btnAbsence_Click(object sender, EventArgs e)
        {
            door.ProcessEvent(DoorEvent.AbsenceDetected);
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (door.CurrentState is AutomaticDoor.DoorState.Opening or AutomaticDoor.DoorState.Closing)
            {
                movementTimer.Start();
            }

            UpdateInterface();
        }
    }
}