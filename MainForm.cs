using System;
using System.Drawing;
using System.Windows.Forms;

namespace afd_porta_automatica
{
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